using System.Text.Json.Serialization;

namespace RiotSharpNET8.Endpoints.StaticDataEndpoint.Champion
{
    /// <summary>
    /// Block of recommended items by type (starting, essential, offensive, etc) for a champion (Static API).
    /// </summary>
    public class BlockStatic
    {
        internal BlockStatic() { }

        /// <summary>
        /// List of recommended items.
        /// </summary>
        [JsonPropertyName("items")]
        public List<BlockItemStatic> Items { get; set; }

        /// <summary>
        /// Rec math.
        /// </summary>
        [JsonPropertyName("recMath")]
        public bool RecMath { get; set; }

        /// <summary>
        /// Type of items (starting, essential, offensive, etc).
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; }
    }
}
