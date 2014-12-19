using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace RiotSharp.MatchEndpoint
{
    /// <summary>
    /// Class representing a frame in a match (Match API).
    /// </summary>
    [Serializable]
    public class Frame
    {
        internal Frame() { }

        /// <summary>
        /// List of events for this frame.
        /// </summary>
        [JsonProperty("events")]
        public List<Event> Events { get; set; }

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
