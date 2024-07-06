using System.Text.Json.Serialization;
using RiotSharpNET8.Misc.Converters;

namespace RiotSharpNET8.Endpoints.StatusEndpoint
{
    /// <summary>
    /// Class representing messages for an incident (Status API).
    /// </summary>
    public class Message
    {
        /// <summary>
        /// Author of the message.
        /// </summary>
        [JsonPropertyName("author")]
        public string Author { get; set; }

        /// <summary>
        /// Content of the message.
        /// </summary>
        [JsonPropertyName("content")]
        public string Content { get; set; }

        /// <summary>
        /// Date at which point the message was created.
        /// </summary>
        [JsonPropertyName("created_at")]
        [JsonConverter(typeof(DateTimeConverterFromString))]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Id of the message.
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary>
        /// Severity of the messaage.
        /// </summary>
        [JsonPropertyName("severity")]
        public string Severity { get; set; }

        /// <summary>
        /// List of available translations for this message.
        /// </summary>
        [JsonPropertyName("translations")]
        public List<Translation> Translations { get; set; }

        /// <summary>
        /// Date at which point the message was last updated.
        /// </summary>
        [JsonPropertyName("updated_at")]
        [JsonConverter(typeof(DateTimeConverterFromString))]
        public DateTime UpdatedAt { get; set; }
    }
}
