// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ShardStatus.cs" company="">
//
// </copyright>
// <summary>
//   Class representing a shard's status (Status API).
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;

using Newtonsoft.Json;

namespace RiotSharp.StatusEndpoint
{
    /// <summary>
    /// Class representing a shard's status (Status API).
    /// </summary>
    public class ShardStatus : Shard
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ShardStatus"/> class.
        /// </summary>
        internal ShardStatus() { }

        /// <summary>
        /// List of services for this shard.
        /// </summary>
        [JsonProperty("services")]
        public List<Service> Services { get; set; }
    }
}
