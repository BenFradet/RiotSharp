// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Mastery.cs" company="">
//
// </copyright>
// <summary>
//   Class representing a mastery of a participant (Match API).
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;

using Newtonsoft.Json;

namespace RiotSharp.MatchEndpoint
{
    /// <summary>
    /// Class representing a mastery of a participant (Match API).
    /// </summary>
    [Serializable]
    public class Mastery
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Mastery"/> class.
        /// </summary>
        internal Mastery() { }

        /// <summary>
        /// Mastery ID.
        /// </summary>
        [JsonProperty("masteryId")]
        public long MasteryId { get; set; }

        /// <summary>
        /// Mastery rank.
        /// </summary>
        [JsonProperty("rank")]
        public long Rank { get; set; }
    }
}
