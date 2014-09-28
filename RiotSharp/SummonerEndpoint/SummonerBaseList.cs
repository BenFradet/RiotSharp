// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SummonerBaseList.cs" company="">
//
// </copyright>
// <summary>
//   The summoner base list.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;

using Newtonsoft.Json;

namespace RiotSharp.SummonerEndpoint
{
    /// <summary>
    /// The summoner base list.
    /// </summary>
    class SummonerBaseList
    {
        /// <summary>
        /// Gets or sets the summoners.
        /// </summary>
        [JsonProperty("summoners")]
        public List<SummonerBase> Summoners { get; set; }
    }
}
