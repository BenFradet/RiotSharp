// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BannedChampion.cs" company="">
//   
// </copyright>
// <summary>
//   Class representing a banned champion (Game API).
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;

using Newtonsoft.Json;

namespace RiotSharp.MatchEndpoint
{
    /// <summary>
    /// Class representing a banned champion (Game API).
    /// </summary>
    [Serializable]
    public class BannedChampion
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BannedChampion"/> class.
        /// </summary>
        internal BannedChampion() { }

        /// <summary>
        /// Banned champion ID.
        /// </summary>
        [JsonProperty("championId")]
        public int ChampionId { get; set; }

        /// <summary>
        /// Turn during which the champion was banned.
        /// </summary>
        [JsonProperty("pickTurn")]
        public int PickTurn { get; set; }
    }
}
