using System.Text.Json.Serialization;

namespace RiotSharp.LeagueOfLegends.Endpoints.MatchEndpoint.Models
{
    /// <summary>
    /// Position on the map.
    /// </summary>
    public class Position
    {
        /// <summary>
        /// X coordinate.
        /// </summary>
        [JsonPropertyName("x")]
        public int X { get; set; }

        /// <summary>
        /// Y coordinate.
        /// </summary>
        [JsonPropertyName("y")]
        public int Y { get; set; }
    }
}
