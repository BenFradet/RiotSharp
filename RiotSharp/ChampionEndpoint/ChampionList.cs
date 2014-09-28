// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ChampionList.cs" company="">
//
// </copyright>
// <summary>
//   The champion list.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;

using Newtonsoft.Json;

namespace RiotSharp.ChampionEndpoint
{
    /// <summary>
    /// The champion list.
    /// </summary>
    class ChampionList
    {
        /// <summary>
        /// List of Champions.
        /// </summary>
        [JsonProperty("champions")]
        public List<Champion> Champions { get; set; }
    }
}
