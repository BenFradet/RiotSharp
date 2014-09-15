using System;
using Newtonsoft.Json;

namespace RiotSharp.StaticDataEndpoint
{
    /// <summary>
    /// Class representing various information about a summoner spell (Static API).
    /// </summary>
    [Serializable]
    public class SpellVarsStatic
    {
        internal SpellVarsStatic() { }

        /// <summary>
        /// Coeff for this summoner spell for the summoner's level.
        /// </summary>
        [JsonProperty("coeff")]
        public object Coeff { get; set; }

        /// <summary>
        /// Seems to always be equal to + when it is present.
        /// </summary>
        [JsonProperty("dyn")]
        public string Dyn { get; set; }

        /// <summary>
        /// Key.
        /// </summary>
        [JsonProperty("key")]
        public string Key { get; set; }

        /// <summary>
        /// Link.
        /// </summary>
        [JsonProperty("link")]
        public string Link { get; set; }

        /// <summary>
        /// Ranks with.
        /// </summary>
        [JsonProperty("ranksWith")]
        public string RanksWith { get; set; }
    }
}
