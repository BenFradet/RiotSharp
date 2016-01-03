using Newtonsoft.Json;
using System.Collections.Generic;

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
