using System.Text.Json.Serialization;

namespace RiotSharp.LeagueOfLegends.Endpoints.MatchEndpoint.Models
{
    /// <summary>
    /// Match class containing all properties to define a match.
    /// </summary>
    public class Match
    {
        /// <summary>
        /// Metadata of the match.
        /// </summary>
        [JsonPropertyName("metadata")]
        public required MatchMetadata Metadata { get; set; }

        /// <summary>
        /// Info containing the most information about the match.
        /// </summary>
        [JsonPropertyName("info")]
        public required MatchInfo Info { get; set; }
    }
}
