using System;
using System.Collections.Generic;

namespace RiotSharp.AspNetCore.Options
{
    /// <summary>
    /// Options for dependency injection
    /// </summary>
    public class RiotSharpOptions
    {
#pragma warning disable CS1591
        public RiotSharpOptions()
        {
            RiotApi = new ApiKeyOptions();
            RiotApi.SlidingExpirationTime = TimeSpan.FromHours(1);
            RiotApi.RateLimits = new Dictionary<TimeSpan, int>
            {
                [TimeSpan.FromSeconds(1)] = 20,
                [TimeSpan.FromMinutes(2)] = 100
            };
            TournamentApi = new TournamentApiKeyOptions();
            TournamentApi.RateLimits = new Dictionary<TimeSpan, int>
            {
                [TimeSpan.FromSeconds(10)] = 10,
                [TimeSpan.FromMinutes(10)] = 500
            };
        }
        
        public ApiKeyOptions RiotApi { get; set; }
        public TournamentApiKeyOptions TournamentApi { get; set; }
    }
#pragma warning restore
}
