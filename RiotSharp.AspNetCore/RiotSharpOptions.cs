namespace RiotSharp.AspNetCore
{
    public class RiotSharpOptions
    {
        public RiotSharpOptions()
        {
            RiotApi = new ApiKeyOptions();
            RiotApi.RateLimitPer10S = 10;
            RiotApi.RateLimitPer10M = 500;
            TournamentApi = new TournamentApiKeyOptions();
            TournamentApi.RateLimitPer10S = 10;
            TournamentApi.RateLimitPer10M = 500;
        }

        public ApiKeyOptions RiotApi { get; set; }
        public TournamentApiKeyOptions TournamentApi { get; set; }       
    }
}
