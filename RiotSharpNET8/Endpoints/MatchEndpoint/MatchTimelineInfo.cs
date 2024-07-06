using System.Text.Json.Serialization;
using RiotSharpNET8.Misc.Converters;

namespace RiotSharpNET8.Endpoints.MatchEndpoint
{
    public class MatchTimelineInfo
    {
        /// <summary>
        /// Time between each returned frame.
        /// </summary>
        [JsonPropertyName("frameInterval")]
        [JsonConverter(typeof(TimeSpanConverterFromMilliseconds))]
        public TimeSpan FrameInterval { get; set; }

        /// <summary>
        /// List of timeline frames for the game.
        /// </summary>
        [JsonPropertyName("frames")]
        public List<MatchFrame> Frames { get; set; }
    }
}
