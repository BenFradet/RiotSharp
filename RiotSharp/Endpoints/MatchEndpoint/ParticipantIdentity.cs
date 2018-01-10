using Newtonsoft.Json;

namespace RiotSharp.Endpoints.MatchEndpoint
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
        public Player Player { get; set; }
    }
}
