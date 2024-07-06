using System.Text.Json.Serialization;

namespace RiotSharpNET8.Endpoints.TeamEndpoint
{
    /// <summary>
    /// Team stats (Team API).
    /// </summary>
    public class TeamStatDetail
    {
        internal TeamStatDetail() { }

        /// <summary>
        /// Number of games played on average.
        /// </summary>
        [JsonPropertyName("averageGamesPlayed")]
        public int AverageGamesPlayed { get; set; }

        /// <summary>
        /// Number of losses.
        /// </summary>
        [JsonPropertyName("losses")]
        public int Losses { get; set; }

        /// <summary>
        /// Type of team stat.
        /// </summary>
        [JsonPropertyName("teamStatType")]
        public string TeamStatType { get; set; }

        /// <summary>
        /// Number of wins.
        /// </summary>
        [JsonPropertyName("wins")]
        public int Wins { get; set; }
    }
}
