using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace RiotSharp.StaticDataEndpoint
{
    /// <summary>
    /// Class representing a map (Static API).
    /// </summary>
    [Serializable]
    public class MapStatic
    {
        internal MapStatic() { }

        /// <summary>
        /// Map id.
        /// </summary>
        [JsonProperty("mapId")]
        public int MapId { get; set; }

        /// <summary>
        /// List of ids of the unpurchasable items.
        /// </summary>
        [JsonProperty("unpurchasableItemList")]
        public List<int> UnpurchasableItemList { get; set; }

        /// <summary>
        /// Map image.
        /// </summary>
        [JsonProperty("image")]
        public ImageStatic Image { get; set; }

        /// <summary>
        /// Map name.
        /// </summary>
        [JsonProperty("mapName")]
        public string MapName { get; set; }
    }
}
