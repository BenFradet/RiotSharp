using System.Collections.Generic;
using Newtonsoft.Json;

namespace RiotSharp.Endpoints.MatchEndpoint
{
    /// <summary>
    /// Class representing a team in a match (Match API).
    /// </summary>
    public class TeamStats
    {
        internal TeamStats() { }

        /// <summary>
        /// If game was draft mode, contains banned champion data, otherwise null.
        /// </summary>
        [JsonProperty("bans")]
        public List<TeamBan> Bans { get; set; }

        /// <summary>
        /// Information about the objectives the team took.
        /// </summary>
        [JsonProperty("objectives")]
        public TeamStatsObjectives Objectives { get; set; }

        /// <summary>
        /// Team ID.
        /// </summary>
        [JsonProperty("teamId")]
        public int TeamId { get; set; }

        /// <summary>
        /// A string indicating whether or not the team won.
        /// </summary>
        [JsonProperty("win")]
        public string Win { get; set; }
    }
}
