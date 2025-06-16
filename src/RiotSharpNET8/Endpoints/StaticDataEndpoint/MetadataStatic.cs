using System.Text.Json.Serialization;

namespace RiotSharpNET8.Endpoints.StaticDataEndpoint
{
    /// <summary>
    /// Class representing metadata on runes and items (Static API).
    /// </summary>
    public class MetadataStatic
    {
        /// <summary>
        /// Whether this item is a rune or not.
        /// </summary>
        [JsonPropertyName("isRune")]
        public bool IsRune { get; set; }

        /// <summary>
        /// Tier of the rune.
        /// </summary>
        [JsonPropertyName("tier")]
        public int Tier { get; set; }

        /// <summary>
        /// Type of the rune.
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; }
    }
}
