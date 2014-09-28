// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MasteryPages.cs" company="">
//
// </copyright>
// <summary>
//   The mastery pages.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;

using Newtonsoft.Json;

namespace RiotSharp.SummonerEndpoint
{
    /// <summary>
    /// The mastery pages.
    /// </summary>
    class MasteryPages
    {
        /// <summary>
        /// List of MasteryPages.
        /// </summary>
        [JsonProperty("pages")]
        public List<MasteryPage> Pages { get; set; }

        /// <summary>
        /// Summoner ID to wich the pages belong.
        /// </summary>
        [JsonProperty("summonerId")]
        public long SummonerId { get; set; }
    }
}