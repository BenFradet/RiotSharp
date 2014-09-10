using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using RiotSharp.Misc;

namespace RiotSharp.StatsEndpoint
{
    class RankedStats
    {
        [JsonProperty("champions")]
        public List<ChampionStats> ChampionStats { get; set; }

        [JsonProperty("modifyDate")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime ModifyDate { get; set; }

        [JsonProperty("summonerId")]
        public long SummonerId { get; set; }
    }
}
