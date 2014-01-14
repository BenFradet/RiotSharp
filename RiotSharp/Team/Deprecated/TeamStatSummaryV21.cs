using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace RiotSharp
{
    public class TeamStatSummaryV21 : Thing
    {
        public TeamStatSummaryV21() { }

        public TeamStatSummaryV21(JToken json)
        {
            JsonConvert.PopulateObject(json.ToString(), this, RiotApi.JsonSerializerSettings);
        }

        [JsonProperty("teamId")]
        public TeamId TeamId { get; set; }

        [JsonProperty("teamStatDetails")]
        public List<TeamStatDetailV21> TeamStatDetails { get; set; }
    }
}
