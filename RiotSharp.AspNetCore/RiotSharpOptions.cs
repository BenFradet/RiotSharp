﻿namespace RiotSharp.AspNetCore
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
            RiotApi.RateLimitPer10S = 10;
            RiotApi.RateLimitPer10M = 500;
            TournamentApi = new TournamentApiKeyOptions();
            TournamentApi.RateLimitPer10S = 10;
            TournamentApi.RateLimitPer10M = 500;
        }

        public bool UseMemoryCache { get; set; }
        public ApiKeyOptions RiotApi { get; set; }
        public TournamentApiKeyOptions TournamentApi { get; set; }       
    }
#pragma warning restore
}
