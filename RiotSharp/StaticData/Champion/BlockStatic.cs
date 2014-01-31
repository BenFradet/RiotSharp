using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RiotSharp
{
    public class BlockStatic
    {
        [JsonProperty("items")]
        public List<BlockItemStatic> Items { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }
}
