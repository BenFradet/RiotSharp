using System;
using Newtonsoft.Json;

namespace RiotSharp.TeamEndpoint
{
    /// <summary>
    /// Summary of the match history of the team (Team API).
    /// </summary>
    [Serializable]
    public class MatchHistorySummary
    {
        internal MatchHistorySummary() { }

        /// <summary>
        /// Number of assists.
        /// </summary>
        [JsonProperty("assists")]
        public int Assists { get; set; }

        /// <summary>
        /// Date when the match took place.
        /// </summary>
        [JsonProperty("date")]
        [JsonConverter(typeof(DateTimeConverterFromLong))]
        public DateTime Date { get; set; }

        /// <summary>
        /// Number of deaths overall.
        /// </summary>
        [JsonProperty("deaths")]
        public int Deaths { get; set; }

        /// <summary>
        /// Game id.
        /// </summary>
        [JsonProperty("gameId")]
        public long GameId { get; set; }

        /// <summary>
        /// Game mode.
        /// </summary>
        [JsonProperty("gameMode")]
        [JsonConverter(typeof(GameModeConverter))]
        public GameMode GameMode { get; set; }

        /// <summary>
        /// Boolean specifying if the match was invalid.
        /// </summary>
        [JsonProperty("invalid")]
        public bool Invalid { get; set; }

        /// <summary>
        /// Number of kills.
        /// </summary>
        [JsonProperty("kills")]
        public int Kills { get; set; }

        /// <summary>
        /// Id of the map.
        /// </summary>
        [JsonProperty("mapId")]
        public int MapId { get; set; }

        /// <summary>
        /// Number of kills for the opposing team.
        /// </summary>
        [JsonProperty("opposingTeamKills")]
        public int OpposingTeamKills { get; set; }

        /// <summary>
        /// Name of the opposite team.
        /// </summary>
        [JsonProperty("opposingTeamName")]
        public string OpposingTeamName { get; set; }

        /// <summary>
        /// Match won if true, lost if false.
        /// </summary>
        [JsonProperty("win")]
        public bool Win { get; set; }
    }
}
