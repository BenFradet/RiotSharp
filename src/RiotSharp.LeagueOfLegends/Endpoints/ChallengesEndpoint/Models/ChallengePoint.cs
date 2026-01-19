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
        public required Level Level { get; set; }

        [JsonPropertyName("current")]
        public required long Current { get; set; }

        [JsonPropertyName("max")]
        public required long Max { get; set; }

        /// <summary>
        /// Docs say long, its a fuckign float.
        /// </summary>
        [JsonPropertyName("percentile")]
        public required double Percentile { get; set; }
    }
}