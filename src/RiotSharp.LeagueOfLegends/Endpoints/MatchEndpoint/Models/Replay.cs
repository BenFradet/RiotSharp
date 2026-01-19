using RiotSharp.LeagueOfLegends.Endpoints.MatchEndpoint.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RiotSharp.LeagueOfLegends.Endpoints.MatchEndpoint.Models
{
    public class Replay
    {
        [JsonPropertyName("total")]
        public required int Total { get; set; }

        [JsonPropertyName("matchFileURLs")]
        public required List<string> MatchFileURLs { get; set; }
    }
}