using System.Text.Json.Serialization;

namespace RiotSharpNET8.Endpoints.TournamentEndpoint
{
    /// <summary>
    /// Class representing a mastery of a participant (Match API).
    /// </summary>
    public class Mastery
    {
        /// <summary>
        /// Mastery ID.
        /// </summary>
        [JsonPropertyName("masteryId")]
        public int MasteryId { get; set; }

        /// <summary>
        /// Mastery rank.
        /// </summary>
        [JsonPropertyName("rank")]
        public int Rank { get; set; }
    }
}
