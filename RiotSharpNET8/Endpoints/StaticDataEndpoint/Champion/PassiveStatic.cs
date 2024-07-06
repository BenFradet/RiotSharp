using System.Text.Json.Serialization;

namespace RiotSharpNET8.Endpoints.StaticDataEndpoint.Champion
{
    /// <summary>
    /// Class representing a champion's passive (Static API).
    /// </summary>
    public class PassiveStatic
    {
        internal PassiveStatic() { }

        /// <summary>
        /// String descripting the passive.
        /// </summary>
        [JsonPropertyName("description")]
        public string Description { get; set; }

        /// <summary>
        /// Image of the passive.
        /// </summary>
        [JsonPropertyName("image")]
        public ImageStatic Image { get; set; }

        /// <summary>
        /// Name of the passive.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Sanitized (HTML stripped) description of the passive.
        /// </summary>
        [JsonPropertyName("sanitizedDescription")]
        public string SanitizedDescription { get; set; }
    }
}
