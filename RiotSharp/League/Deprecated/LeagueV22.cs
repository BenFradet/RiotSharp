using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace RiotSharp
{
    /// <summary>
    /// Class representing a League in the API.
    /// </summary>
    [Obsolete("The league api v2.2 is deprecated, please use League instead.")]
    public class LeagueV22
    {
        internal LeagueV22() { }

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
