using RiotSharp.Core.Misc.Converters;
using System.Text.Json.Serialization;

namespace RiotSharp.LeagueOfLegends.Endpoints.MatchEndpoint.Models
{
    /// <summary>
    /// Timeline frame data for a match.
    /// </summary>
    public class FramesTimeLine
    {
        /// <summary>
        /// List of events that occurred in this frame.
        /// </summary>
        [JsonPropertyName("events")]
        public required List<EventsTimeLine> Events { get; set; }

        /// <summary>
        /// Map of participant ID to participant frame data.
        /// </summary>
        [JsonPropertyName("participantFrames")]
        public required Dictionary<string, ParticipantFrame> ParticipantFrames { get; set; }

        /// <summary>
        /// Timestamp of this frame (in milliseconds).
        /// </summary>
        [JsonPropertyName("timestamp")]
        [JsonConverter(typeof(DateTimeConverterFromLong))]
        public required DateTime Timestamp { get; set; }
    }
}
