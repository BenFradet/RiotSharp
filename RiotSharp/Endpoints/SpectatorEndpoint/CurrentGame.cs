using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using RiotSharp.Misc;
using RiotSharp.Misc.Converters;

namespace RiotSharp.Endpoints.SpectatorEndpoint
{
    /// <summary>
    /// Class representing a CurrentGame in the API.
    /// </summary>
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
        /// </summary>
        [JsonProperty("gameMode")]
        public string GameMode { get; set; }

        /// <summary>
        /// The queue type
        /// </summary>
        [JsonProperty("gameQueueConfigId")]
        public string GameQueueType { get; set; }

        /// <summary>
        /// The game start time
        /// </summary>
        [JsonProperty("gameStartTime")]
        [JsonConverter(typeof(DateTimeConverterFromLong))]
        public DateTime GameStartTime { get; set; }

        /// <summary>
        /// Game type.
        /// </summary>
        [JsonProperty("gameType")]
        public GameType GameType { get; set; }

        /// <summary>
        /// Map type.
        /// </summary>
        [JsonProperty("mapId")]
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
        public Platform Platform { get; set; }
    }
}
