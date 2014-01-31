using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RiotSharp
{
    public class LevelTipStatic
    {
        [JsonProperty("effect")]
        public List<string> Effects { get; set; }

        [JsonProperty("label")]
        public List<string> Labels { get; set; }
    }
}
