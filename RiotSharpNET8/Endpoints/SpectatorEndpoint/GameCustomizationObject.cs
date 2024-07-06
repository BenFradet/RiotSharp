using System.Text.Json.Serialization;

namespace RiotSharpNET8.Endpoints.SpectatorEndpoint
{
    /// <summary>
    /// Class representing a GameCustomizationObject in the API.
    /// </summary>
    public class GameCustomizationObject
    {
        /// <summary>
        /// Category identifier for Game Customization
        /// </summary>
        [JsonPropertyName("category")]
        public string Category { get; set; }

        /// <summary>
        /// Game Customization content
        /// </summary>
        [JsonPropertyName("content")]
        public string Content { get; set; }
    }
}
