using System;
using System.Collections.Generic;
using System.Text;
using RiotSharp.Http.Interfaces;
using RiotSharp.Misc;

namespace RiotSharp.Http
{
    public class RateLimitProvider : IRateLimitProvider
    {
        public readonly IDictionary<TimeSpan, int> RateLimits;

        private readonly IDictionary<Region, RateLimiter> rateLimiters = new Dictionary<Region, RateLimiter>();

        public RateLimitProvider(IDictionary<TimeSpan, int> rateLimits)
        {
            RateLimits = rateLimits;
        }

        public RateLimiter GetLimiter(Region region)
        {
            if (!rateLimiters.ContainsKey(region))
                rateLimiters[region] = new RateLimiter(RateLimits);
            return rateLimiters[region];
        }
    }
}
