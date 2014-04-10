using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RiotSharp
{
    [Obsolete("The stats api v1.2 is deprecated, please use RankedStats instead.")]
    class RankedStatsV12
    {
        [JsonProperty("champions")]
        public List<ChampionStatsV12> ChampionStats { get; set; }

        [JsonProperty("modifyDate")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime ModifyDate { get; set; }

        [JsonProperty("summonerId")]
        public long SummonerId { get; set; }
    }
}
