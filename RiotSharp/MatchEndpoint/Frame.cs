// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Frame.cs" company="">
//
// </copyright>
// <summary>
//   Class representing a frame in a match (Match API).
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;

using Newtonsoft.Json;

namespace RiotSharp.MatchEndpoint
{
    /// <summary>
    /// Class representing a frame in a match (Match API).
    /// </summary>
    [Serializable]
    public class Frame
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Frame"/> class.
        /// </summary>
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
        [JsonConverter(typeof(TimeSpanConverterFromMS))]
        public TimeSpan Timestamp { get; set; }
    }
}
