using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RiotSharp
{
    class RankedStatsV11
    {
        [JsonProperty("champions")]
        public List<ChampionStatsV11> ChampionStats { get; set; }

        [JsonProperty("modifyDate")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime ModifyDate { get; set; }

        [JsonProperty("modifyDateStr")]
        public string ModifyDateString { get; set; }

        [JsonProperty("summonerId")]
        public long SummonerId { get; set; }
    }
}
