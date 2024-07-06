using System.Text.Json.Serialization;
using RiotSharpNET8.Misc.Converters;

namespace RiotSharpNET8.Endpoints.TournamentEndpoint
{
    /// <summary>
    /// Class representing a match's timeline (Match API).
    /// </summary>
    public class MatchTimeline
    {
        internal MatchTimeline() { }

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
