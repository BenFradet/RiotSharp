using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RiotSharp
{
    class PlayerStatsSummaryListV11
    {
        [JsonProperty("playerStatSummaries")]
        public List<PlayerStatsSummaryV11> PlayerStatSummaries { get; set; }

        [JsonProperty("summonerId")]
        public long SummonerId { get; set; }
    }
}
