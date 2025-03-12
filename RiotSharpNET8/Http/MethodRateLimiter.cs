using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.RateLimiting;
using System.Threading.Tasks;
using RiotSharpNET8.Http.Interfaces;
using RiotSharpNET8.Http.RateLimiting;
using RiotSharpNET8.Misc;

namespace RiotSharpNET8.Http
{
	/// <summary>
	/// The MethodRateLimiter is a special RateLimiter that is endforced per endpoint.
	/// As default the limit is 20.000 requests per 10 seconds, but others have lower limits.
	/// Some endpoints have different limits per region.
	/// Should the wrong MethodRateLimiter be used, it will be possible to change the rate limits and the IsRegionBased flag.
	/// </summary>
	public class MethodRateLimiter : IRateLimiter
	{
		/// <summary>
		/// Dictionary containing the rate limiters for each region.
		/// Some of the regions are not used by the API, but they are included.
		/// </summary>
		private readonly ConcurrentDictionary<Region, List<System.Threading.RateLimiting.RateLimiter>> _regionRateLimits = new();

		/// <summary>
		/// Flag that specifies if the rate limiter is region based. If not then one rate limiter is used for all regions.
		/// </summary>
		public bool IsRegionBased { get; set; }

		/// <summary>
		/// Constructor for the Global method rate limiter. The given Dictionary is used for all regions.
		/// </summary>
		/// <param name="isRegionBased"></param>
		/// <param name="rateLimits"></param>
		public MethodRateLimiter(bool isRegionBased, IDictionary<TimeSpan, int> rateLimits)
		{
			if (isRegionBased)
				throw new ArgumentException("The chosen constructor is for the global method rate limiting, but the given parameter was regional!");
			else
				IsRegionBased = isRegionBased;

			if (rateLimits == null || rateLimits.Count == 0)
				throw new ArgumentException("Rate limits cannot be null or empty.");

			List<Region> regions = new List<Region> { Region.Global };

			// Copied straight from ApplicationRateLimiter, I hope it works(:
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
						return (System.Threading.RateLimiting.RateLimiter) new FixedWindowRateLimiter(options);
					}).ToList();

				// Add sorted limiters to the corresponding region in the dictionary
				_regionRateLimits.TryAdd(region, sortedRateLimiters);
			}
		}

		/// <summary>
		/// Constructor for the region based method rate limiter.
		/// </summary>
		/// <param name="isRegionBased"></param>
		/// <param name="rateLimits"></param>
		public MethodRateLimiter(bool isRegionBased, IDictionary<Region, IDictionary<TimeSpan, int>> rateLimits)
		{
			if (!isRegionBased)
				throw new ArgumentException("The chosen constructor is for the regional method rate limiting, but the given parameter was global!");
			else
				IsRegionBased = isRegionBased;

			if (rateLimits == null || rateLimits.Count == 0)
				throw new ArgumentException("Rate limits cannot be null or empty.");

			List<Region> regions = Enum.GetValues(typeof(Region)).Cast<Region>().ToList();

			// Copied straight from ApplicationRateLimiter, I hope it works(:
			foreach (var region in regions)
			{
				var regionRateLimits = rateLimits[region];

				// Create rate limiters with their respective windows and permits, then sort by window length
				var sortedRateLimiters = regionRateLimits
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
						return (System.Threading.RateLimiting.RateLimiter) new FixedWindowRateLimiter(options);
					}).ToList();

				// Add sorted limiters to the corresponding region in the dictionary
				_regionRateLimits.TryAdd(region, sortedRateLimiters);
			}
		}

		public void ChangeRateLimitsForRegion(Region region, IDictionary<TimeSpan, int> rateLimits)
		{
		}


		//TODO: Implement a helper function that loops through the rate limiters and tries to acquire a lease.

		/// <summary>
		/// Get a lease for a specific region.
		/// </summary>
		/// <param name="region"></param>
		/// <param name="numberOfLeases"></param>
		/// <returns></returns>
		public ValueTask<RequestLease> GetLeaseForRegion(Region region, int numberOfLeases = 1)
		{
			// If the rate limiter is region based, get the list of ratelimiters. If not, get the global ratelimiter.
			// This check is not really necessary, but it is here for clarity.
			// When the list of ratelimiters is retrieved, loop through them like in the ApplicationRateLimiter.
			return new ValueTask<RequestLease>();
		}
	}
}
