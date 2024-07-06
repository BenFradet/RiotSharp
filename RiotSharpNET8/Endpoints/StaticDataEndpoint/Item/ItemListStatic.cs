using System.Text.Json.Serialization;

namespace RiotSharpNET8.Endpoints.StaticDataEndpoint.Item
{
    /// <summary>
    /// Class representing a list of items (Static API).
    /// </summary>
    public class ItemListStatic
    {
        internal ItemListStatic() { }
        /// <summary>
        /// Map of items indexed by their id.
        /// </summary>
        [JsonPropertyName("data")]
        [JsonConverter(typeof(ItemsConverter))]
        public Dictionary<int, ItemStatic> Items { get; set; }

        /// <summary>
        /// Information about the groups of an item.
        /// </summary>
        [JsonPropertyName("groups")]
        public List<GroupStatic> Groups { get; set; }

        /// <summary>
        /// Items' tree (Tools, Defense, Attack, Magic, Movement).
        /// </summary>
        [JsonPropertyName("tree")]
        public List<ItemTreeStatic> Trees { get; set; }

        /// <summary>
        /// API type (item).
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; }

        /// <summary>
        /// Version of the API.
        /// </summary>
        [JsonPropertyName("version")]
        public string Version { get; set; }
    }
}
