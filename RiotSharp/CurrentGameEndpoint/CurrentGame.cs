using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using RiotSharp.CurrentGameEndpoint.Converters;
using RiotSharp.Misc;

namespace RiotSharp.CurrentGameEndpoint
{
    /// <summary>
    /// Class representing a CurrentGame in the API.
    /// </summary>
    [Serializable]
    public class CurrentGame
    {
        internal CurrentGame() { }

        /// <summary>
        /// Banned champion information
        /// </summary>
        [JsonProperty("bannedChampions")]
        public List<BannedChampion> BannedChampions { get; set; }

        /// <summary>
        /// The ID of the game
        /// </summary>
        [JsonProperty("gameId")]
        public long GameId { get; set; }

        /// <summary>
        /// The amount of time in seconds that has passed since the game started
        /// </summary>
        [JsonProperty("gameLength")]
        public long GameLength { get; set; }

        /// <summary>
        /// Game mode.
        /// <list type="table">
        /// <listheader><description>Legal values:</description></listheader>
        /// <item><term>CLASSIC</term><description>Classic Summoner's Rift and Twisted Treeline games</description></item>
        /// <item><term>ODIN</term><description>Dominion/Crystal Scar games</description></item>
        /// <item><term>ARAM</term><description>ARAM games</description></item>
        /// <item><term>TUTORIAL</term><description>Tutorial games</description></item>
        /// <item><term>ONEFORALL</term><description>One for All games</description></item>
        /// <item><term>FIRSTBLOOD</term><description>Snowdown Showdown games</description></item>
        /// <item><term>KINGPORO</term><description>Legend of the Poro King games</description></item>
        /// </list>
        /// </summary>
        [JsonProperty("gameMode")]
        [JsonConverter(typeof(GameModeConverter))]
        public GameMode GameMode { get; set; }

        /// <summary>
        /// The queue type
        /// </summary>
        [JsonProperty("gameQueueConfigId")]
        [JsonConverter(typeof(GameQueueTypeConverter))]
        public GameQueueType GameQueueType { get; set; }

        /// <summary>
        /// The game start time
        /// </summary>
        [JsonProperty("gameStartTime")]
        [JsonConverter(typeof(DateTimeConverterFromLong))]
        public DateTime GameStartTime { get; set; }

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
        /// The ID of the map
        /// /// <list type="table">
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
        /// The observer information
        /// </summary>
        [JsonProperty("observers")]
        public Observer Observers { get; set; }

        /// <summary>
        /// The participant information
        /// </summary>
        [JsonProperty("participants")]
        public List<Participant> Participants { get; set; }

        /// <summary>
        /// The ID of the platform on which the game is being played
        /// </summary>
        [JsonProperty("platformId")]
        [JsonConverter(typeof(PlatformConverter))]
        public Platform Platform { get; set; }

    }
}
