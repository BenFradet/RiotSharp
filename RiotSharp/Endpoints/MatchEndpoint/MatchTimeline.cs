using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using RiotSharp.Misc.Converters;

namespace RiotSharp.Endpoints.MatchEndpoint
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
        [JsonProperty("frameInterval")]
        [JsonConverter(typeof(TimeSpanConverterFromMilliseconds))]
        public TimeSpan FrameInterval { get; set; }

        /// <summary>
        /// List of timeline frames for the game.
        /// </summary>
        [JsonProperty("frames")]
        public List<Frame> Frames { get; set; }
    }
}
