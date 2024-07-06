using System.Text.Json.Serialization;

namespace RiotSharpNET8.Endpoints.StaticDataEndpoint.Item
{
    /// <summary>
    /// Class representing an item's group (Static API).
    /// </summary>
    public class GroupStatic
    {
        internal GroupStatic() { }

        /// <summary>
        /// Max group ownable.
        /// </summary>
        [JsonPropertyName("MaxGroupOwnable")]
        public string MaxGroupOwnable { get; set; }

        /// <summary>
        /// Key of the group.
        /// </summary>
        [JsonPropertyName("key")]
        public string Key { get; set; }
    }
}
