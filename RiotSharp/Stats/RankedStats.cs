using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RiotSharp
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
