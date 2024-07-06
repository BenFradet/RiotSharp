using System.Text.Json.Serialization;

namespace RiotSharpNET8.Endpoints.TournamentEndpoint
{
    /// <summary>
    /// Class representing a rune of a participant (Match API).
    /// </summary>
    public class Rune
    {
        /// <summary>
        /// Rune rank.
        /// </summary>
        [JsonPropertyName("rank")]
        public int Rank { get; set; }

        /// <summary>
        /// Rune ID.
        /// </summary>
        [JsonPropertyName("runeId")]
        public int RuneId { get; set; }
    }
}
