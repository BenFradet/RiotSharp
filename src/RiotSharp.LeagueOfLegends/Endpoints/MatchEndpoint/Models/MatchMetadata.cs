using System.Text.Json.Serialization;

namespace RiotSharp.LeagueOfLegends.Endpoints.MatchEndpoint.Models
{
    public class MatchMetadata
    {
        /// <summary>
        /// Data Version of the data.
        /// </summary>
        [JsonPropertyName("dataVersion")]
        public string DataVersion { get; set; }

        /// <summary>
        /// Match ID of the match.
        /// </summary>
        [JsonPropertyName("matchId")]
        public string MatchId { get; set; }

        /// <summary>
        /// Participant Puuids.
        /// </summary>
        [JsonPropertyName("participants")]
        public List<string> Participants { get; set; }
    }
}
