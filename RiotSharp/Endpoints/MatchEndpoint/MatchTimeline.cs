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
        /// Metadata of the match
        /// </summary>
        [JsonProperty("metadata")]
        public MatchMetadata Metadata { get; set; }

        /// <summary>
        /// Info containing the most information about the match timeline.
        /// </summary>
        [JsonProperty("info")]
        public MatchTimelineInfo Info { get; set; }
    }
}
