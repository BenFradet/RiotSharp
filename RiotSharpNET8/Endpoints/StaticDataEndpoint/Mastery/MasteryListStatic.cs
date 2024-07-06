using System.Text.Json.Serialization;

namespace RiotSharpNET8.Endpoints.StaticDataEndpoint.Mastery
{
    /// <summary>
    /// Class representing a list of masteries (Static API).
    /// </summary>
    public class MasteryListStatic
    {
        /// <summary>
        /// Map of masteries indexed by their id.
        /// </summary>
        [JsonPropertyName("data")]
        public Dictionary<int, MasteryStatic> Masteries { get; set; }

        /// <summary>
        /// Tree of masteries.
        /// </summary>
        [JsonPropertyName("tree")]
        public MasteryTreeStatic Tree { get; set; }

        /// <summary>
        /// API type (mastery).
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
