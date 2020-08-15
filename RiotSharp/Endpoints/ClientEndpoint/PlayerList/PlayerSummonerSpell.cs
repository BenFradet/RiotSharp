using Newtonsoft.Json;

namespace RiotSharp.Endpoints.ClientEndpoint.PlayerList
{
    public class PlayerSummonerSpell
    {
        internal PlayerSummonerSpell() { }
        
        [JsonProperty("displayName")]
        public string DisplayName { get; set; }

        [JsonProperty("rawDisplayName")]
        public string RawDisplayName { get; set; }

        [JsonProperty("rawDescription")]
        public string RawDescription { get; set; }
    }
}