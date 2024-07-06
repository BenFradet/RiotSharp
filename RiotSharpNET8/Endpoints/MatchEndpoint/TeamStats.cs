using System.Text.Json.Serialization;

namespace RiotSharpNET8.Endpoints.MatchEndpoint
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
        [JsonPropertyName("bans")]
        public List<TeamBan> Bans { get; set; }

        /// <summary>
        /// Information about the objectives the team took.
        /// </summary>
        [JsonPropertyName("objectives")]
        public TeamStatsObjectives Objectives { get; set; }

        /// <summary>
        /// Team ID.
        /// </summary>
        [JsonPropertyName("teamId")]
        public int TeamId { get; set; }

        /// <summary>
        /// A string indicating whether or not the team won.
        /// </summary>
        [JsonPropertyName("win")]
        public bool Win { get; set; }
    }
}
