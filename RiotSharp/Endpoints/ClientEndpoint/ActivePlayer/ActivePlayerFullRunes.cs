using System.Collections.Generic;
using Newtonsoft.Json;
using RiotSharp.Endpoints.ClientEndpoint.PlayerList;

namespace RiotSharp.Endpoints.ClientEndpoint.ActivePlayer
{
    public class ActivePlayerFullRunes
    {
        internal ActivePlayerFullRunes() { }

        [JsonProperty("generalRunes")]
        public List<PlayerRune> General { get; set; }

        [JsonProperty("keystone")]
        public PlayerRune Keystone { get; set; }

        [JsonProperty("primaryRuneTree")]
        public PlayerRuneTree PrimaryTree { get; set; }

        [JsonProperty("secondaryRuneTree")]
        public PlayerRuneTree SecondaryTree { get; set; }

        [JsonProperty("statRunes")]
        public List<ActivePlayerStatRune> Stats { get; set; }
    }
}