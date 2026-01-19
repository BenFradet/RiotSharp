using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace RiotSharp.LeagueOfLegends.Endpoints.ChallengesEndpoint.Models
{
    public class ApexPlayerInfo
    {
        [JsonPropertyName("puuid")]
        public required string Puuid { get; set; }

        [JsonPropertyName("value")]
        public required double Value { get; set; }

        [JsonPropertyName("position")]
        public required int Position { get; set; }
    }
}