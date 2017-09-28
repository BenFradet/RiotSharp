using Newtonsoft.Json;
using RiotSharp.Misc.Converters;
using System;
using System.Collections.Generic;
using System.Text;

namespace RiotSharp.MatchEndpoint
{
    public class Match
    {
        [JsonProperty("seasonId")]
        public int SeasonId { get; set; }

        [JsonProperty("queueId")]
        public int QueueId { get; set; }

        /// <summary>
        /// Equivalent to match id
        /// </summary>
        [JsonProperty("gameId")]
        public long GameId { get; set; }

        [JsonProperty("participantIdentities")]
        public List<ParticipantIdentity> ParticipantIdentities { get; set; }

        [JsonProperty("gameVersion")]
        public string GameVersion { get; set; }

        [JsonProperty("gameMode")]
        public string GameMode { get; set; }

        [JsonProperty("MapId")]
        public int MapId { get; set; }

        [JsonProperty("gameType")]
        public string GameType { get; set; }

        [JsonProperty("teams")]
        public List<TeamStats> Teams { get; set; }

        [JsonProperty("participants")]
        public List<Participant> Participants { get; set; } 

        [JsonProperty("gameDuration")]
        [JsonConverter(typeof(TimeSpanConverterFromMilliseconds))]
        public TimeSpan GameDuration { get; set; }

        [JsonProperty("gameCreation")]
        [JsonConverter(typeof(DateTimeConverterFromLong))]
        public DateTime GameCreation { get; set; }
    }
}
