using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace RiotSharp
{
    /// <summary>
    /// Class representing a list of champions (Static API).
    /// </summary>
    public class ChampionListStatic
    {
        /// <summary>
        /// Map of champions indexed by their name.
        /// </summary>
        [JsonProperty("data")]
        public Dictionary<string, ChampionStatic> Champions { get; set; }

        /// <summary>
        /// Format of the data retrieved (always null afaik).
        /// </summary>
        [JsonProperty("format")]
        public string Format { get; set; }

        /// <summary>
        /// Map of the champions names indexed by their id.
        /// </summary>
        [JsonProperty("keys")]
        public Dictionary<int, string> Keys { get; set; }

        /// <summary>
        /// TAPI type (item).
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
