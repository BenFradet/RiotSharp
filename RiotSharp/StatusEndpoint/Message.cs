using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace RiotSharp.StatusEndpoint
{
    /// <summary>
    /// Class representing messages for an incident (Status API).
    /// </summary>
    [Serializable]
    public class Message
    {
        internal Message() { }

        /// <summary>
        /// Author of the message.
        /// </summary>
        [JsonProperty("author")]
        public string Author { get; set; }

        /// <summary>
        /// Content of the message.
        /// </summary>
        [JsonProperty("content")]
        public string Content { get; set; }

        /// <summary>
        /// Date at which point the message was created.
        /// </summary>
        [JsonProperty("created_at")]
        [JsonConverter(typeof(DateTimeConverterFromString))]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Id of the message.
        /// </summary>
        [JsonProperty("id")]
        public long Id { get; set; }

        /// <summary>
        /// Severity of the messaage.
        /// </summary>
        [JsonProperty("severity")]
        public string Severity { get; set; }

        /// <summary>
        /// List of available translations for this message.
        /// </summary>
        [JsonProperty("translations")]
        public List<Translation> Translations { get; set; }

        /// <summary>
        /// Date at which point the message was last updated.
        /// </summary>
        [JsonProperty("updated_at")]
        [JsonConverter(typeof(DateTimeConverterFromString))]
        public DateTime UpdatedAt { get; set; }
    }
}
