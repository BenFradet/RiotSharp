using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RiotSharp
{
    /// <summary>
    /// Stats for all champions (Stats API).
    /// </summary>
    [Serializable]
    [Obsolete("The stats api v1.2 is deprecated, please use ChampionStats instead.")]
    public class ChampionStatsV12
    {
        internal ChampionStatsV12() { }

        /// <summary>
        /// Champion id.
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// Champion name.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Champion stats associated with the champion.
        /// </summary>
        [JsonProperty("stats")]
        public ChampionStat Stats { get; set; }
    }
}
