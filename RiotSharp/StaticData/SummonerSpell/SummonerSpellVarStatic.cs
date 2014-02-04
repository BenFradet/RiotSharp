using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RiotSharp
{
    public class SummonerSpellVarStatic
    {
        [JsonProperty("coeff")]
        public object Coeff { get; set; }

        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("link")]
        public string Link { get; set; }
    }
}
