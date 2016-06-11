using Newtonsoft.Json;
using System.Collections.Generic;

namespace RiotSharp.StaticDataEndpoint
{
    class MapsStatic
    {
        /// <summary>
        /// Map of id to map.
        /// </summary>
        [JsonProperty("data")]
        public Dictionary<int, MapStatic> Data { get; set; }
    }
}
