using Newtonsoft.Json;
using RiotSharp.Endpoints.ClientEndpoint.Enums;

namespace RiotSharp.Endpoints.ClientEndpoint
{
    /// <summary>
    ///     Represents the statistics of the current game.
    /// </summary>
    public class GameStats
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="GameStats" /> class.
        /// </summary>
        internal GameStats() { }

        /// <summary>
        ///     Gets or sets the name of the played game mode.
        /// </summary>
        [JsonProperty("gameMode")]
        public string Mode { get; set; }

        /// <summary>
        ///     Gets or sets the current ingame time.
        /// </summary>
        [JsonProperty("gameTime")]
        public double GameTime { get; set; }

        /// <summary>
        ///     Gets or sets the name of the played map.
        /// </summary>
        [JsonProperty("mapName")]
        public string MapName { get; set; }

        /// <summary>
        ///     Gets or sets the number of the played map.
        /// </summary>
        [JsonProperty("mapNumber")]
        public int MapNumber { get; set; }

        /// <summary>
        ///     Gets or sets the <see cref="TerrainType" />.
        /// </summary>
        [JsonProperty("mapTerrain")]
        public TerrainType MapTerrain { get; set; }
    }
}