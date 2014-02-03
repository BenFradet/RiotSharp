using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RiotSharp
{
    public class MasteryListStatic
    {
        [JsonProperty("data")]
        public Dictionary<int, MasteryStatic> Data { get; set; }

        [JsonProperty("tree")]
        public MasteryTreeStatic Tree { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }
    }
}
