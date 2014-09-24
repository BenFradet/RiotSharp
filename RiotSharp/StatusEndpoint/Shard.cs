using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace RiotSharp.StatusEndpoint
{
    /// <summary>
    /// Class representing a shard (Status API).
    /// </summary>
    [Serializable]
    public class Shard
    {
        internal Shard() { }

        /// <summary>
        /// Hostname of the shard.
        /// </summary>
        [JsonProperty("hostname")]
        public string Hostname { get; set; }

        /// <summary>
        /// List of locales supported by this shard.
        /// </summary>
        [JsonProperty("locales")]
        public List<Language> Locales { get; set; }

        /// <summary>
        /// Name of the region the shard is handling.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Tag of the region the shard is handling.
        /// </summary>
        [JsonProperty("region_tag")]
        public string RegionTag { get; set; }

        /// <summary>
        /// Slug.
        /// </summary>
        [JsonProperty("slug")]
        public Region Slug { get; set; }
    }
}
