using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace RiotSharp
{
    public class Game : Thing
    {
        public Game(JToken json)
        {
            JsonConvert.PopulateObject(json.ToString(), this, RiotApi.JsonSerializerSettings);
        }

        [JsonProperty("championId")]
        public int ChampionId { get; set; }
        [JsonProperty("createDate")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime CreateDate { get; set; }
        [JsonProperty("createDateStr")]
        public String CreateDateString { get; set; }
        [JsonProperty("fellowPlayers")]
        public List<Player> FellowPlayers { get; set; }
        [JsonProperty("gameId")]
        public long GameId { get; set; }
        [JsonProperty("gameMode")]
        public String GameMode { get; set; }
        [JsonProperty("gameType")]
        public String GameType { get; set; }
        [JsonProperty("invalid")]
        public bool Invalid { get; set; }
        [JsonProperty("level")]
        public int Level { get; set; }
        [JsonProperty("mapId")]
        public int MapId { get; set; }
        [JsonProperty("spell1")]
        public int Spell1 { get; set; }
        [JsonProperty("spell2")]
        public int Spell2 { get; set; }
        [JsonProperty("statistics")]
        public List<RawStat> Statistics { get; set; }
        [JsonProperty("subType")]
        public String SubType { get; set; }
        [JsonProperty("teamId")]
        public int TeamId { get; set; }
    }
}
