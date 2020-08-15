using Newtonsoft.Json;

namespace RiotSharp.Endpoints.ClientEndpoint.PlayerList
{
    public class PlayerScores
    {
        internal PlayerScores() { }
        
        [JsonProperty("assists")]
        public int Assists { get; set; }

        [JsonProperty("creepScore")]
        public int Creeps { get; set; }

        [JsonProperty("deaths")]
        public int Deaths { get; set; }

        [JsonProperty("kills")]
        public int Kills { get; set; }

        [JsonProperty("wardScore")]
        public double Vision { get; set; }
    }
}