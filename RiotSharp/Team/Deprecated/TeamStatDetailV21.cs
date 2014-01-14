using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace RiotSharp
{
    public class TeamStatDetailV21 : Thing
    {
        public TeamStatDetailV21() { }

        public TeamStatDetailV21(JToken json)
        {
            JsonConvert.PopulateObject(json.ToString(), this, RiotApi.JsonSerializerSettings);
        }

        [JsonProperty("averageGamesPlayed")]
        public int AverageGamesplayed { get; set; }

        [JsonProperty("losses")]
        public int Losses { get; set; }

        [JsonProperty("teamId")]
        public TeamId TeamId { get; set; }

        [JsonProperty("teamStatType")]
        public string TeamStatType { get; set; }

        [JsonProperty("wins")]
        public int Wins { get; set; }
    }
}
