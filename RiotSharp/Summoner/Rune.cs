using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        /// Rune tier.
        /// </summary>
        [JsonProperty("tier")]
        public int Tier { get; set; }
    }
}
