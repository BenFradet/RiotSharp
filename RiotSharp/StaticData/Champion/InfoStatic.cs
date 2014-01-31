using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RiotSharp
{
    public class InfoStatic
    {
        [JsonProperty("attack")]
        public int Attack { get; set; }

        [JsonProperty("defense")]
        public int Defense { get; set; }

        [JsonProperty("difficulty")]
        public int Difficulty { get; set; }

        [JsonProperty("magic")]
        public int Magic { get; set; }
    }
}
