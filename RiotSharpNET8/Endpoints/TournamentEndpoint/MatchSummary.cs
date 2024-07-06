using System.Text.Json.Serialization;
using RiotSharpNET8.Endpoints.MatchEndpoint.Enums;
using RiotSharpNET8.Misc;
using RiotSharpNET8.Misc.Converters;

namespace RiotSharpNET8.Endpoints.TournamentEndpoint
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
        [JsonPropertyName("mapId")]
        public MapType MapType { get; set; }

        /// <summary>
        /// Match creation time. Designates when the team select lobby is created and/or the match is made through
        /// match making, not when the game actually starts.
        /// </summary>
        [JsonPropertyName("matchCreation")]
        [JsonConverter(typeof(DateTimeConverterFromLong))]
        public DateTime MatchCreation { get; set; }

        /// <summary>
        /// Match duration.
        /// </summary>
        [JsonPropertyName("matchDuration")]
        [JsonConverter(typeof(TimeSpanConverterFromSeconds))]
        public TimeSpan MatchDuration { get; set; }

        /// <summary>
        /// Match ID.
        /// </summary>
        [JsonPropertyName("matchId")]
        public long MatchId { get; set; }

        /// <summary>
        /// Match mode.
        /// </summary>
        [JsonPropertyName("matchMode")]
        public string MatchMode { get; set; }

        /// <summary>
        /// Defines what GameType the match is eg. Custom, Matched, Tutorial.
        /// </summary>
        [JsonPropertyName("matchType")]
        public GameType MatchType { get; set; }

        /// <summary>
        /// Match version.
        /// </summary>
        [JsonPropertyName("matchVersion")]
        public string MatchVersion { get; set; }

        /// <summary>
        /// Participants identity information.
        /// </summary>
        [JsonPropertyName("participantIdentities")]
        public List<ParticipantIdentity> ParticipantIdentities { get; set; }

        /// <summary>
        /// Participants information
        /// </summary>
        [JsonPropertyName("participants")]
        public List<Participant> Participants { get; set; }

        /// <summary>
        /// Match queue type.
        /// </summary>
        [JsonPropertyName("queueType")]
        public string QueueType { get; set; }

        /// <summary>
        /// Region where the match was played.
        /// </summary>
        [JsonPropertyName("region")]
        public Region Region { get; set; }

        /// <summary>
        /// Season match was played.
        /// </summary>
        [JsonPropertyName("season")]
        public Season Season { get; set; }
    }
}
