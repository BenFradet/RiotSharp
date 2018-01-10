using System.Collections.Generic;
using Newtonsoft.Json;

namespace RiotSharp.Endpoints.MatchEndpoint
{
    public class ParticipantTimeline
    {
        /// <summary>
        /// The lane of the participant.
        /// </summary>
        [JsonProperty("lane")]
        public string Lane { get; set; }

        /// <summary>
        /// The role of the participant.
        /// </summary>
        [JsonProperty("role")]
        public string Role { get; set; }

        /// <summary>
        /// The participant ID.
        /// </summary>
        [JsonProperty("participantId")]
        public int ParticipantId { get; set; }

        [JsonProperty("goldPerMinDeltas")]
        public Dictionary<string, double> GoldPerMinDeltas { get; set; }

        [JsonProperty("xpDiffPerMinDeltas")]
        public Dictionary<string, double> XpDiffPerMinDeltas { get; set; }

        [JsonProperty("xpPerMinDeltas")]
        public Dictionary<string, double> XpPerMinDeltas { get; set; }

        [JsonProperty("csDiffPerMinDeltas")]
        public Dictionary<string, double> CsDiffPerMinDeltas { get; set; }

        [JsonProperty("creepsPerMinDeltas")]
        public Dictionary<string, double> CreepsPerMinDeltas { get; set; }

        [JsonProperty("damageTakenDiffPerMinDeltas")]
        public Dictionary<string, double> DamageTakenDiffPerMinDeltas { get; set; }

        [JsonProperty("damageTakenPerMinDeltas")]
        public Dictionary<string, double> DamageTakenPerMinDeltas { get; set; }
    }
}
