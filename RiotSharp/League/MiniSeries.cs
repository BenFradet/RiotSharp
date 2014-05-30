using System;
using Newtonsoft.Json;

namespace RiotSharp
{
    /// <summary>
    /// LeagueItem has entered a MiniSeries (League API).
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
        /// Array representing the progress in the MiniSeries L for a loss, W for a win, N for not played.
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
        /// Time left to play the MiniSeries.
        /// </summary>
        [JsonProperty("timeLeftToPlayMillis")]
        [JsonConverter(typeof(TimeSpanConverterFromMS))]
        public TimeSpan TimeLeftToPlayMillis { get; set; }

        /// <summary>
        /// umber of current wins in the mini series.
        /// </summary>
        [JsonProperty("wins")]
        public int Wins { get; set; }
    }
}
