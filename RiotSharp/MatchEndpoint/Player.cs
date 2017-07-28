using Newtonsoft.Json;

namespace RiotSharp.MatchEndpoint
{
    /// <summary>
    /// Player in a match (Match API).
    /// </summary>
    public class Player
    {
        internal Player() { }

        /// <summary>
        /// Current platform ID.
        /// </summary>
        [JsonProperty("currentPlatformId")]
        public string CurrentPlatformId { get; set; }

        /// <summary>
        /// Platform ID.
        /// </summary>
        public string PlatformId { get; set; }

        /// <summary>
        /// Match history URI.
        /// </summary>
        [JsonProperty("matchHistoryUri")]
        public string MatchHistoryUri { get; set; }

        /// <summary>
        /// Profile icon ID.
        /// </summary>
        [JsonProperty("profileIcon")]
        public int ProfileIcon { get; set; }

        /// <summary>
        /// Current account ID.
        /// </summary>
        [JsonProperty("currentAccountId")]
        public long CurrentAccountId { get; set; }

        /// <summary>
        /// Account ID.
        /// </summary>
        public long AccountId { get; set; }

        /// <summary>
        /// Summoner ID.
        /// </summary>
        [JsonProperty("summonerId")]
        public long SummonerId { get; set; }

        /// <summary>
        /// Summoner name.
        /// </summary>
        [JsonProperty("summonerName")]
        public string SummonerName { get; set; }
    }
}
