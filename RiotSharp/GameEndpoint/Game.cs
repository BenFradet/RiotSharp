using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using RiotSharp.GameEndpoint.Enums;

namespace RiotSharp.GameEndpoint
{
    /// <summary>
    /// Class representing a Game in the API.
    /// </summary>
    public class Game
    {
        internal Game() { }

        /// <summary>
        /// Champion ID associated with game.
        /// </summary>
        [JsonProperty("championId")]
        public int ChampionId { get; set; }

        /// <summary>
        /// Date game was played.
        /// </summary>
        [JsonProperty("createDate")]
        [JsonConverter(typeof(DateTimeConverterFromLong))]
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// Other players associated with the game.
        /// </summary>
        [JsonProperty("fellowPlayers")]
        public List<Player> FellowPlayers { get; set; }

        /// <summary>
        /// Game ID.
        /// <para>A gameId can be repeated over diffrent servers as they are not shared!</para>
        /// </summary>
        [JsonProperty("gameId")]
        public long GameId { get; set; }

        /// <summary>
        /// Game mode.
        /// </summary>
        [JsonProperty("gameMode")]
        public GameMode GameMode { get; set; }

        /// <summary>
        /// Game type.
        /// </summary>
        [JsonProperty("gameType")]
        public GameType GameType { get; set; }

        /// <summary>
        /// Invalid flag.
        /// </summary>
        [JsonProperty("invalid")]
        public bool Invalid { get; set; }

        /// <summary>
        /// Ip earned during the game.
        /// </summary>
        [JsonProperty("ipEarned")]
        public int IpEarned { get; set; }

        /// <summary>
        /// Level of the champion.
        /// </summary>
        [JsonProperty("level")]
        public int Level { get; set; }

        /// <summary>
        /// Map type.
        /// </summary>
        [JsonProperty("mapId")]
        public MapType MapType { get; set; }

        /// <summary>
        /// ID of first summoner spell.
        /// </summary>
        [JsonProperty("spell1")]
        public int SummonerSpell1 { get; set; }

        /// <summary>
        /// ID of second summoner spell.
        /// </summary>
        [JsonProperty("spell2")]
        public int SummonerSpell2 { get; set; }

        /// <summary>
        /// Statistics associated with the game for this summoner.
        /// </summary>
        [JsonProperty("stats")]
        public RawStat Statistics { get; set; }

        /// <summary>
        /// Game sub-type.
        /// </summary>
        [JsonProperty("subType")]
        public GameSubType GameSubType { get; set; }

        /// <summary>
        /// Team ID associated with game.
        /// <para>Blue = 100</para>
        /// <para>Purple = 200</para>
        /// </summary>
        [JsonProperty("teamId")]
        public int TeamId { get; set; }
    }
}
