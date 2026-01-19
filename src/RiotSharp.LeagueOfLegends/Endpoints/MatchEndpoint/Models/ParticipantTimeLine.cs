using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RiotSharp.LeagueOfLegends.Endpoints.MatchEndpoint.Models
{
    public class ParticipantTimeLine
    {
        [JsonPropertyName("participantId")]
        public required int ParticipantId { get; set; }

        [JsonPropertyName("puuid")]
        public required string Puuid { get; set; }
    }
}