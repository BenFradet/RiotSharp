using System.Text.Json.Serialization;

namespace RiotSharpNET8.Endpoints.StaticDataEndpoint
{
    /// <summary>
    /// Class representing various information about a summoner spell (Static API).
    /// </summary>
    public class SpellVarsStatic
    {
        internal SpellVarsStatic() { }

        /// <summary>
        /// Coeff for this summoner spell for the summoner's level.
        /// </summary>
        [JsonPropertyName("coeff")]
        public object Coeff { get; set; }

        /// <summary>
        /// Seems to always be equal to + when it is present.
        /// </summary>
        [JsonPropertyName("dyn")]
        public string Dyn { get; set; }

        /// <summary>
        /// Key.
        /// </summary>
        [JsonPropertyName("key")]
        public string Key { get; set; }

        /// <summary>
        /// Link.
        /// </summary>
        [JsonPropertyName("link")]
        public string Link { get; set; }

        /// <summary>
        /// Ranks with.
        /// </summary>
        [JsonPropertyName("ranksWith")]
        public string RanksWith { get; set; }
    }
}
