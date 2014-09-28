// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ParticipantIdentity.cs" company="">
//
// </copyright>
// <summary>
//   Class representing a participant's identity in a match (Match API).
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;

using Newtonsoft.Json;

namespace RiotSharp.MatchEndpoint
{
    /// <summary>
    /// Class representing a participant's identity in a match (Match API).
    /// </summary>
    [Serializable]
    public class ParticipantIdentity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ParticipantIdentity"/> class.
        /// </summary>
        internal ParticipantIdentity() { }

        /// <summary>
        /// Participant ID.
        /// </summary>
        [JsonProperty("participantId")]
        public int ParticipantId { get; set; }

        /// <summary>
        /// Player information.
        /// </summary>
        [JsonProperty("player")]
        public Player Player { get; set; }
    }
}
