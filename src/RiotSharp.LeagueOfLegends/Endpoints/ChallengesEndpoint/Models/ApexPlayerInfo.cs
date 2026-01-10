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
        public string Puuid { get; set; }

        [JsonPropertyName("value")]
        public double Value { get; set; }

        [JsonPropertyName("position")]
        public int Position { get; set; }
    }
}