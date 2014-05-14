using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RiotSharp
{
    /// <summary>
    /// LeagueItem has entered a MiniSeries (League API).
    /// </summary>
    [Obsolete("The league api v2.3 is deprecated, please use MiniSeries instead.")]
    [Serializable]
    public class MiniSeriesV23
    {
        internal MiniSeriesV23() { }

        /// <summary>
        /// Number of losses.
        /// </summary>
        [JsonProperty("losses")]
        public int Losses { get; set; }

        /// <summary>
        /// Array representing the progress in the MiniSeries L for a loss, W for a win, N for not played (I guess).
        /// </summary>
        [JsonProperty("progress")]
        [JsonConverter(typeof(CharArrayConverter))]
        public char[] Progress { get; set; }

        /// <summary>
        /// Number of wins required (I guess).
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
        /// Number of wins.
        /// </summary>
        [JsonProperty("wins")]
        public int Wins { get; set; }
    }
}
