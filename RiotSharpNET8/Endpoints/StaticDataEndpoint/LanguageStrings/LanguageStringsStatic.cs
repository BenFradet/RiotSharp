using System.Text.Json.Serialization;

namespace RiotSharpNET8.Endpoints.StaticDataEndpoint.LanguageStrings
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
        [JsonPropertyName("type")]
        public string Type { get; set; }

        /// <summary>
        /// Version of the dragon API.
        /// </summary>
        [JsonPropertyName("version")]
        public string Version { get; set; }

        /// <summary>
        /// Translated strings.
        /// </summary>
        [JsonPropertyName("data")]
        public Dictionary<String, String> Data { get; set; }
    }
}
