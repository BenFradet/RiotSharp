using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RiotSharp.LeagueOfLegends.Endpoints.ChallengesEndpoint.Models
{
    public class ChallengeDescription
    {
        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("shortDescription")]
        public string ShortDescription { get; set; }
    }
}