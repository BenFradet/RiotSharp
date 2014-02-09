using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RiotSharp
{
    class MasteryPagesV11
    {
        [JsonProperty("pages")]
        public List<MasteryPageV11> Pages { get; set; }

        [JsonProperty("summonerId")]
        public long SummonerId { get; set; }
    }
}
