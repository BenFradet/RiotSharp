using System.Text.Json.Serialization;
using RiotSharpNET8.Misc.Converters;

namespace RiotSharpNET8.Endpoints.MatchEndpoint
{
    /// <summary>
    /// Class representing a frame in a match (Match API).
    /// </summary>
    public class MatchFrame
    {
        internal MatchFrame() { }

        /// <summary>
        /// List of events for this frame.
        /// </summary>
        [JsonPropertyName("events")]
        public List<MatchEvent> Events { get; set; }

        /// <summary>
        /// Map of each participant ID to the participant's information for the frame.
        /// </summary>
        [JsonPropertyName("participantFrames")]
        public Dictionary<string, ParticipantFrame> ParticipantFrames { get; set; }

        /// <summary>
        /// Represents how much time into the game the frame occurred.
        /// </summary>
        [JsonPropertyName("timestamp")]
        [JsonConverter(typeof(TimeSpanConverterFromMilliseconds))]
        public TimeSpan Timestamp { get; set; }
    }
}
