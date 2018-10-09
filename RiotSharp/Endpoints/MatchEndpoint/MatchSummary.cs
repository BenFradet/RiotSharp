using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using RiotSharp.Endpoints.MatchEndpoint.Enums;
using RiotSharp.Misc;
using RiotSharp.Misc.Converters;

namespace RiotSharp.Endpoints.MatchEndpoint
{
    /// <summary>
    /// Summary of a match (Match API).
    /// </summary>
    public class MatchSummary
    {
        internal MatchSummary() { }

        /// <summary>
        /// Map type.
        /// </summary>
        [JsonProperty("mapId")]
        public MapType MapType { get; set; }

        /// <summary>
        /// Match creation time. Designates when the team select lobby is created and/or the match is made through
        /// match making, not when the game actually starts.
        /// </summary>
        [JsonProperty("matchCreation")]
        [JsonConverter(typeof(DateTimeConverterFromLong))]
        public DateTime MatchCreation { get; set; }

        /// <summary>
        /// Match duration.
        /// </summary>
        [JsonProperty("matchDuration")]
        [JsonConverter(typeof(TimeSpanConverterFromSeconds))]
        public TimeSpan MatchDuration { get; set; }

        /// <summary>
        /// Match ID.
        /// </summary>
        [JsonProperty("matchId")]
        public long MatchId { get; set; }

        /// <summary>
        /// Match mode.
        /// </summary>
        [JsonProperty("matchMode")]
        public string MatchMode { get; set; }

        /// <summary>
        /// Defines what GameType the match is eg. Custom, Matched, Tutorial.
        /// </summary>
        [JsonProperty("matchType")]
        public GameType MatchType { get; set; }

        /// <summary>
        /// Match version.
        /// </summary>
        [JsonProperty("matchVersion")]
        public string MatchVersion { get; set; }

        /// <summary>
        /// Participants identity information.
        /// </summary>
        [JsonProperty("participantIdentities")]
        public List<ParticipantIdentity> ParticipantIdentities { get; set; }

        /// <summary>
        /// Participants information
        /// </summary>
        [JsonProperty("participants")]
        public List<Participant> Participants { get; set; }

        /// <summary>
        /// Match queue type.
        /// </summary>
        [JsonProperty("queueType")]
        public string QueueType { get; set; }

        /// <summary>
        /// Region where the match was played.
        /// </summary>
        [JsonProperty("region")]
        public Region Region { get; set; }

        /// <summary>
        /// Season match was played.
        /// </summary>
        [JsonProperty("season")]
        public Season Season { get; set; }
    }
}
