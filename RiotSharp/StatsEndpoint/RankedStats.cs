// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RankedStats.cs" company="">
//   
// </copyright>
// <summary>
//   The ranked stats.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;

using Newtonsoft.Json;

namespace RiotSharp.StatsEndpoint
{
    /// <summary>
    /// The ranked stats.
    /// </summary>
    class RankedStats
    {
        /// <summary>
        /// Gets or sets the champion stats.
        /// </summary>
        [JsonProperty("champions")]
        public List<ChampionStats> ChampionStats { get; set; }

        /// <summary>
        /// Gets or sets the modify date.
        /// </summary>
        [JsonProperty("modifyDate")]
        [JsonConverter(typeof(DateTimeConverterFromLong))]
        public DateTime ModifyDate { get; set; }

        /// <summary>
        /// Gets or sets the summoner id.
        /// </summary>
        [JsonProperty("summonerId")]
        public long SummonerId { get; set; }
    }
}
