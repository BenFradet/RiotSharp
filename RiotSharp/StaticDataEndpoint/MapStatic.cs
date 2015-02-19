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

        [JsonProperty("mapId")]
        public int MapId { get; set; }

        [JsonProperty("unpurchasableItemList")]
        public List<int> UnpurchasableItemList { get; set; }

        [JsonProperty("image")]
        public ImageStatic Image { get; set; }

        [JsonProperty("mapName")]
        public string MapName { get; set; }
    }
}
