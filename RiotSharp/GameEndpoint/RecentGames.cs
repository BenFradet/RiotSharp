// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RecentGames.cs" company="">
//
// </copyright>
// <summary>
//   The recent games.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;

using Newtonsoft.Json;

namespace RiotSharp.GameEndpoint
{
    /// <summary>
    /// The recent games.
    /// </summary>
    class RecentGames
    {
        /// <summary>
        /// A list of games for a summoner.
        /// </summary>
        [JsonProperty("games")]
        public List<Game> Games { get; set; }

        /// <summary>
        /// The summonerId assosiated with the games.
        /// </summary>
        [JsonProperty("summonerId")]
        public long SummonerId { get; set; }
    }
}
