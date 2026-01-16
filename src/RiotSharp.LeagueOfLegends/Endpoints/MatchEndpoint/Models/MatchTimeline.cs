using System.Text.Json.Serialization;

namespace RiotSharp.LeagueOfLegends.Endpoints.MatchEndpoint.Models
{
    /// <summary>
    /// Class representing a match's timeline (Match API).
    /// </summary>
    public class MatchTimeline
    {
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
