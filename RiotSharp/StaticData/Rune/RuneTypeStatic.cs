using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RiotSharp
{
    /// <summary>
    /// Class representing a rune type (Static API).
    /// </summary>
    [Serializable]
    public class RuneTypeStatic
    {
        internal RuneTypeStatic() { }

        /// <summary>
        /// Boolean indicating whether this is a rune.
        /// </summary>
        [JsonProperty("isrune")]
        public bool IsRune { get; set; }

        /// <summary>
        /// Rune tier.
        /// </summary>
        [JsonProperty("tier")]
        public string Tier { get; set; }

        /// <summary>
        /// Rune type.
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }
    }
}
