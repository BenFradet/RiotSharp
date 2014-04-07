using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RiotSharp
{
    [Obsolete("The champion api v1.1 is deprecated, please use ChampionList instead.")]
    class ChampionListV11
    {
        [JsonProperty("champions")]
        public List<ChampionV11> Champions { get; set; }
    }
}
