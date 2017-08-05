using System;
using System.Collections.Generic;

namespace RiotSharp.AspNetCore
{
    public class ApiKeyOptions
    {
        internal ApiKeyOptions() { }

        public string ApiKey { get; set; }
        public IDictionary<TimeSpan, int> RateLimits { get; set; }

        /// <summary>
        /// Enable or disable default caching for the static data endpint
        /// </summary>
        public bool UseCache { get; set; }
        /// <summary>
        /// Enable or disable ASP.NET Core memory cache implementation for caching
        /// </summary>
        public bool UseMemoryCache { get; set; }
        /// <summary>
        /// Sliding expiration time for caching of the static data endpoint
        /// </summary>
        public TimeSpan SlidingExpirationTime { get; set; }
    }
}
