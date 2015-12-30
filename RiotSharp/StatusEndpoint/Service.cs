using Newtonsoft.Json;
using System.Collections.Generic;

namespace RiotSharp.StatusEndpoint
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
        [JsonProperty("incidents")]
        public List<Incident> Incidents { get; set; }

        /// <summary>
        /// Name of the service.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Slug.
        /// </summary>
        [JsonProperty("slug")]
        public string Slug { get; set; }

        /// <summary>
        /// Service's status.
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; set; }
    }
}
