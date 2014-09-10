using System;
using Newtonsoft.Json;

namespace RiotSharp.LeagueEndpoint
{
    /// <summary>
    /// LeagueEntry has entered a MiniSeries (League API).
    /// </summary>
    [Serializable]
    public class MiniSeries
    {
        internal MiniSeries() { }

        /// <summary>
        /// Number of current losses in the mini series.
        /// </summary>
        [JsonProperty("losses")]
        public int Losses { get; set; }

        /// <summary>
        /// String showing the current, sequential mini series progress where 'W' represents a win, 'L' represents a
        /// loss, and 'N' represents a game that hasn't been played yet.
        /// </summary>
        [JsonProperty("progress")]
        [JsonConverter(typeof(CharArrayConverter))]
        public char[] Progress { get; set; }

        /// <summary>
        /// Number of wins required for promotion.
        /// </summary>
        [JsonProperty("target")]
        public int Target { get; set; }

        /// <summary>
        /// Number of current wins in the mini series.
        /// </summary>
        [JsonProperty("wins")]
        public int Wins { get; set; }
    }
}
