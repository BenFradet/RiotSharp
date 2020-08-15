using Newtonsoft.Json;

namespace RiotSharp.Endpoints.ClientEndpoint.PlayerList
{
    public class PlayerSummonerSpellList
    {
        internal PlayerSummonerSpellList() { }
        
        [JsonProperty("summonerSpellOne")]
        public PlayerSummonerSpell One { get; set; }
        
        [JsonProperty("summonerSpellTwo")]
        public PlayerSummonerSpell Two { get; set; }
    }
}