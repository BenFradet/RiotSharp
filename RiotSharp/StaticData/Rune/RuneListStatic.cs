using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RiotSharp
{
    /// <summary>
    /// Class representing a list of runes (Static API).
    /// </summary>
    public class RuneListStatic
    {
        internal RuneListStatic() { }

        /// <summary>
        /// Basic data (empty object so far).
        /// </summary>
        [JsonProperty("basic")]
        public object Basic { get; set; }

        /// <summary>
        /// Map of runes indexed by their id.
        /// </summary>
        [JsonProperty("data")]
        public Dictionary<int, RuneStatic> Runes { get; set; }

        /// <summary>
        /// API type (rune).
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// Version of the API.
        /// </summary>
        [JsonProperty("version")]
        public string Version { get; set; }
    }
}
