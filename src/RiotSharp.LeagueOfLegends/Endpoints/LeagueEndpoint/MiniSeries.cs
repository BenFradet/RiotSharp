using System.Text.Json.Serialization;
using RiotSharp.LeagueOfLegends.Endpoints.LeagueEndpoint.Enums.Converters;

namespace RiotSharp.LeagueOfLegends.Endpoints.LeagueEndpoint
{
    /// <summary>
    /// LeaguePosition has entered a MiniSeries (League API).
    /// </summary>
    public class MiniSeries
    {
        /// <summary>
        /// Number of current losses in the mini series.
        /// </summary>
        [JsonPropertyName("losses")]
        public int Losses { get; set; }

        /// <summary>
        /// String showing the current, sequential mini series progress where 'W' represents a win, 'L' represents a
        /// loss, and 'N' represents a game that hasn't been played yet.
        /// </summary>
        [JsonPropertyName("progress")]
        [JsonConverter(typeof(ProgressConverter))]
        public char[] Progress { get; set; }

        /// <summary>
        /// Number of wins required for promotion.
        /// </summary>
        [JsonPropertyName("target")]
        public int Target { get; set; }

        /// <summary>
        /// Number of current wins in the mini series.
        /// </summary>
        [JsonPropertyName("wins")]
        public int Wins { get; set; }
    }
}
