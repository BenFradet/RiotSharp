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
