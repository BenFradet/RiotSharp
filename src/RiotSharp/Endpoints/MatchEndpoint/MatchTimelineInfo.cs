using Newtonsoft.Json;
using RiotSharp.Misc.Converters;
using System;
using System.Collections.Generic;
using System.Text;

namespace RiotSharp.Endpoints.MatchEndpoint
{
    public class MatchTimelineInfo
    {
        internal MatchTimelineInfo() { }

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
        public List<MatchFrame> Frames { get; set; }
    }
}
