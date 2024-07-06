using System.Text.Json.Serialization;

namespace RiotSharpNET8.Endpoints.StaticDataEndpoint.Map
{
    /// <summary>
    /// Class representing a map (Static API).
    /// </summary>
    public class MapStatic
    {
        internal MapStatic() { }

        /// <summary>
        /// Map id.
        /// </summary>
        [JsonPropertyName("mapId")]
        public int MapId { get; set; }

        /// <summary>
        /// List of ids of the unpurchasable items.
        /// </summary>
        [JsonPropertyName("unpurchasableItemList")]
        public List<int> UnpurchasableItemList { get; set; }

        /// <summary>
        /// Map image.
        /// </summary>
        [JsonPropertyName("image")]
        public ImageStatic Image { get; set; }

        /// <summary>
        /// Map name.
        /// </summary>
        [JsonPropertyName("mapName")]
        public string MapName { get; set; }
    }
}
