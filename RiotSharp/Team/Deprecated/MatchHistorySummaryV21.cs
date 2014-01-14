using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace RiotSharp
{
    public class MatchHistorySummaryV21 : Thing
    {
        public MatchHistorySummaryV21() { }

        public MatchHistorySummaryV21(JToken json)
        {
            JsonConvert.PopulateObject(json.ToString(), this, RiotApi.JsonSerializerSettings);
        }

        [JsonProperty("assists")]
        public int Assists { get; set; }

        [JsonProperty("date")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime Date { get; set; }

        [JsonProperty("deaths")]
        public int Deaths { get; set; }

        [JsonProperty("gameId")]
        public long GameId { get; set; }

        [JsonProperty("gameMode")]
        [JsonConverter(typeof(GameModeConverter))]
        public GameMode GameMode { get; set; }

        [JsonProperty("invalid")]
        public bool Invalid { get; set; }

        [JsonProperty("kills")]
        public int Kills { get; set; }

        [JsonProperty("mapId")]
        public int MapId { get; set; }

        [JsonProperty("oppositeTeamKills")]
        public int OppositeTeamKills { get; set; }

        [JsonProperty("oppositeTeamName")]
        public string OppositeTeamName { get; set; }

        [JsonProperty("win")]
        public bool Win { get; set; }
    }
}
