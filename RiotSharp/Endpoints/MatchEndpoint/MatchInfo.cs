using Newtonsoft.Json;
using RiotSharp.Misc.Converters;
using System;
using System.Collections.Generic;
using System.Text;

namespace RiotSharp.Endpoints.MatchEndpoint
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
        [JsonProperty("gameCreation")]
        [JsonConverter(typeof(DateTimeConverterFromLong))]
        public DateTime GameCreation { get; set; }

        /// <summary>
        /// The game duration.
        /// </summary>
        [JsonProperty("gameDuration")]
        [JsonConverter(typeof(TimeSpanConverterFromMilliseconds))]
        public TimeSpan GameDuration { get; set; }

        /// <summary>
        /// Game ID.
        /// </summary>
        [JsonProperty("gameId")]
        public long GameId { get; set; }

        /// <summary>
        /// The game mode.
        /// </summary>
        [JsonProperty("gameMode")]
        public string GameMode { get; set; }

        /// <summary>
        /// Name of the game.
        /// </summary>
        [JsonProperty("gameName")]
        public string GameName { get; set; }

        /// <summary>
        /// The date time of the game start.
        /// </summary>
        [JsonProperty("gameStartTimeStemp")]
        [JsonConverter(typeof(DateTimeConverterFromLong))]
        public DateTime GameStartTimeStemp { get; set; }

        /// <summary>
        /// The game type.
        /// </summary>
        [JsonProperty("gameType")]
        public string GameType { get; set; }

        /// <summary>
        /// The game version.
        /// </summary>
        [JsonProperty("gameVersion")]
        public string GameVersion { get; set; }

        /// <summary>
        /// The map ID.
        /// </summary>
        [JsonProperty("MapId")]
        public int MapId { get; set; }

        /// <summary>
        /// The participants.
        /// </summary>
        [JsonProperty("participants")]
        public List<Participant> Participants { get; set; }

        /// <summary>
        /// Platform Id.
        /// </summary>
        [JsonProperty("platformId")]
        public string PlatformId { get; set; }

        /// <summary>
        /// Specifies the Queue ID.
        /// </summary>
        [JsonProperty("queueId")]
        public int QueueId { get; set; }

        /// <summary>
        /// The teams.
        /// </summary>
        [JsonProperty("teams")]
        public List<TeamStats> Teams { get; set; }

        /// <summary>
        /// The tournament code of the game. Only present if applicable.
        /// </summary>
        [JsonProperty("tournamentCode")]
        public string TournamentCode { get; set; }
    }
}
