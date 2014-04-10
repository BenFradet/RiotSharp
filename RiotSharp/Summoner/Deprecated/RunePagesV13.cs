using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RiotSharp
{
    [Obsolete("The summoner api v1.3 is deprecated, please use RunePages instead.")]
    class RunePagesV13
    {
        [JsonProperty("pages")]
        public List<RunePageV13> Pages { get; set; }

        [JsonProperty("summonerId")]
        public long SummonerId { get; set; }
    }
}
