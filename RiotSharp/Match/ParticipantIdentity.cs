using Newtonsoft.Json;

namespace RiotSharp
{
    /// <summary>
    /// Class representing a participant's identity in a match (Match API).
    /// </summary>
    public class ParticipantIdentity
    {
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
        public PlayerMatch Player { get; set; }
    }
}
