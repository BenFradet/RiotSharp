// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TeamStatDetail.cs" company="">
//
// </copyright>
// <summary>
//   Team stats (Team API).
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;

using Newtonsoft.Json;

namespace RiotSharp.TeamEndpoint
{
    /// <summary>
    /// Team stats (Team API).
    /// </summary>
    [Serializable]
    public class TeamStatDetail
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TeamStatDetail"/> class.
        /// </summary>
        internal TeamStatDetail() { }

        /// <summary>
        /// Number of games played on average.
        /// </summary>
        [JsonProperty("averageGamesPlayed")]
        public int AverageGamesPlayed { get; set; }

        /// <summary>
        /// Number of losses.
        /// </summary>
        [JsonProperty("losses")]
        public int Losses { get; set; }

        /// <summary>
        /// Type of team stat.
        /// </summary>
        [JsonProperty("teamStatType")]
        public string TeamStatType { get; set; }

        /// <summary>
        /// Number of wins.
        /// </summary>
        [JsonProperty("wins")]
        public int Wins { get; set; }
    }
}
