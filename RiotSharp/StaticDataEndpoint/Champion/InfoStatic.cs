using System;
using Newtonsoft.Json;

namespace RiotSharp.StaticDataEndpoint
{
    /// <summary>
    /// Basic information for a champion (Static API).
    /// </summary>
    [Serializable]
    public class InfoStatic
    {
        internal InfoStatic() { }

        /// <summary>
        /// Number between 1 and 10 representing the attack power of a champion.
        /// </summary>
        [JsonProperty("attack")]
        public int Attack { get; set; }

        /// <summary>
        /// Number between 1 and 10 representing the defense power of a champion.
        /// </summary>
        [JsonProperty("defense")]
        public int Defense { get; set; }

        /// <summary>
        /// Number between 1 and 10 representing the difficulty of a champion.
        /// </summary>
        [JsonProperty("difficulty")]
        public int Difficulty { get; set; }

        /// <summary>
        /// Number between 1 and 10 representing the magic power of a champion.
        /// </summary>
        [JsonProperty("magic")]
        public int Magic { get; set; }
    }
}
