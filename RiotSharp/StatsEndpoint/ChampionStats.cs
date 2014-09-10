using System;
using Newtonsoft.Json;

namespace RiotSharp.StatsEndpoint
{
    /// <summary>
    /// Stats for all champions (Stats API).
    /// </summary>
    [Serializable]
    public class ChampionStats
    {
        internal ChampionStats() { }

        /// <summary>
        /// Champion ID. Note that champion ID 0 represents the combined stats for all champions.
        /// </summary>
        [JsonProperty("id")]
        public int ChampionId { get; set; }

        /// <summary>
        /// Champion stats associated with the champion.
        /// </summary>
        [JsonProperty("stats")]
        public ChampionStat Stats { get; set; }
    }
}
