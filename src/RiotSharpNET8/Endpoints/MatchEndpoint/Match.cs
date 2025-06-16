using System.Text.Json.Serialization;

namespace RiotSharpNET8.Endpoints.MatchEndpoint
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
        public MatchMetadata Metadata { get; set; }

        /// <summary>
        /// Info containing the most information about the match.
        /// </summary>
        [JsonPropertyName("info")]
        public MatchInfo Info { get; set; }
    }
}
