using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RiotSharp
{
    /// <summary>
    /// Class representing a rune if an item is a rune (Static API).
    /// </summary>
    public class ItemRuneStatic
    {
        internal ItemRuneStatic() { }

        /// <summary>
        /// Whether this item is a rune or not.
        /// </summary>
        [JsonProperty("isRune")]
        public bool IsRune { get; set; }

        /// <summary>
        /// Tier of the rune.
        /// </summary>
        [JsonProperty("tier")]
        public int Tier { get; set; }

        /// <summary>
        /// Type of the rune.
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }
    }
}
