using System.Text.Json.Serialization;

namespace RiotSharpNET8.Endpoints.TournamentEndpoint
{
    /// <summary>
    /// Details about a match (Match API).
    /// </summary>
    public class MatchDetail : MatchSummary
    {
        internal MatchDetail() { }

        /// <summary>
        /// Team information.
        /// </summary>
        [JsonPropertyName("teams")]
        public List<TeamStats> Teams { get; set; }

        /// <summary>
        /// Match timeline data. Not included by default.
        /// </summary>
        [JsonPropertyName("timeline")]
        public MatchTimeline Timeline { get; set; }
    }
}
