using System.Collections.Generic;
using Newtonsoft.Json;
using RiotSharp.Endpoints.ClientEndpoint.Enums;

namespace RiotSharp.Endpoints.ClientEndpoint.PlayerList
{
    public class Player
    {
        internal Player() { }

        [JsonProperty("championName")]
        public string ChampionName { get; set; }

        [JsonProperty("rawChampionName")]
        public string RawChampionName { get; set; }
        
        [JsonProperty("isBot")]
        public bool IsBot { get; set; }

        [JsonProperty("isDead")]
        public bool IsDead { get; set; }

        [JsonProperty("items")]
        public List<PlayerItem> Items { get; set; }

        [JsonProperty("level")]
        public int Level { get; set; }

        [JsonProperty("position")]
        public PositionType Position { get; set; }

        [JsonProperty("respawnTimer")]
        public double RespawnTimer { get; set; }

        [JsonProperty("runes")]
        public PlayerMainRunes Runes { get; set; }

        [JsonProperty("scores")]
        public PlayerScores Scores { get; set; }

        [JsonProperty("skinID")]
        public int SkinId { get; set; }

        [JsonProperty("summonerName")]
        public string SummonerName { get; set; }

        [JsonProperty("summonerSpells")]
        public PlayerSummonerSpellList SummonerSpells { get; set; }

        [JsonProperty("team")]
        public TeamType Team { get; set; }
    }
}