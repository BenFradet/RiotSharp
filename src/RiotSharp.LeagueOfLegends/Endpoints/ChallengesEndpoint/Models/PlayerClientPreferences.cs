using System.Text.Json.Serialization;

namespace RiotSharp.LeagueOfLegends.Endpoints.ChallengesEndpoint.Models
{
    /// <summary>
    /// I don't know what this class represents.
    /// </summary>
    public class PlayerClientPreferences
    {
        [JsonPropertyName("bannerAccent")]
        public required string BannerAccent { get; set; }

        [JsonPropertyName("title")]
        public required string Title { get; set; }

        // The challenge ids are fucking ints/longs but docs say they are strings???
        // My best guess is that the required field is valid since it might just return an empty list instead of null?
        [JsonPropertyName("challengeIds")]
        public required List<int> ChallengeIds { get; set; }

        [JsonPropertyName("crestBorder")]
        public required string CrestBorder { get; set; }

        [JsonPropertyName("prestigeCrestBorderLevel")]
        public required int PrestigeCrestBorderLevel { get; set; }
    }
}