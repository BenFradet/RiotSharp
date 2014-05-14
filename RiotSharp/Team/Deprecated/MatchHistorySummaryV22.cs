using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RiotSharp
{
    /// <summary>
    /// Summary of the match history of the team (Team API).
    /// </summary>
    [Obsolete("The team api v2.2 is deprecated, please use MatchHistorySummary instead.")]
    [Serializable]
    public class MatchHistorySummaryV22
    {
        internal MatchHistorySummaryV22() { }

        /// <summary>
        /// Number of assists.
        /// </summary>
        [JsonProperty("assists")]
        public int Assists { get; set; }

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
