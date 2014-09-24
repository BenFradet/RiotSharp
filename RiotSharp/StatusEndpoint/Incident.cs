using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace RiotSharp.StatusEndpoint
{
    /// <summary>
    /// Class representing an incident inside a service (Status API).
    /// </summary>
    [Serializable]
    public class Incident
    {
        internal Incident() { }

        /// <summary>
        /// Whether or not this incident is still active.
        /// </summary>
        [JsonProperty("active")]
        public bool Active { get; set; }

        /// <summary>
        /// Date at which point the incident was logged.
        /// </summary>
        [JsonProperty("created_at")]
        [JsonConverter(typeof(DateTimeConverterFromString))]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Id of the incident.
        /// </summary>
        [JsonProperty("id")]
        public long Id { get; set; }

        /// <summary>
        /// List of updates for this incident.
        /// </summary>
        [JsonProperty("updates")]
        public List<Message> Updates { get; set; }
    }
}
