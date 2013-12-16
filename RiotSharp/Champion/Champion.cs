using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace RiotSharp
{
    public class Champion : Thing
    {
        public Champion(JToken json)
        {
            JsonConvert.PopulateObject(json.ToString(), this, RiotApi.JsonSerializerSettings);
        }

        [JsonProperty("active")]
        public bool Active { get; set; }
        [JsonProperty("attackRank")]
        public int AttackRank { get; set; }
        [JsonProperty("botEnabled")]
        public bool BotEnabled { get; set; }
        [JsonProperty("botMmEnabled")]
        public bool BotMmEnabled { get; set; }
        [JsonProperty("defenseRank")]
        public int DefenseRank { get; set; }
        [JsonProperty("difficultyRank")]
        public int DifficultyRank { get; set; }
        [JsonProperty("freeToPlay")]
        public bool FreeToPlay { get; set; }
        [JsonProperty("id")]
        public long Id { get; set; }
        [JsonProperty("magicRank")]
        public int MagicRank { get; set; }
        [JsonProperty("name")]
        public String Name { get; set; }
        [JsonProperty("rankedPlayEnabled")]
        public bool RankedPlayEnabled { get; set; }
    }
}
