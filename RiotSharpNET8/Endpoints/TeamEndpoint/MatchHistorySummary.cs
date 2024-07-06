using System.Text.Json.Serialization;
using RiotSharpNET8.Misc.Converters;

namespace RiotSharpNET8.Endpoints.TeamEndpoint
{
    /// <summary>
    /// Summary of the match history of the team (Team API).
    /// </summary>
    public class MatchHistorySummary
    {
        internal MatchHistorySummary() { }

        /// <summary>
        /// Number of assists.
        /// </summary>
        [JsonPropertyName("assists")]
        public int Assists { get; set; }

        /// <summary>
        /// Date when the match took place.
        /// </summary>
        [JsonPropertyName("date")]
        [JsonConverter(typeof(DateTimeConverterFromLong))]
        public DateTime Date { get; set; }

        /// <summary>
        /// Number of deaths overall.
        /// </summary>
        [JsonPropertyName("deaths")]
        public int Deaths { get; set; }

        /// <summary>
        /// Game id.
        /// </summary>
        [JsonPropertyName("gameId")]
        public long GameId { get; set; }

        /// <summary>
        /// Game mode.
        /// </summary>
        [JsonPropertyName("gameMode")]
        public string GameMode { get; set; }

        /// <summary>
        /// Boolean specifying if the match was invalid.
        /// </summary>
        [JsonPropertyName("invalid")]
        public bool Invalid { get; set; }

        /// <summary>
        /// Number of kills.
        /// </summary>
        [JsonPropertyName("kills")]
        public int Kills { get; set; }

        /// <summary>
        /// Id of the map.
        /// </summary>
        [JsonPropertyName("mapId")]
        public int MapId { get; set; }

        /// <summary>
        /// Number of kills for the opposing team.
        /// </summary>
        [JsonPropertyName("opposingTeamKills")]
        public int OpposingTeamKills { get; set; }

        /// <summary>
        /// Name of the opposite team.
        /// </summary>
        [JsonPropertyName("opposingTeamName")]
        public string OpposingTeamName { get; set; }

        /// <summary>
        /// Match won if true, lost if false.
        /// </summary>
        [JsonPropertyName("win")]
        public bool Win { get; set; }
    }
}
