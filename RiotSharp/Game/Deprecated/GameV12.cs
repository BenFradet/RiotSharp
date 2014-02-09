using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace RiotSharp
{
    /// <summary>
    /// Class representing a Game in the API.
    /// </summary>
    [Obsolete("The game api v1.2 is deprecated, please use Game instead.")]
    public class GameV12
    {
        internal GameV12() { }

        /// <summary>
        /// Champion ID associated with game.
        /// </summary>
        [JsonProperty("championId")]
        public int ChampionId { get; set; }

        /// <summary>
        /// Date game was played.
        /// </summary>
        [JsonProperty("createDate")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// Other players associated with the game.
        /// </summary>
        [JsonProperty("fellowPlayers")]
        public List<Player> FellowPlayers { get; set; }

        /// <summary>
        /// Game ID.
        /// </summary>
        [JsonProperty("gameId")]
        public long GameId { get; set; }

        /// <summary>
        /// Game mode.
        /// </summary>
        [JsonProperty("gameMode")]
        [JsonConverter(typeof(GameModeConverter))]
        public GameMode GameMode { get; set; }

        /// <summary>
        /// Game type.
        /// </summary>
        [JsonProperty("gameType")]
        [JsonConverter(typeof(GameTypeConverter))]
        public GameType GameType { get; set; }

        /// <summary>
        /// Invalid flag.
        /// </summary>
        [JsonProperty("invalid")]
        public bool Invalid { get; set; }

        /// <summary>
        /// Level.
        /// </summary>
        [JsonProperty("level")]
        public int Level { get; set; }

        /// <summary>
        /// Map ID.
        /// </summary>
        [JsonProperty("mapId")]
        public int MapId { get; set; }

        /// <summary>
        /// ID of first summoner spell.
        /// </summary>
        [JsonProperty("spell1")]
        public int Spell1 { get; set; }

        /// <summary>
        /// ID of second summoner spell.
        /// </summary>
        [JsonProperty("spell2")]
        public int Spell2 { get; set; }

        /// <summary>
        /// Statistics associated with the game for this summoner.
        /// </summary>
        [JsonProperty("statistics")]
        public List<RawStatV12> Statistics { get; set; }

        /// <summary>
        /// Game sub-type.
        /// </summary>
        [JsonProperty("subType")]
        [JsonConverter(typeof(GameSubTypeConverter))]
        public GameSubType SubType { get; set; }

        /// <summary>
        /// Team ID associated with game.
        /// </summary>
        [JsonProperty("teamId")]
        public int TeamId { get; set; }
    }
}
