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

        // The challenge ids are fucking ints/longs but docs say they are strings???
        [JsonPropertyName("challengeIds")]
        public List<int> ChallengeIds { get; set; }

        [JsonPropertyName("crestBorder")]
        public string CrestBorder { get; set; }

        [JsonPropertyName("prestigeCrestBorderLevel")]
        public int PrestigeCrestBorderLevel { get; set; }
    }
}