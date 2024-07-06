using System.Text.Json.Serialization;

namespace RiotSharpNET8.Endpoints.StatusEndpoint
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
        [JsonPropertyName("services")]
        public List<Service> Services { get; set; }
    }
}
