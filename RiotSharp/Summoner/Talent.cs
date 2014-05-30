using System;
using Newtonsoft.Json;

namespace RiotSharp
{
    /// <summary>
    /// Class representing a Masterie (Talent) in the API.
    /// </summary>
    [Serializable]
    public class Talent
    {
        internal Talent() { }

        /// <summary>
        /// Talent id.
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// Talent name.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Talent rank.
        /// </summary>
        [JsonProperty("rank")]
        public int Rank { get; set; }
    }
}
