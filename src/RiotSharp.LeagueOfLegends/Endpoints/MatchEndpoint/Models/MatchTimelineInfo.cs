using RiotSharp.Core.Misc.Converters;
using System.Text.Json.Serialization;

namespace RiotSharp.LeagueOfLegends.Endpoints.MatchEndpoint.Models
{
    public class MatchTimelineInfo
    {
        /// <summary>
        /// Refer to indicate if the game ended in termination.
        /// </summary>
        [JsonPropertyName("endOfGameResult")]
        public required string EndOfGameResult { get; set; }

        /// <summary>
        /// Time between each returned frame.
        /// </summary>
        [JsonPropertyName("frameInterval")]
        [JsonConverter(typeof(TimeSpanConverterFromMilliseconds))]
        public required TimeSpan FrameInterval { get; set; }

        [JsonPropertyName("gameId")]
        public required long GameId { get; set; }

        [JsonPropertyName("participants")]
        public required List<ParticipantTimeLine> Participants { get; set; }

        /// <summary>
        /// List of timeline frames for the game.
        /// </summary>
        [JsonPropertyName("frames")]
        public required List<FramesTimeLine> Frames { get; set; }
    }
}
