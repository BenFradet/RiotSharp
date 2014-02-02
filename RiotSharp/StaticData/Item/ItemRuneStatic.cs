using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RiotSharp
{
    public class ItemRuneStatic
    {
        [JsonProperty("isRune")]
        public bool IsRune { get; set; }

        [JsonProperty("tier")]
        public int Tier { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }
}
