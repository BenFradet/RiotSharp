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
	public class RequestLease
	{
		/// <summary>
		/// Indicates if the request was acquired.
		/// </summary>
		public bool IsAcquired { get; set; }

		/// <summary>
		/// If the request was denied, a RetryAfter TimeSpan is set.
		/// </summary>
		public TimeSpan? RetryAfter { get; set; }

		/// <summary>
		/// Constructor for the RequestLease object.
		/// </summary>
		/// <param name="isAcquired"></param>
		/// <param name="retryAfter"></param>
		public RequestLease(bool isAcquired, TimeSpan? retryAfter)
		{
			IsAcquired = isAcquired;
			RetryAfter = retryAfter;
		}
	}
}
