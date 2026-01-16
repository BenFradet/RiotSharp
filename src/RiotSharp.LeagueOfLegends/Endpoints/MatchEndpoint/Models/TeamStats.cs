using System.Text.Json.Serialization;

namespace RiotSharp.LeagueOfLegends.Endpoints.MatchEndpoint.Models
{
    /// <summary>
    /// Team statistics from a match (Match API).
    /// </summary>
    public class TeamStats
    {
        /// <summary>
        /// List of champion bans.
        /// </summary>
        [JsonPropertyName("bans")]
        public List<Ban> Bans { get; set; }

        /// <summary>
        /// Objectives completed by the team.
        /// </summary>
        [JsonPropertyName("objectives")]
        public Objectives Objectives { get; set; }

        /// <summary>
        /// Team ID (100 = Blue, 200 = Red).
        /// </summary>
        [JsonPropertyName("teamId")]
        public int TeamId { get; set; }

        /// <summary>
        /// Flag indicating whether the team won.
        /// </summary>
        [JsonPropertyName("win")]
        public bool Win { get; set; }
    }
}
