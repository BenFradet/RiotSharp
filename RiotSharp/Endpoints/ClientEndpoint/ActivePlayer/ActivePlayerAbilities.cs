using Newtonsoft.Json;

namespace RiotSharp.Endpoints.ClientEndpoint.ActivePlayer
{
    public class ActivePlayerAbilities
    {
        internal ActivePlayerAbilities() { }

        [JsonProperty("passive")]
        public ActivePlayerAbility Passive { get; set; }

        [JsonProperty("Q")]
        public ActivePlayerAbility Q { get; set; }

        [JsonProperty("W")]
        public ActivePlayerAbility W { get; set; }

        [JsonProperty("E")]
        public ActivePlayerAbility E { get; set; }

        [JsonProperty("R")]
        public ActivePlayerAbility R { get; set; }
    }
}