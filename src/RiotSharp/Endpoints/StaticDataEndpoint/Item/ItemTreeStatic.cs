using System.Collections.Generic;
using Newtonsoft.Json;

namespace RiotSharp.Endpoints.StaticDataEndpoint.Item
{
    /// <summary>
    /// Class representing an item tree in the shop (Static API).
    /// </summary>
    public class ItemTreeStatic
    {
        internal ItemTreeStatic() { }

        /// <summary>
        /// Tree's header (Tools, Defense, Attack, Magic, Movement).
        /// </summary>
        [JsonProperty("header")]
        public string Header { get; set; }

        /// <summary>
        /// Tags available in this tree.
        /// </summary>
        [JsonProperty("tags")]
        public List<string> Tags { get; set; }
    }
}
