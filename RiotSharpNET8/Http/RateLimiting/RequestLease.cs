using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiotSharpNET8.Http.RateLimiting
{
	
	/// <summary>
	/// Return object for the rate limiters.
	/// </summary>
	public class RequestLease : IRequestLease
	{
		
		/// <inheritdoc/>
		public bool IsAcquired { get; set; }
		
		/// <inheritdoc/>
		public TimeSpan? RetryAfter { get; set; }
		
		/// <inheritdoc/>
		public RateLimitType RateLimitType { get; set; }

		/// <summary>
		/// Constructor for the RequestLease object.
		/// </summary>
		/// <param name="isAcquired"></param>
		/// <param name="retryAfter"></param>
		public RequestLease(bool isAcquired, TimeSpan? retryAfter, RateLimitType rateLimitType)
		{
			IsAcquired = isAcquired;
			RetryAfter = retryAfter;
			RateLimitType = rateLimitType;
		}
	}
}
