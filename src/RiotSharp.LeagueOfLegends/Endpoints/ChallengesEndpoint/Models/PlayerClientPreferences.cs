using System.Text.Json.Serialization;

namespace RiotSharp.LeagueOfLegends.Endpoints.ChallengesEndpoint.Models
{
    /// <summary>
    /// I don't know what this class represents.
    /// </summary>
    public class PlayerClientPreferences
    {
        [JsonPropertyName("bannerAccent")]
        public string BannerAccent { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("challengeIds")]
        public List<string> ChallengeIds { get; set; }

        [JsonPropertyName("crestBorder")]
        public string CrestBorder { get; set; }

        [JsonPropertyName("prestigeCrestBorderLevel")]
        public int PrestigeCrestBorderLevel { get; set; }
    }
}