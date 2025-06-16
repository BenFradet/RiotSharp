using System.Collections.Concurrent;
using System.Threading.RateLimiting;
using RiotSharp.Core.Http.Interfaces;
using RiotSharp.Core.Misc;

namespace RiotSharp.Core.Http.RateLimiting
{
	/// <summary>
	/// Rate limiter for the application rate limits.
	/// The ratelimiter does not have a queue so if the rate limit is reached, the request will be rejected with a retry time.
	/// </summary>
	public class ApplicationRateLimiter : IRateLimiter, IDisposable
	{
		/// <summary>
		/// Dictionary containing the rate limiters for each region.
		/// Some of the regions are not used by the API, but they are included.
		/// </summary>
		private readonly ConcurrentDictionary<Region, List<System.Threading.RateLimiting.RateLimiter>> _regionRateLimits = new();

		/// <summary>
		/// Constructor for the ApplicationRateLimiter.
		/// </summary>
		/// <param name="rateLimits"></param>
		/// <exception cref="ArgumentException">If dictionary is null or is empty an exception is thrown.</exception>
		public ApplicationRateLimiter(IDictionary<TimeSpan, int> rateLimits)
		{
			if(rateLimits == null || rateLimits.Count == 0)
			{
				throw new ArgumentException("Rate limits cannot be null or empty.");
			}

			List<Region> regions = Enum.GetValues(typeof(Region)).Cast<Region>().ToList();
			
			foreach (var region in regions)
			{
				// Create rate limiters with their respective windows and permits, then sort by window length
				var sortedRateLimiters = rateLimits
					.OrderBy(rateLimit => rateLimit.Key) // Sort by the TimeSpan key (window length)
					.Select(rateLimit =>
					{
						var options = new FixedWindowRateLimiterOptions
						{
							PermitLimit = rateLimit.Value,
							Window = rateLimit.Key,
							QueueLimit = 0,
							QueueProcessingOrder = QueueProcessingOrder.OldestFirst,
							AutoReplenishment = true
						};
						return (System.Threading.RateLimiting.RateLimiter)new FixedWindowRateLimiter(options);
					}).ToList();

				// Add sorted limiters to the corresponding region in the dictionary
				_regionRateLimits.TryAdd(region, sortedRateLimiters);
			}
		}

		/// <summary>
		/// Function that handles requesting a lease for a specific region.
		/// Will go through the list of rate limiters for the region and try to acquire a lease.
		/// </summary>
		/// <param name="region"></param>
		/// <param name="numberOfLeases"></param>
		/// <returns><see cref="RateLimitLease"/> object with the IsAcquired set to either true or false indicating the result of the request.</returns>
		/// TODO: Consider making the returnvalue nullable.
		private async ValueTask<RateLimitLease> AsyncAcquireLeaseForRegion(Region region, int numberOfLeases)
		{
			var rateLimitersForRegion = _regionRateLimits[region];
			RateLimitLease? lease = null;

			// This foreach will go through the rate limiters in order of their window length.
			// E.g. if the rate limits are the developer rate limit, it will go through the 20/1s rate limiter first, then the 100/2min rate limiter.
			foreach(var rateLimiter in rateLimitersForRegion)
			{
				lease?.Dispose(); // Dispose the previous lease if it exists

				try
				{
					lease = await rateLimiter.AcquireAsync(numberOfLeases).ConfigureAwait(false);
					if (!lease.IsAcquired) // If the lease could not be acquired then return the unacquired lease for handling.
					{
						return lease;
					}
				}
				catch (Exception e)
				{
					lease?.Dispose(); // Dispose the lease if an exception is thrown
					throw;
				}
			}

			return lease;
		}

		/// <summary>
		/// Get a lease for a specific region. If the lease is not acquired, the function will return a <see cref="RequestLease"/> object with the retry time.
		/// </summary>
		/// <param name="region"></param>
		/// <param name="numberOfLeases"></param>
		/// <returns>A <see cref="RequestLease"/> object with information about the state of the request.</returns>
		/// <exception cref="ArgumentOutOfRangeException">If the number of leases exceed a given limit.</exception>
		public async ValueTask<IRequestLease> GetLeaseForRegion(Region region, int numberOfLeases = 1)
		{
			try
			{
				using var result = await AsyncAcquireLeaseForRegion(region, numberOfLeases).ConfigureAwait(false);

				if (result.IsAcquired)
				{
					return new RequestLease(true, null, RateLimitType.App);
				}
				else
				{
					result.TryGetMetadata(MetadataName.RetryAfter, out var retryAfter);
					return new RequestLease(false, (TimeSpan)retryAfter, RateLimitType.App);
				}
			}
			catch (Exception e)
			{
				throw;
			}
		}

		/// <summary>
		/// This function changes the Rate limits for a specific region.
		/// Do note that the current rate limiters will be replaced with the new ones, and the old ones will be lost.
		/// </summary>
		/// <param name="region"></param>
		/// <param name="rateLimits"></param>
		/// <exception cref="ArgumentException">If dictionary is null or is empty an exception is thrown.</exception>
		public async void ChangeRateLimitsForRegion(Region region, IDictionary<TimeSpan, int> rateLimits)
		{
			if(rateLimits == null || rateLimits.Count == 0)
			{
				throw new ArgumentException("Rate limits cannot be null or empty.");
			}
			
			// Dispose of the existing rate limiters for the region
			if (_regionRateLimits.TryGetValue(region, out var existingRateLimiters))
			{
				foreach (var rateLimiter in existingRateLimiters)
				{
					await rateLimiter.DisposeAsync().ConfigureAwait(false);
				}
			}

			// Create new rate limiters with their respective windows and permits, sorted by window length
			var sortedRateLimiters = rateLimits
				.OrderBy(rateLimit => rateLimit.Key) // Sort by the TimeSpan key (window length)
				.Select(rateLimit =>
				{
					var options = new FixedWindowRateLimiterOptions
					{
						PermitLimit = rateLimit.Value,
						Window = rateLimit.Key,
						QueueLimit = 0,
						QueueProcessingOrder = QueueProcessingOrder.OldestFirst,
						AutoReplenishment = true
					};
					return (System.Threading.RateLimiting.RateLimiter)new FixedWindowRateLimiter(options);
				}).ToList();

			// Add or update the sorted limiters for the region in the dictionary
			_regionRateLimits.AddOrUpdate(region, sortedRateLimiters, (key, oldValue) => sortedRateLimiters);
		}

		/// <summary>
		/// Dispose of all the rate limiters.
		/// </summary>
	 	public void Dispose()
		{
			foreach (var rateLimiters in _regionRateLimits.Values)
			{
				foreach (var rateLimiter in rateLimiters)
				{
					rateLimiter.DisposeAsync().ConfigureAwait(false);
				}
			}
		}
	}
}
