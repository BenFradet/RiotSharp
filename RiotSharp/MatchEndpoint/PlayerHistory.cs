// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PlayerHistory.cs" company="">
//
// </copyright>
// <summary>
//   The player history.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using Newtonsoft.Json;

namespace RiotSharp.MatchEndpoint
{
    /// <summary>
    /// The player history.
    /// </summary>
    class PlayerHistory
    {
        /// <summary>
        /// List of matches for the player.
        /// </summary>
        [JsonProperty("matches")]
        public List<MatchSummary> Matches { get; set; }
    }
}
