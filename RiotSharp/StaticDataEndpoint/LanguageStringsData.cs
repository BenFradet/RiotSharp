using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace RiotSharp.StaticDataEndpoint
{
    /// <summary>
    /// Class representing data returned by the language strings endpoint (Static API).
    /// </summary>
    [Serializable]
    public class LanguageStringsData
    {
        internal LanguageStringsData() { }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }

        [JsonProperty("data")]
        public Dictionary<String, String> Data { get; set; }
    }
}
