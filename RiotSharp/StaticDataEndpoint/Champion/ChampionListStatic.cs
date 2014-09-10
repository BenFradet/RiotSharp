using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace RiotSharp.StaticDataEndpoint
{
    /// <summary>
    /// Class representing a list of champions (Static API).
    /// </summary>
    [Serializable]
    public class ChampionListStatic
    {
        internal ChampionListStatic() { }

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
