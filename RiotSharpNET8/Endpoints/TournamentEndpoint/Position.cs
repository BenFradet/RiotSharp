using System.Text.Json.Serialization;

namespace RiotSharpNET8.Endpoints.TournamentEndpoint
{
    /// <summary>
    /// Participant's position (Match API).
    /// </summary>
    public class Position
    {
        /// <summary>
        /// Participant's X coordinate.
        /// </summary>
        [JsonPropertyName("x")]
        public int X { get; set; }

        /// <summary>
        /// Participant's Y coordinate.
        /// </summary>
        [JsonPropertyName("y")]
        public int Y { get; set; }
    }
}
