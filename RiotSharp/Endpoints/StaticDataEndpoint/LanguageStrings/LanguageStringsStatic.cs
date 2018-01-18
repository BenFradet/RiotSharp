﻿using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace RiotSharp.Endpoints.StaticDataEndpoint.LanguageStrings
{
    /// <summary>
    /// Class representing data returned by the language strings endpoint (Static API).
    /// </summary>
    public class LanguageStringsStatic
    {
        internal LanguageStringsStatic() { }

        /// <summary>
        /// Type of data returned.
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// Version of the dragon API.
        /// </summary>
        [JsonProperty("version")]
        public string Version { get; set; }

        /// <summary>
        /// Translated strings.
        /// </summary>
        [JsonProperty("data")]
        public Dictionary<String, String> Data { get; set; }
    }
}
