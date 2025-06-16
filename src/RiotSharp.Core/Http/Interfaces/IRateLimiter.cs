using RiotSharp.Core.Http.RateLimiting;
using RiotSharp.Core.Misc;

namespace RiotSharp.Core.Http.Interfaces
{
	/// <summary>
	/// Interface for the application rate limiter.
	/// </summary>
	public interface IRateLimiter
	{
		/// <summary>
		/// Get a lease for a specific region.
		/// </summary>
		/// <param name="region"></param>
		/// <param name="numberOfLeases"></param>
		/// <returns>true if the lease was available, false and a RetryAfter if not.</returns>
		ValueTask<IRequestLease> GetLeaseForRegion(Region region, int numberOfLeases = 1);

		/// <summary>
		/// Changes the rate limits for a specific region.
		/// </summary>
		/// <param name="region"></param>
		/// <param name="rateLimits"></param>
		void ChangeRateLimitsForRegion(Region region, IDictionary<TimeSpan, int> rateLimits);
	}

}
