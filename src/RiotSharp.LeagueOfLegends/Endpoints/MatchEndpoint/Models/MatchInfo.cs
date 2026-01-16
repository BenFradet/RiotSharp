using System.Text.Json.Serialization;
using RiotSharp.Core.Misc;
using RiotSharp.Core.Misc.Converters;
using RiotSharp.LeagueOfLegends.Endpoints.MatchEndpoint.Enums;
using RiotSharp.LeagueOfLegends.Misc;

namespace RiotSharp.LeagueOfLegends.Endpoints.MatchEndpoint.Models
{
    /// <summary>
    /// Info of a match (Match API).
    /// </summary>
    public class MatchInfo
    {
        /// <summary>
        /// Refer to indicate if the game ended in termination.
        /// </summary>
        [JsonPropertyName("endOfGameResult")]
        public string EndOfGameResult { get; set; }

        /// <summary>
        /// The date time of the game creation.
        /// From doc: 	Unix timestamp for when the game is created on the game server (i.e., the loading screen).
        /// </summary>
        [JsonPropertyName("gameCreation")]
        [JsonConverter(typeof(DateTimeConverterFromLong))]
        public DateTime GameCreation { get; set; }

        /// <summary>
        /// The game duration. This field is only valid if the game is post patch 11.20!
        /// From doc: Prior to patch 11.20, this field returns the game length in milliseconds calculated from gameEndTimestamp - gameStartTimestamp. 
        /// Post patch 11.20, this field returns the max timePlayed of any participant in the game in seconds, 
        /// which makes the behavior of this field consistent with that of match-v4. 
        /// The best way to handling the change in this field is to treat the value as milliseconds if the gameEndTimestamp field 
        /// isn't in the response and to treat the value as seconds if gameEndTimestamp is in the response.
        /// </summary>
        [JsonPropertyName("gameDuration")]
        [JsonConverter(typeof(TimeSpanConverterFromSeconds))]
        public TimeSpan GameDuration { get; set; }

        /// <summary>
        /// The game duration.
        /// Unix timestamp for when match ends on the game server.
        /// This timestamp can occasionally be significantly longer than when the match "ends".
        /// This field was added to match-v5 in patch 11.20 on Oct 5th, 2021.
        /// </summary>
        [JsonPropertyName("gameEndTimestamp")]
        [JsonConverter(typeof(DateTimeConverterFromLong))]
        public DateTime GameEndTimestamp { get; set; }

        /// <summary>
        /// Game ID.
        /// </summary>
        [JsonPropertyName("gameId")]
        public long GameId { get; set; }

        /// <summary>
        /// The game mode.
        /// </summary>
        [JsonPropertyName("gameMode")]
        public GameMode GameMode { get; set; }

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
        public GameType GameType { get; set; }

        /// <summary>
        /// The game version.
        /// </summary>
        [JsonPropertyName("gameVersion")]
        public string GameVersion { get; set; }

        /// <summary>
        /// The map ID.
        /// </summary>
        [JsonPropertyName("MapId")]
        public MapType Map { get; set; }

        /// <summary>
        /// The participants.
        /// </summary>
        [JsonPropertyName("participants")]
        public List<Participant> Participants { get; set; }

        /// <summary>
        /// Platform the game was played on.
        /// </summary>
        [JsonPropertyName("platformId")]
        public Platform Platform { get; set; }

        /// <summary>
        /// Specifies the Queue.
        /// </summary>
        [JsonPropertyName("queueId")]
        public Queue Queue { get; set; }

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
