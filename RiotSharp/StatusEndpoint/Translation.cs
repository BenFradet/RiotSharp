using System;
using Newtonsoft.Json;

namespace RiotSharp.StatusEndpoint
{
    /// <summary>
    /// Class representing a translation of a message (Status API).
    /// </summary>
    [Serializable]
    public class Translation
    {
        internal Translation() { }

        /// <summary>
        /// Translated content of the message.
        /// </summary>
        [JsonProperty("content")]
        public string Content { get; set; }

        /// <summary>
        /// Language in which the translation was done.
        /// </summary>
        [JsonProperty("locale")]
        public Language Locale { get; set; }

        /// <summary>
        /// Date at which point the translation was last updated.
        /// </summary>
        [JsonProperty("updated_at")]
        [JsonConverter(typeof(DateTimeConverterFromString))]
        public DateTime UpdatedAt { get; set; }
    }
}
