namespace RiotSharp.AspNetCore
{
    public class RiotSharpOptions
    {
        public RiotSharpOptions()
        {
            ApiKey = new ApiKey();
            ApiKey.RateLimitPer10S = 10;
            ApiKey.RateLimitPer10M = 500;
            TournamentApiKey = new ApiKey();
            TournamentApiKey.RateLimitPer10S = 10;
            TournamentApiKey.RateLimitPer10M = 500;
        }

        public ApiKey ApiKey { get; set; }
        public ApiKey TournamentApiKey { get; set; }       
    }
}
