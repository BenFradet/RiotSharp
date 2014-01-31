using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RiotSharp
{
    public class BlockItemStatic
    {
        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }
    }
}
