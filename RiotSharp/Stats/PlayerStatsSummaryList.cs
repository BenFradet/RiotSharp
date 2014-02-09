using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RiotSharp
{
    class PlayerStatsSummaryList
    {
        [JsonProperty("playerStatSummaries")]
        public List<PlayerStatsSummary> PlayerStatSummaries { get; set; }

        [JsonProperty("summonerId")]
        public long SummonerId { get; set; }
    }
}
