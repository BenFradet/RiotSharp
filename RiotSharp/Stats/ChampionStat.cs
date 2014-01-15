using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace RiotSharp
{
    /// <summary>
    /// Stat of a particular champion (League API).
    /// </summary>
    public class ChampionStat : AggregatedStat
    {
        public ChampionStat()
            : base() { }

        public ChampionStat(JToken json)
            : base(json) { }

        /// <summary>
        /// Maximum number of deaths, only returned for ranked stats.
        /// </summary>
        [JsonProperty("maxNumDeaths")]
        public int MaxNumDeaths { get; set; }

        /// <summary>
        /// Total number of deaths per session, only returned for ranked stats.
        /// </summary>
        [JsonProperty("totalDeathsPerSession")]
        public int TotalDeathsPerSession { get; set; }
    }
}
