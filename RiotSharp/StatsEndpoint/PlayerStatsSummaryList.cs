// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PlayerStatsSummaryList.cs" company="">
//   
// </copyright>
// <summary>
//   The player stats summary list.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;

using Newtonsoft.Json;

namespace RiotSharp.StatsEndpoint
{
    /// <summary>
    /// The player stats summary list.
    /// </summary>
    class PlayerStatsSummaryList
    {
        /// <summary>
        /// Gets or sets the player stat summaries.
        /// </summary>
        [JsonProperty("playerStatSummaries")]
        public List<PlayerStatsSummary> PlayerStatSummaries { get; set; }

        /// <summary>
        /// Gets or sets the summoner id.
        /// </summary>
        [JsonProperty("summonerId")]
        public long SummonerId { get; set; }
    }
}
