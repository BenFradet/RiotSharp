using Newtonsoft.Json;
using RiotSharp.Endpoints.ClientEndpoint.Enums;

namespace RiotSharp.Endpoints.ClientEndpoint
{
    public class GameStats
    {
        internal GameStats()
        {
        }

        [JsonProperty("gameMode")]
        public string Mode { get; set; }

        [JsonProperty("gameTime")]
        public double GameTime { get; set; }

        [JsonProperty("mapName")]
        public string MapName { get; set; }

        [JsonProperty("mapNumber")]
        public string MapNumber { get; set; }

        [JsonProperty("mapTerrain")]
        public TerrainType MapTerrain { get; set; }
    }
}