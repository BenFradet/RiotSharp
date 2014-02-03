using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RiotSharp
{
    public class RuneListStatic
    {
        [JsonProperty("basic")]
        public object Basic { get; set; }

        [JsonProperty("data")]
        public Dictionary<int, RuneStatic> Data { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }
    }
}
