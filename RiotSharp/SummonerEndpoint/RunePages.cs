// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RunePages.cs" company="">
//   
// </copyright>
// <summary>
//   The rune pages.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;

using Newtonsoft.Json;

namespace RiotSharp.SummonerEndpoint
{
    /// <summary>
    /// The rune pages.
    /// </summary>
    class RunePages
    {
        /// <summary>
        /// List of RunePages;
        /// </summary>
        [JsonProperty("pages")]
        public List<RunePage> Pages { get; set; }

        /// <summary>
        /// Summoner ID to wich the pages belong.
        /// </summary>
        [JsonProperty("summonerId")]
        public long SummonerId { get; set; }
    }
}