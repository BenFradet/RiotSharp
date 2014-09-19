using System;
using Newtonsoft.Json;

namespace RiotSharp.MatchEndpoint
{
    /// <summary>
    /// Player in a match (Match API).
    /// </summary>
    [Serializable]
    public class Player
    {
        internal Player() { }

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
