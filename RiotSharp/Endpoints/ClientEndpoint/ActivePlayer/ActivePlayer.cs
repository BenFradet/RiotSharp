using Newtonsoft.Json;

namespace RiotSharp.Endpoints.ClientEndpoint.ActivePlayer
{
    public class ActivePlayer
    {
        internal ActivePlayer() { }

        [JsonProperty("abilities")]
        public ActivePlayerAbilities Abilities { get; set; }

        [JsonProperty("championStats")]
        public ActivePlayerChampionStats ChampionStats { get; set; }

        [JsonProperty("currentGold")]
        public double CurrentGold { get; set; }

        [JsonProperty("fullRunes")]
        public ActivePlayerFullRunes Runes { get; set; }

        [JsonProperty("level")]
        public int Level { get; set; }

        [JsonProperty("summonerName")]
        public string SummonerName { get; set; }
    }
}