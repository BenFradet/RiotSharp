using Newtonsoft.Json;

namespace RiotSharp
{
    /// <summary>
    /// Player in a match (Match API).
    /// </summary>
    public class PlayerMatch
    {
        internal PlayerMatch() { }

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
        /// Summoner name.
        /// </summary>
        [JsonProperty("summonerName")]
        public string SummonerName { get; set; }
    }
}
