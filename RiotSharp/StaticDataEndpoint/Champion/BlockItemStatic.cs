using System;
using Newtonsoft.Json;

namespace RiotSharp.StaticDataEndpoint
{
    /// <summary>
    /// Recommended items in a block (starting, essential, offensive, etc) for a champion (Static API).
    /// </summary>
    [Serializable]
    public class BlockItemStatic
    {
        internal BlockItemStatic() { }

        /// <summary>
        /// Recommended count.
        /// </summary>
        [JsonProperty("count")]
        public int Count { get; set; }

        /// <summary>
        /// Id of the recommended item.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }
    }
}
