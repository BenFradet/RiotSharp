using System.Text.Json.Serialization;

namespace RiotSharpNET8.Endpoints.StatusEndpoint
{
    /// <summary>
    /// Class representing a service (Status API).
    /// </summary>
    public class Service
    {
        internal Service() { }

        /// <summary>
        /// List of incidents for this service.
        /// </summary>
        [JsonPropertyName("incidents")]
        public List<Incident> Incidents { get; set; }

        /// <summary>
        /// Name of the service.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Slug.
        /// </summary>
        [JsonPropertyName("slug")]
        public string Slug { get; set; }

        /// <summary>
        /// Service's status.
        /// </summary>
        [JsonPropertyName("status")]
        public string Status { get; set; }
    }
}
