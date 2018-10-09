using System;
using System.Collections.Generic;

namespace RiotSharp.AspNetCore
{
    /// <summary>
    /// Specifies the options for ApiKey
    /// </summary>
    public class ApiKeyOptions
    {
        internal ApiKeyOptions() { }

        /// <summary>
        /// Gets or sets the API key.
        /// </summary>
        public string ApiKey { get; set; }

        /// <summary>
        /// Gets or sets the rate limits.
        /// </summary>
        public IDictionary<TimeSpan, int> RateLimits { get; set; }

        /// <summary>
        /// Enable or disable default RiotSharp's internal caching for the static data endpint
        /// </summary>
        public bool UseCache { get; set; }

        /// <summary>
        /// Enable or disable ASP.NET Core in-memory cache implementation for caching
        /// </summary>
        public bool UseMemoryCache { get; set; }
        /// <summary>
        /// Enable or disable ASP.NET Core distributed cache implementation for caching
        /// </summary>
        public bool UseDistributedCache { get; set; }
        /// <summary>
        /// Enable or disable memory cache and distributed cache. If enabled, in-memory cache will be at first and distributed as a fallback.
        /// </summary>
        public bool UseHybridCache { get; set; }

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
