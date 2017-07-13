using System;
using System.Collections.Generic;

namespace RiotSharp.AspNetCore
{
    public class ApiKeyOptions
    {
        internal ApiKeyOptions() { }

        public string ApiKey { get; set; }
        public IDictionary<TimeSpan, int> RateLimits { get; set; }
    }
}
