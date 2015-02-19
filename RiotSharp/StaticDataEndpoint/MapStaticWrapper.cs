using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace RiotSharp.StaticDataEndpoint
{
    class MapStaticWrapper
    {
        [JsonProperty("data")]
        public Dictionary<int, MapStatic> Data { get; set; }
    }
}
