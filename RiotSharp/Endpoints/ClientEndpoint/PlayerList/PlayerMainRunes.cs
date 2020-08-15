using Newtonsoft.Json;

namespace RiotSharp.Endpoints.ClientEndpoint.PlayerList
{
    public class PlayerMainRunes
    {
        internal PlayerMainRunes() { }

        [JsonProperty("keystone")]
        public PlayerRune Keystone { get; set; }

        [JsonProperty("primaryRuneTree")]
        public PlayerRuneTree PrimaryTree { get; set; }

        [JsonProperty("secondaryRuneTree")]
        public PlayerRuneTree SecondaryTree { get; set; }
    }
}