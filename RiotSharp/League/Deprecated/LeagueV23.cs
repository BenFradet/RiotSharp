using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RiotSharp
{
    /// <summary>
    /// Class representing a League in the API.
    /// </summary>
    [Obsolete("The league api v2.3 is deprecated, please use League instead.")]
    [Serializable]
    public class LeagueV23
    {
        internal LeagueV23() { }

        /// <summary>
        /// LeagueItems associated with this League.
        /// </summary>
        [JsonProperty("entries")]
        public List<LeagueItemV23> Entries { get; set; }

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
        /// League queue.
        /// </summary>
        [JsonProperty("queue")]
        [JsonConverter(typeof(QueueConverter))]
        public Queue Queue { get; set; }

        /// <summary>
        /// League tier.
        /// </summary>
        [JsonProperty("tier")]
        [JsonConverter(typeof(TierConverter))]
        public Tier Tier { get; set; }
    }
}
