using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RiotSharp
{
    class ChampionList
    {
        [JsonProperty("champions")]
        public List<Champion> Champions { get; set; }
    }
}
