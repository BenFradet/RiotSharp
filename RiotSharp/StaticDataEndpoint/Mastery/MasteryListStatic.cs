using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace RiotSharp.StaticDataEndpoint
{
    /// <summary>
    /// Class representing a list of masteries (Static API).
    /// </summary>
    [Serializable]
    public class MasteryListStatic
    {
        internal MasteryListStatic() { }

        /// <summary>
        /// Map of masteries indexed by their id.
        /// </summary>
        [JsonProperty("data")]
        public Dictionary<int, MasteryStatic> Masteries { get; set; }

        /// <summary>
        /// Tree of masteries.
        /// </summary>
        [JsonProperty("tree")]
        public MasteryTreeStatic Tree { get; set; }

        /// <summary>
        /// API type (mastery).
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
