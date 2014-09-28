// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MatchDetail.cs" company="">
//   
// </copyright>
// <summary>
//   Details about a match (Match API).
// </summary>
// --------------------------------------------------------------------------------------------------------------------

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
        /// <summary>
        /// Initializes a new instance of the <see cref="MatchDetail"/> class.
        /// </summary>
        internal MatchDetail()
        {
        }

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
