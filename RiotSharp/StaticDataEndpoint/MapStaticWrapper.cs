using Newtonsoft.Json;
using System.Collections.Generic;

namespace RiotSharp.StaticDataEndpoint
{
    /// <summary>
    /// Wrapper for the MapStatic class.
    /// </summary>
    class MapStaticWrapper
    {
        /// <summary>
        /// Map of id to map.
        /// </summary>
        [JsonProperty("data")]
        public Dictionary<int, MapStatic> Data { get; set; }
    }
}
