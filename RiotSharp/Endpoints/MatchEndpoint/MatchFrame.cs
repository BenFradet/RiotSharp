﻿using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using RiotSharp.Misc.Converters;

namespace RiotSharp.Endpoints.MatchEndpoint
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
        [JsonProperty("events")]
        public List<MatchEvent> Events { get; set; }

        /// <summary>
        /// Map of each participant ID to the participant's information for the frame.
        /// </summary>
        [JsonProperty("participantFrames")]
        public Dictionary<string, ParticipantFrame> ParticipantFrames { get; set; }

        /// <summary>
        /// Represents how much time into the game the frame occurred.
        /// </summary>
        [JsonProperty("timestamp")]
        [JsonConverter(typeof(TimeSpanConverterFromMilliseconds))]
        public TimeSpan Timestamp { get; set; }
    }
}
