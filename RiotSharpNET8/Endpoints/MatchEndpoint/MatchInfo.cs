using System.Text.Json.Serialization;
using RiotSharpNET8.Misc.Converters;

namespace RiotSharpNET8.Endpoints.MatchEndpoint
{
    /// <summary>
    /// Info of a match (Match API).
    /// </summary>
    public class MatchInfo
    {
        internal MatchInfo() { }

        /// <summary>
        /// The date time of the game creation.
        /// </summary>
        [JsonPropertyName("gameCreation")]
        [JsonConverter(typeof(DateTimeConverterFromLong))]
        public DateTime GameCreation { get; set; }

        /// <summary>
        /// The game duration.
        /// </summary>
        [JsonPropertyName("gameDuration")]
        [JsonConverter(typeof(TimeSpanConverterFromMilliseconds))]
        public TimeSpan GameDuration { get; set; }

        /// <summary>
        /// The game duration.
        /// Unix timestamp for when match ends on the game server.
        /// This timestamp can occasionally be significantly longer than when the match "ends".
        /// This field was added to match-v5 in patch 11.20 on Oct 5th, 2021.
        /// </summary>
        [JsonPropertyName("gameEndTimestamp")]
        public long GameEndTimestamp { get; set; }

        /// <summary>
        /// Game ID.
        /// </summary>
        [JsonPropertyName("gameId")]
        public long GameId { get; set; }

        /// <summary>
        /// The game mode.
        /// </summary>
        [JsonPropertyName("gameMode")]
        public string GameMode { get; set; }

        /// <summary>
        /// Name of the game.
        /// </summary>
        [JsonPropertyName("gameName")]
        public string GameName { get; set; }

        /// <summary>
        /// The date time of the game start.
        /// </summary>
        [JsonPropertyName("gameStartTimeStemp")]
        [JsonConverter(typeof(DateTimeConverterFromLong))]
        public DateTime GameStartTimeStemp { get; set; }

        /// <summary>
        /// The game type.
        /// </summary>
        [JsonPropertyName("gameType")]
        public string GameType { get; set; }

        /// <summary>
        /// The game version.
        /// </summary>
        [JsonPropertyName("gameVersion")]
        public string GameVersion { get; set; }

        /// <summary>
        /// The map ID.
        /// </summary>
        [JsonPropertyName("MapId")]
        public int MapId { get; set; }

        /// <summary>
        /// The participants.
        /// </summary>
        [JsonPropertyName("participants")]
        public List<Participant> Participants { get; set; }

        /// <summary>
        /// Platform Id.
        /// </summary>
        [JsonPropertyName("platformId")]
        public string PlatformId { get; set; }

        /// <summary>
        /// Specifies the Queue ID.
        /// </summary>
        [JsonPropertyName("queueId")]
        public int QueueId { get; set; }

        /// <summary>
        /// The teams.
        /// </summary>
        [JsonPropertyName("teams")]
        public List<TeamStats> Teams { get; set; }

        /// <summary>
        /// The tournament code of the game. Only present if applicable.
        /// </summary>
        [JsonPropertyName("tournamentCode")]
        public string TournamentCode { get; set; }
    }
}
