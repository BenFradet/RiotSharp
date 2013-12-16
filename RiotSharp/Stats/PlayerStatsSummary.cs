using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace RiotSharp
{
    public class PlayerStatsSummary : Thing
    {
        public PlayerStatsSummary() { }

        public PlayerStatsSummary(JToken json)
        {
            JsonConvert.PopulateObject(json.ToString(), this, RiotApi.JsonSerializerSettings);
        }

        [JsonProperty("aggregatedStats")]
        public List<AggregatedStat> AggregatedStats { get; set; }
        [JsonProperty("losses")]
        public int Losses { get; set; }
        [JsonProperty("modifyDate")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime ModifyDate { get; set; }
        [JsonProperty("modifyDateStr")]
        public String ModifyDateString { get; set; }
        [JsonProperty("playerStatSummaryType")]
        public String PlayerStatSummaryType { get; set; }
        [JsonProperty("wins")]
        public int Wins { get; set; }
    }
}
