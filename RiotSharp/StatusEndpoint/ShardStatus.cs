using System.Collections.Generic;
using Newtonsoft.Json;

namespace RiotSharp.StatusEndpoint
{
    /// <summary>
    /// Class representing a shard's status (Status API).
    /// </summary>
    public class ShardStatus : Shard
    {
        internal ShardStatus() { }

        /// <summary>
        /// List of services for this shard.
        /// </summary>
        [JsonProperty("services")]
        public List<Service> Services { get; set; }
    }
}
