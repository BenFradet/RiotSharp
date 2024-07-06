using System.Text.Json.Serialization;

namespace RiotSharpNET8.Endpoints.StaticDataEndpoint.Champion
{
    /// <summary>
    /// Class representing a list of champions (Static API).
    /// </summary>
    public class ChampionListStatic
    {
        internal ChampionListStatic() { }

        /// <summary>
        /// Map of champions indexed by their name.
        /// </summary>
        [JsonPropertyName("data")]
        public Dictionary<string, ChampionStatic> Champions { get; set; }

        /// <summary>
        /// Format of the data retrieved (always null afaik).
        /// </summary>
        [JsonPropertyName("format")]
        public string Format { get; set; }

        /// <summary>
        /// Map of the champions names indexed by their id.
        /// </summary>
        [JsonPropertyName("keys")]
        public Dictionary<int, string> Keys { get; set; }

        /// <summary>
        /// TAPI type (item).
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
