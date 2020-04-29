using RiotSharp.AspNetCore.Caching;
using System;
using System.Collections.Generic;

namespace RiotSharp.AspNetCore.Options
{
    /// <summary>
    /// Specifies the options for ApiKey
    /// </summary>
    public class ApiKeyOptions
    {
        internal ApiKeyOptions() {
            CacheType = CacheType.PassThrough;
        }

        /// <summary>
        /// Gets or sets the API key.
        /// </summary>
        public string ApiKey { get; set; }

        /// <summary>
        /// Gets or sets the rate limits.
        /// </summary>
        public IDictionary<TimeSpan, int> RateLimits { get; set; }

        /// <summary>
        /// Cache type for the RiotSharp API. By default caching is disabled.
        /// </summary>
        public CacheType CacheType { get; set; }

        /// <summary>
        /// Sliding expiration time for caching of the static data endpoint
        /// </summary>
        public TimeSpan SlidingExpirationTime { get; set; }

        /// <summary>
        /// For static data only: Throws a RiotSharpException instead of delaying the request when the rate limit is reached.
        /// </summary>
        public bool ThrowOnRateLimitedReached { get; set; }
    }
}
