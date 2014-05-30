using System;
using Newtonsoft.Json;

namespace RiotSharp
{
    /// <summary>
    /// Rune (Summoner API).
    /// </summary>
    [Serializable]
    public class Rune
    {
        internal Rune() { }

        /// <summary>
        /// Rune description.
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// Rune ID.
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// Rune name.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// <para>Rune tier.</para>
        /// <para>Valid: 1 - 3</para>
        /// </summary>
        [JsonProperty("tier")]
        public int Tier { get; set; }
    }
}
