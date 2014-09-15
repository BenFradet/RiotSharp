using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace RiotSharp.StaticDataEndpoint
{
    /// <summary>
    /// Class representing a list of items (Static API).
    /// </summary>
    [Serializable]
    public class ItemListStatic
    {
        internal ItemListStatic() { }

        /// <summary>
        /// Basic data about the items retrieved.
        /// </summary>
        [JsonProperty("basic")]
        public BasicDataStatic BasicData { get; set; }

        /// <summary>
        /// Map of items indexed by their id.
        /// </summary>
        [JsonProperty("data")]
        public Dictionary<int, ItemStatic> Items { get; set; }

        /// <summary>
        /// Information about the groups of an item.
        /// </summary>
        [JsonProperty("groups")]
        public List<GroupStatic> Groups { get; set; }

        /// <summary>
        /// Items' tree (Tools, Defense, Attack, Magic, Movement).
        /// </summary>
        [JsonProperty("tree")]
        public List<ItemTreeStatic> Trees { get; set; }

        /// <summary>
        /// API type (item).
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// Version of the API.
        /// </summary>
        [JsonProperty("version")]
        public string Version { get; set; }
    }
}
