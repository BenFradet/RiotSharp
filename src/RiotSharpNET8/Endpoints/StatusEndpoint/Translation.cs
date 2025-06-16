using System.Text.Json.Serialization;
using RiotSharpNET8.Misc;
using RiotSharpNET8.Misc.Converters;

namespace RiotSharpNET8.Endpoints.StatusEndpoint
{
    /// <summary>
    /// Class representing a translation of a message (Status API).
    /// </summary>
    public class Translation
    {
        internal Translation() { }

        /// <summary>
        /// Translated content of the message.
        /// </summary>
        [JsonPropertyName("content")]
        public string Content { get; set; }

        /// <summary>
        /// Language in which the translation was done.
        /// </summary>
        [JsonPropertyName("locale")]
        public Language Locale { get; set; }

        /// <summary>
        /// Date at which point the translation was last updated.
        /// </summary>
        [JsonPropertyName("updated_at")]
        [JsonConverter(typeof(DateTimeConverterFromString))]
        public DateTime UpdatedAt { get; set; }
    }
}
