using System.Text.Json.Serialization;
using RiotSharpNET8.Misc;
using RiotSharpNET8.Misc.Converters;

namespace RiotSharpNET8.Endpoints.SpectatorEndpoint
{
    /// <summary>
    /// Class representing a CurrentGameInfo in the API.
    /// </summary>
    public class CurrentGame
    {
        /// <summary>
        /// Banned champion information
        /// </summary>
        [JsonPropertyName("bannedChampions")]
        public List<BannedChampion> BannedChampions { get; set; }

        /// <summary>
        /// The ID of the game
        /// </summary>
        [JsonPropertyName("gameId")]
        public long GameId { get; set; }

        /// <summary>
        /// The amount of time in seconds that has passed since the game started
        /// </summary>
        [JsonPropertyName("gameLength")]
        [JsonConverter(typeof(TimeSpanConverterFromSeconds))]
        public TimeSpan GameLength { get; set; }

        /// <summary>
        /// Game mode.
        /// </summary>
        [JsonPropertyName("gameMode")]
        public string GameMode { get; set; }

        /// <summary>
        /// The queue type
        /// </summary>
        [JsonPropertyName("gameQueueConfigId")]
        public string GameQueueType { get; set; }

        /// <summary>
        /// The game start time
        /// </summary>
        [JsonPropertyName("gameStartTime")]
        [JsonConverter(typeof(DateTimeConverterFromLong))]
        public DateTime GameStartTime { get; set; }

        /// <summary>
        /// Game type.
        /// </summary>
        [JsonPropertyName("gameType")]
        public GameType GameType { get; set; }

        /// <summary>
        /// Map type.
        /// </summary>
        [JsonPropertyName("mapId")]
        public MapType MapType { get; set; }

        /// <summary>
        /// The observer information
        /// </summary>
        [JsonPropertyName("observers")]
        public Observer Observers { get; set; }

        /// <summary>
        /// The participant information
        /// </summary>
        [JsonPropertyName("participants")]
        public List<CurrentGameParticipant> Participants { get; set; }

        /// <summary>
        /// The ID of the platform on which the game is being played
        /// </summary>
        [JsonPropertyName("platformId")]
        public Platform Platform { get; set; }
    }
}
