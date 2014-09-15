using System.Collections.Generic;
using Newtonsoft.Json;

namespace RiotSharp.StatsEndpoint
{
    class PlayerStatsSummaryList
    {
        [JsonProperty("playerStatSummaries")]
        public List<PlayerStatsSummary> PlayerStatSummaries { get; set; }

        [JsonProperty("summonerId")]
        public long SummonerId { get; set; }
    }
}
