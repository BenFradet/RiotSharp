using System.Text.Json.Serialization;
using RiotSharpNET8.Misc.Converters;

namespace RiotSharpNET8.Endpoints.StatusEndpoint
{
    /// <summary>
    /// Class representing an incident inside a service (Status API).
    /// </summary>
    public class Incident
    {
        internal Incident() { }

        /// <summary>
        /// Whether or not this incident is still active.
        /// </summary>
        [JsonPropertyName("active")]
        public bool Active { get; set; }

        /// <summary>
        /// Date at which point the incident was logged.
        /// </summary>
        [JsonPropertyName("created_at")]
        [JsonConverter(typeof(DateTimeConverterFromString))]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Id of the incident.
        /// </summary>
        [JsonPropertyName("id")]
        public long Id { get; set; }

        /// <summary>
        /// List of updates for this incident.
        /// </summary>
        [JsonPropertyName("updates")]
        public List<Message> Updates { get; set; }
    }
}
