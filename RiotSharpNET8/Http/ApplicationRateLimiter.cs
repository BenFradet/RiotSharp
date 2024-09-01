using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiotSharpNET8.Http
{
	/// <summary>
	/// Rate limiter for the application rate limits
	/// </summary>
	internal class ApplicationRateLimiter
	{
		private readonly RateLimiter _rateLimiter;
		private readonly bool _throwExceptionOnLimitReached;



		public ApplicationRateLimiter(IDictionary<TimeSpan, int> rateLimits, bool throwExceptionOnLimitReached = false)
		{

		}


	}
}
