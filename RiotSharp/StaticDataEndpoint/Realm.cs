using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace RiotSharp.StaticDataEndpoint
{
    /// <summary>
    /// Class representing a realm (Static API).
    /// </summary>
    [Serializable]
    public class Realm
    {
        internal Realm() { }

        /// <summary>
        /// The base CDN url.
        /// </summary>
        [JsonProperty("cdn")]
        public string Cdn { get; set; }

        /// <summary>
        /// Latest changed version of Dragon Magic's css file.
        /// </summary>
        [JsonProperty("css")]
        public string Css { get; set; }

        /// <summary>
        /// Latest changed version of Dragon Magic.
        /// </summary>
        [JsonProperty("dd")]
        public string Dd { get; set; }

        /// <summary>
        /// Default language for this realm.
        /// </summary>
        [JsonProperty("l")]
        public string L { get; set; }

        /// <summary>
        /// Legacy script mode for IE6 or older.
        /// </summary>
        [JsonProperty("lg")]
        public string Lg { get; set; }

        /// <summary>
        /// Latest changed version for each data type listed.
        /// </summary>
        [JsonProperty("n")]
        public Dictionary<string, string> N { get; set; }

        /// <summary>
        /// Special behavior number identifying the largest profileicon id that can be used under 500.
        /// Any profileicon that is requested between this number and 500 should be mapped to 0.
        /// </summary>
        [JsonProperty("profileiconmax")]
        public int ProfileIconMax { get; set; }

        /// <summary>
        /// Additional api data drawn from other sources that may be related to data dragon functionality.
        /// </summary>
        [JsonProperty("store")]
        public string Store { get; set; }

        /// <summary>
        /// Current version of this file for this realm.
        /// </summary>
        [JsonProperty("v")]
        public string V { get; set; }
    }
}
