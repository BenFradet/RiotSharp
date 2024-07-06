using System.Text.Json.Serialization;
using RiotSharpNET8.Misc;

namespace RiotSharpNET8.Endpoints.TournamentEndpoint
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
        [JsonPropertyName("currentPlatformId")]
        public Platform CurrentPlatformId { get; set; }

        /// <summary>
        /// Platform ID.
        /// </summary>
        [JsonPropertyName("platformId")]
        public Platform PlatformId { get; set; }

        /// <summary>
        /// Match history URI.
        /// </summary>
        [JsonPropertyName("matchHistoryUri")]
        public string MatchHistoryUri { get; set; }

        /// <summary>
        /// Profile icon ID.
        /// </summary>
        [JsonPropertyName("profileIcon")]
        public int ProfileIcon { get; set; }

        /// <summary>
        /// Current account ID.
        /// </summary>
        [JsonPropertyName("currentAccountId")]
        public string CurrentAccountId { get; set; }

        /// <summary>
        /// Account ID.
        /// </summary>
        [JsonPropertyName("accountId")]
        public string AccountId { get; set; }

        /// <summary>
        /// Summoner ID.
        /// </summary>
        [JsonPropertyName("summonerId")]
        public string SummonerId { get; set; }

        /// <summary>
        /// Summoner name.
        /// </summary>
        [JsonPropertyName("summonerName")]
        public string SummonerName { get; set; }
    }
}
