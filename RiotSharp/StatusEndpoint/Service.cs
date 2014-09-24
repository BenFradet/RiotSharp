using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace RiotSharp.StatusEndpoint
{
    /// <summary>
    /// Class representing a service (Status API).
    /// </summary>
    [Serializable]
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
