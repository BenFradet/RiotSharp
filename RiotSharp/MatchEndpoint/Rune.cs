// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Rune.cs" company="">
//
// </copyright>
// <summary>
//   Class representing a rune of a participant (Match API).
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;

using Newtonsoft.Json;

namespace RiotSharp.MatchEndpoint
{
    /// <summary>
    /// Class representing a rune of a participant (Match API).
    /// </summary>
    [Serializable]
    public class Rune
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Rune"/> class.
        /// </summary>
        internal Rune() { }

        /// <summary>
        /// Rune rank.
        /// </summary>
        [JsonProperty("rank")]
        public long Rank { get; set; }

        /// <summary>
        /// Rune ID.
        /// </summary>
        [JsonProperty("runeId")]
        public long RuneId { get; set; }
    }
}
