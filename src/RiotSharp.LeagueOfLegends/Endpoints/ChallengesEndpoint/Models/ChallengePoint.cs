using RiotSharp.LeagueOfLegends.Endpoints.ChallengesEndpoint.Enums;
using System.Text.Json.Serialization;

namespace RiotSharp.LeagueOfLegends.Endpoints.ChallengesEndpoint.Models
{
    public class ChallengePoint
    {
        /// <summary>
        /// I hope it is also a level. Doesn't have documentation.
        /// </summary>
        [JsonPropertyName("level")]
        public Level Level { get; set; }

        [JsonPropertyName("current")]
        public long Current { get; set; }

        [JsonPropertyName("max")]
        public long Max { get; set; }

        [JsonPropertyName("precentile")]
        public long Precentile { get; set; }
    }
}