// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ChampionStat.cs" company="">
//   
// </copyright>
// <summary>
//   Stat of a particular champion (League API).
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;

using Newtonsoft.Json;

namespace RiotSharp.StatsEndpoint
{
    /// <summary>
    /// Stat of a particular champion (League API).
    /// </summary>
    [Serializable]
    public class ChampionStat : AggregatedStat
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ChampionStat"/> class.
        /// </summary>
        internal ChampionStat()
        {
        }

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
