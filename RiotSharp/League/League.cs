using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace RiotSharp
{
    /// <summary>
    /// Class representing a League in the API.
    /// </summary>
    [Serializable]
    public class League
    {
        internal League() { }

        /// <summary>
        /// LeagueItems associated with this League.
        /// </summary>
        [JsonProperty("entries")]
        public List<LeagueItem> Entries { get; set; }

        /// <summary>
        /// League name.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Id of the participant.
        /// </summary>
        [JsonProperty("participantId")]
        public string ParticipantId { get; set; }

        /// <summary>
        /// League queue (eg: RankedSolo5x5).
        /// </summary>
        [JsonProperty("queue")]
        [JsonConverter(typeof(QueueConverter))]
        public Queue Queue { get; set; }

        /// <summary>
        /// League tier (eg: Challenger).
        /// </summary>
        [JsonProperty("tier")]
        [JsonConverter(typeof(TierConverter))]
        public Tier Tier { get; set; }
    }
}
