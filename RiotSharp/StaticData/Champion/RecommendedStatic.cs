using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RiotSharp
{
    public class RecommendedStatic
    {
        [JsonProperty("blocks")]
        public List<BlockStatic> Blocks { get; set; }

        [JsonProperty("champion")]
        public string Champion { get; set; }

        [JsonProperty("map")]
        public string Map { get; set; }

        [JsonProperty("mode")]
        public string Mode { get; set; }

        [JsonProperty("priority")]
        public bool Priority { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }
}
