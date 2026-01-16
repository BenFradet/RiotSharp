using System.Text.Json.Serialization;

namespace RiotSharp.LeagueOfLegends.Endpoints.MatchEndpoint.Models
{
    /// <summary>
    /// Missions data.
    /// </summary>
    public class Missions
    {
        /// <summary>
        /// Player score 0.
        /// </summary>
        [JsonPropertyName("playerScore0")]
        public int PlayerScore0 { get; set; }

        /// <summary>
        /// Player score 1.
        /// </summary>
        [JsonPropertyName("playerScore1")]
        public int PlayerScore1 { get; set; }

        /// <summary>
        /// Player score 2.
        /// </summary>
        [JsonPropertyName("playerScore2")]
        public int PlayerScore2 { get; set; }

        /// <summary>
        /// Player score 3.
        /// </summary>
        [JsonPropertyName("playerScore3")]
        public int PlayerScore3 { get; set; }

        /// <summary>
        /// Player score 4.
        /// </summary>
        [JsonPropertyName("playerScore4")]
        public int PlayerScore4 { get; set; }

        /// <summary>
        /// Player score 5.
        /// </summary>
        [JsonPropertyName("playerScore5")]
        public int PlayerScore5 { get; set; }

        /// <summary>
        /// Player score 6.
        /// </summary>
        [JsonPropertyName("playerScore6")]
        public int PlayerScore6 { get; set; }

        /// <summary>
        /// Player score 7.
        /// </summary>
        [JsonPropertyName("playerScore7")]
        public int PlayerScore7 { get; set; }

        /// <summary>
        /// Player score 8.
        /// </summary>
        [JsonPropertyName("playerScore8")]
        public int PlayerScore8 { get; set; }

        /// <summary>
        /// Player score 9.
        /// </summary>
        [JsonPropertyName("playerScore9")]
        public int PlayerScore9 { get; set; }

        /// <summary>
        /// Player score 10.
        /// </summary>
        [JsonPropertyName("playerScore10")]
        public int PlayerScore10 { get; set; }

        /// <summary>
        /// Player score 11.
        /// </summary>
        [JsonPropertyName("playerScore11")]
        public int PlayerScore11 { get; set; }
    }
}
