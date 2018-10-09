using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using RiotSharp.Misc.Converters;

namespace RiotSharp.Endpoints.MatchEndpoint
{
    /// <summary>
    /// Match class containing all properties to define a match.
    /// </summary>
    public class Match
    {
        /// <summary>
        /// The season ID.
        /// </summary>
        [JsonProperty("seasonId")]
        public int SeasonId { get; set; }

        /// <summary>
        /// Specifies the Queue ID.
        /// </summary>
        [JsonProperty("queueId")]
        public int QueueId { get; set; }

        /// <summary>
        /// Equivalent to match id
        /// </summary>
        [JsonProperty("gameId")]
        public long GameId { get; set; }

        /// <summary>
        /// The participants identities.
        /// </summary>
        [JsonProperty("participantIdentities")]
        public List<ParticipantIdentity> ParticipantIdentities { get; set; }

        /// <summary>
        /// The game version.
        /// </summary>
        [JsonProperty("gameVersion")]
        public string GameVersion { get; set; }

        /// <summary>
        /// The game mode.
        /// </summary>
        [JsonProperty("gameMode")]
        public string GameMode { get; set; }

        /// <summary>
        /// The map ID.
        /// </summary>
        [JsonProperty("MapId")]
        public int MapId { get; set; }

        /// <summary>
        /// The game type.
        /// </summary>
        [JsonProperty("gameType")]
        public string GameType { get; set; }

        /// <summary>
        /// The teams.
        /// </summary>
        [JsonProperty("teams")]
        public List<TeamStats> Teams { get; set; }

        /// <summary>
        /// The participants.
        /// </summary>
        [JsonProperty("participants")]
        public List<Participant> Participants { get; set; }

        /// <summary>
        /// The game duration.
        /// </summary>
        [JsonProperty("gameDuration")]
        [JsonConverter(typeof(TimeSpanConverterFromSeconds))]
        public TimeSpan GameDuration { get; set; }

        /// <summary>
        /// The date time of the game creation.
        /// </summary>
        [JsonProperty("gameCreation")]
        [JsonConverter(typeof(DateTimeConverterFromLong))]
        public DateTime GameCreation { get; set; }
    }
}
