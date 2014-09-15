using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace RiotSharp.MatchEndpoint
{
    /// <summary>
    /// Details about a match (Match API).
    /// </summary>
    [Serializable]
    public class MatchDetail : MatchSummary
    {
        internal MatchDetail() : base() { }

        /// <summary>
        /// Team information.
        /// </summary>
        [JsonProperty("teams")]
        public List<Team> Teams { get; set; }

        /// <summary>
        /// Match timeline data. Not included by default.
        /// </summary>
        [JsonProperty("timeline")]
        public Timeline Timeline { get; set; }
    }
}
