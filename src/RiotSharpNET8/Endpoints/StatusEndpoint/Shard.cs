using System.Text.Json.Serialization;
using RiotSharpNET8.Misc;

namespace RiotSharpNET8.Endpoints.StatusEndpoint
{
    /// <summary>
    /// Class representing a shard (Status API).
    /// </summary>
    public class Shard
    {
        internal Shard() { }

        /// <summary>
        /// Hostname of the shard.
        /// </summary>
        [JsonPropertyName("hostname")]
        public string Hostname { get; set; }

        /// <summary>
        /// List of locales supported by this shard.
        /// </summary>
        [JsonPropertyName("locales")]
        public List<Language> Locales { get; set; }

        /// <summary>
        /// Name of the region the shard is handling.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Tag of the region the shard is handling.
        /// </summary>
        [JsonPropertyName("region_tag")]
        public string RegionTag { get; set; }

        /// <summary>
        /// Slug.
        /// </summary>
        [JsonPropertyName("slug")]
        public string Slug { get; set; }
    }
}
