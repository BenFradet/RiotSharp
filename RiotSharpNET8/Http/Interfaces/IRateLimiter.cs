using RiotSharpNET8.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.RateLimiting;
using System.Threading.Tasks;
using RiotSharpNET8.Http.RateLimiting;

namespace RiotSharpNET8.Http.Interfaces
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
		ValueTask<RequestLease> GetLeaseForRegion(Region region, int numberOfLeases = 1);

		/// <summary>
		/// Changes the rate limits for a specific region.
		/// </summary>
		/// <param name="region"></param>
		/// <param name="rateLimits"></param>
		void ChangeRateLimitsForRegion(Region region, IDictionary<TimeSpan, int> rateLimits);
	}

}
