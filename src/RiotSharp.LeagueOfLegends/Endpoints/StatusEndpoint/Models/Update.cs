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
    /// Represents an update to a status
    /// </summary>
    public class Update
    {
        /// <summary>
        /// Unique identifier for the update
        /// </summary>
        [JsonPropertyName("id")]
        public required int Id { get; set; }

        /// <summary>
        /// Author of the update
        /// </summary>
        [JsonPropertyName("author")]
        public required string Author { get; set; }

        /// <summary>
        /// Whether the update should be published
        /// </summary>
        [JsonPropertyName("publish")]
        public required bool Publish { get; set; }
        
        /// <summary>
        /// List of locations where the update should be published (riotclient, riotstatus, game)
        /// </summary>
        [JsonPropertyName("publish_locations")]
        public required List<PublishLocation> PublishLocations { get; set; }

        /// <summary>
        /// List of translations for the update content
        /// </summary>
        [JsonPropertyName("translations")]
        public required List<Content> Translations { get; set; }

        /// <summary>
        /// Timestamp when the update was created
        /// </summary>
        [JsonPropertyName("created_at")]
        [JsonConverter(typeof(DateTimeConverterFromLong))]
        public required DateTime CreatedAt { get; set; }

        /// <summary>
        /// Timestamp when the update was last updated
        /// </summary>
        [JsonPropertyName("updated_at")]
        [JsonConverter(typeof(DateTimeConverterFromLong))]
        public required DateTime UpdatedAt { get; set; }
    }
}