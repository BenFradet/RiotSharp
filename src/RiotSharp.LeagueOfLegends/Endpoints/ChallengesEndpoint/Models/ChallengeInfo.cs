using RiotSharp.Core.Misc.Converters;
using RiotSharp.LeagueOfLegends.Endpoints.ChallengesEndpoint.Enums;
using System.Text.Json.Serialization;

namespace RiotSharp.LeagueOfLegends.Endpoints.ChallengesEndpoint.Models
{
    /// <summary>
    /// Information about a challenge for a player.
    /// </summary>
    public class ChallengeInfo
    {
        /// <summary>
        /// Which percentile the player is in for this challenge.
        /// </summary>
        [JsonPropertyName("percentile")]
        public required double Percentile { get; set; }

        /// <summary>
        /// How many players are in this level for the challenge.
        /// </summary>
        [JsonPropertyName("playersInLevel")]
        public int? PlayersInLevel { get; set; }

        /// <summary>
        /// When the player achieved this level for the challenge.
        /// </summary>
        [JsonPropertyName("achievedTime")]
        [JsonConverter(typeof(DateTimeConverterFromLong))]
        public DateTime? AchievedTime { get; set; }

        /// <summary>
        /// I don't know what this field is.
        /// </summary>
        [JsonPropertyName("value")]
        public required double Value { get; set; }

        /// <summary>
        /// Id of the challenge.
        /// </summary>
        [JsonPropertyName("challengeId")]
        public required long ChallengeId { get; set; }

        /// <summary>
        /// The achieved level for the challenge.
        /// </summary>
        [JsonPropertyName("level")]
        public required Level Level { get; set; }

        /// <summary>
        /// I don't know what this field is.
        /// </summary>
        [JsonPropertyName("position")]
        public int? Position { get; set; }
    }
}