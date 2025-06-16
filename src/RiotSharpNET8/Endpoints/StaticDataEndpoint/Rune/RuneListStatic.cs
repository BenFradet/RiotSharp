using System.Text.Json.Serialization;

namespace RiotSharpNET8.Endpoints.StaticDataEndpoint.Rune
{
    /// <summary>
    /// Class representing a list of runes (Static API).
    /// </summary>
    public class RuneListStatic
    {
        /// <summary>
        /// Map of runes indexed by their id.
        /// </summary>
        [JsonPropertyName("data")]
        public Dictionary<int, RuneStatic> Runes { get; set; }

        /// <summary>
        /// API type (rune).
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; }

        /// <summary>
        /// Version of the API.
        /// </summary>
        [JsonPropertyName("version")]
        public string Version { get; set; }
    }
}
