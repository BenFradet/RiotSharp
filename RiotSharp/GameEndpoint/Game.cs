using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace RiotSharp.GameEndpoint
{
    /// <summary>
    /// Class representing a Game in the API.
    /// </summary>
    [Serializable]
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
        /// <list type="table">
        /// <listheader><description>Possible values:</description></listheader>
        /// <item><term>CLASSIC</term><description>Classic Summoner's Rift and Twisted Treeline games</description></item>
        /// <item><term>ODIN</term><description>Dominion/Crystal Scar games</description></item>
        /// <item><term>ARAM</term><description>ARAM games</description></item>
        /// <item><term>TUTORIAL</term><description>Tutorial games</description></item>
        /// <item><term>ONEFORALL</term><description>One for All games</description></item>
        /// <item><term>FIRSTBLOOD</term><description>Snowdown Showdown games</description></item>
        /// </list>
        /// </summary>
        [JsonProperty("gameMode")]
        [JsonConverter(typeof(GameModeConverter))]
        public GameMode GameMode { get; set; }

        /// <summary>
        /// Game type.
        /// <list type="table">
        /// <listheader><description>Possible values:</description></listheader>
        /// <item><term>CUSTOM_GAME</term><description>Custom games</description></item>
        /// <item><term>TUTORIAL_GAME</term><description>Tutorial games</description></item>
        /// <item><term>MATCHED_GAME</term><description>All other games</description></item>
        /// </list>
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
        /// Map ID.
        /// <list type="table">
        /// <listheader><description>Possible values:</description></listheader>
        /// <item><term>1</term><description>Summoner's Rift: Summer Variant</description></item>
        /// <item><term>2</term><description>Summoner's Rift: Autumn Variant</description></item>
        /// <item><term>3</term><description>The Proving Grounds: Tutorial Map</description></item>
        /// <item><term>4</term><description>Twisted Treeline: Original Version</description></item>
        /// <item><term>8</term><description>The Crystal Scar: Dominion Map</description></item>
        /// <item><term>10</term><description>Twisted Treeline: Current Version</description></item>
        /// <item><term>12</term><description>Howling Abyss: ARAM Map</description></item>
        /// </list>
        /// </summary>
        [JsonProperty("mapId")]
        [JsonConverter(typeof(MapTypeConverter))]
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
        /// <list type="table">
        /// <listheader><description>Possible values:</description></listheader>
        /// <item><term>NONE</term><description>Custom games</description></item>
        /// <item><term>NORMAL</term><description>Summoner's Rift unranked games</description></item>
        /// <item><term>NORMAL_3x3</term><description>Twisted Treeline unranked games</description></item>
        /// <item><term>ODIN_UNRANKED</term><description>Dominion/Crystal Scar games</description></item>
        /// <item><term>ARAM_UNRANKED_5x5</term><description>ARAM / Howling Abyss games</description></item>
        /// <item><term>BOT</term><description>Summoner's Rift and Crystal Scar games played against AI</description></item>
        /// <item><term>BOT_3x3</term><description>Twisted Treeline games played against AI</description></item>
        /// <item><term>RANKED_SOLO_5x5</term><description>Summoner's Rift ranked solo queue games</description></item>
        /// <item><term>RANKED_TEAM_3x3</term><description>Twisted Treeline ranked team games</description></item>
        /// <item><term>RANKED_TEAM_5x5</term><description>Summoner's Rift ranked team games</description></item>
        /// <item><term>ONEFORALL_5x5</term><description>One for All games</description></item>
        /// <item><term>FIRSTBLOOD_1x1</term><description>Snowdown Showdown 1x1 games</description></item>
        /// <item><term>FIRSTBLOOD_2x2</term><description>Snowdown Showdown 2x2 games</description></item>
        /// <item><term>SR_6x6</term><description>Hexakill games</description></item>
        /// <item><term>CAP_5x5</term><description>Team Builder games</description></item>
        /// <item><term>URF</term><description>Ultra Rapid Fire games</description></item>
        /// <item><term>URF_BOT</term><description>Ultra Rapid Fire games played against AI</description></item>
        /// </list>
        /// </summary>
        [JsonProperty("subType")]
        [JsonConverter(typeof(GameSubTypeConverter))]
        public GameSubType SubType { get; set; }

        /// <summary>
        /// Team ID associated with game.
        /// <para>Blue = 100</para>
        /// <para>Purple = 200</para>
        /// </summary>
        [JsonProperty("teamId")]
        public int TeamId { get; set; }
    }
}
