using RiotSharp.Core.Misc.Converters;
using RiotSharp.LeagueOfLegends.Endpoints.StatusEndpoint.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RiotSharp.LeagueOfLegends.Endpoints.StatusEndpoint.Models
{
    /// <summary>
    /// Represents a status update for a platform or service
    /// </summary>
    public class Status
    {
        /// <summary>
        /// Unique identifier for the status
        /// </summary>
        [JsonPropertyName("id")]
        public required int Id { get; set; }

        /// <summary>
        /// Current maintenance status (scheduled, in_progress, complete)
        /// </summary>
        [JsonPropertyName("maintenance_status")]
        public MaintenanceStatus? MaintenanceStatus { get; set; }

        /// <summary>
        /// Incident severity level (info, warning, critical)
        /// </summary>
        [JsonPropertyName("incident_severity")]
        public IncidentSeverity? IncidentSeverity { get; set; }

        /// <summary>
        /// List of titles for the status update
        /// </summary>
        [JsonPropertyName("titles")]
        public required List<Content> Titles { get; set; }

        /// <summary>
        /// List of updates for the status
        /// </summary>
        [JsonPropertyName("updates")]
        public required List<Update> Updates { get; set; }

        /// <summary>
        /// Timestamp when the status was created
        /// </summary>
        [JsonPropertyName("created_at")]
        public required DateTime CreatedAt { get; set; }

        /// <summary>
        /// Timestamp when the status will be archived
        /// </summary>
        [JsonPropertyName("archive_at")]
        [JsonConverter(typeof(DateTimeConverterFromLong))]
        public required DateTime ArchiveAt { get; set; }

        /// <summary>
        /// Timestamp when the status was last updated
        /// </summary>
        [JsonPropertyName("updated_at")]
        [JsonConverter(typeof(DateTimeConverterFromLong))]
        public required DateTime UpdatedAt { get; set; }

        /// <summary>
        /// List of affected platforms (windows, macos, android, ios, ps4, xbone, switch)
        /// </summary>
        [JsonPropertyName("platforms")]
        public required List<Platform> Platforms { get; set; }
    }
}