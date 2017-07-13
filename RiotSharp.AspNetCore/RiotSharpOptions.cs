namespace RiotSharp.AspNetCore
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
            TournamentApi = new TournamentApiKeyOptions();
        }

        public bool UseMemoryCache { get; set; }
        public ApiKeyOptions RiotApi { get; set; }
        public TournamentApiKeyOptions TournamentApi { get; set; }
    }
#pragma warning restore
}
