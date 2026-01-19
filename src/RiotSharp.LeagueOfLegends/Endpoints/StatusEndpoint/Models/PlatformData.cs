using RiotSharp.Core.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RiotSharp.LeagueOfLegends.Endpoints.StatusEndpoint.Models
{
    public class PlatformData
    {
        [JsonPropertyName("id")]
        public required string Id { get; set; }

        [JsonPropertyName("name")]
        public required string Name { get; set; }

        [JsonPropertyName("locales")]
        public required List<Language> Locales { get; set; }

        [JsonPropertyName("maintenances")]
        public required List<Status> Maintenances { get; set; }

        [JsonPropertyName("incidents")]
        public required List<Status> Incidents { get; set; }
    }
}