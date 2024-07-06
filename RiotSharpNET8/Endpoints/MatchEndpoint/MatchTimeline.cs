using System.Text.Json.Serialization;

namespace RiotSharpNET8.Endpoints.MatchEndpoint
{
    /// <summary>
    /// Class representing a match's timeline (Match API).
    /// </summary>
    public class MatchTimeline
    {
        internal MatchTimeline() { }

        /// <summary>
        /// Metadata of the match
        /// </summary>
        [JsonPropertyName("metadata")]
        public MatchMetadata Metadata { get; set; }

        /// <summary>
        /// Info containing the most information about the match timeline.
        /// </summary>
        [JsonPropertyName("info")]
        public MatchTimelineInfo Info { get; set; }
    }
}
