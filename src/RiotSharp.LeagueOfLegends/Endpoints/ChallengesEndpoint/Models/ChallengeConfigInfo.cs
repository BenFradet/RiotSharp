using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using RiotSharp.Core.Misc;
using RiotSharp.Core.Misc.Converters;
using RiotSharp.LeagueOfLegends.Endpoints.ChallengesEndpoint.Enums;

namespace RiotSharp.LeagueOfLegends.Endpoints.ChallengesEndpoint.Models
{
    /// <summary>
    /// Configuration information for a challenge.
    /// </summary>
    public class ChallengeConfigInfo
    {
        /// <summary>
        /// Unique identifier for the challenge.
        /// </summary>
        [JsonPropertyName("id")]
        public long Id { get; set; }

        /// <summary>
        /// Localized names for the challenge. Maps locale to name/description pairs.
        /// Basically it is for many different languages.
        /// </summary>
        [JsonPropertyName("localizedNames")]
        public Dictionary<Language, ChallengeDescription> LocalizedNames { get; set; }

        /// <summary>
        /// Current state of the challenge (Disabled, Hidden, Enabled, or Archived).
        /// </summary>
        [JsonPropertyName("state")]
        public State State { get; set; }

        /// <summary>
        /// Tracking type for the challenge (Lifetime or Season).
        /// </summary>
        [JsonPropertyName("tracking")]
        public Tracking Tracking { get; set; }

        /// <summary>
        /// Start timestamp for the challenge in milliseconds since epoch.
        /// </summary>
        [JsonPropertyName("startTimestamp")]
        [JsonConverter(typeof(DateTimeConverterFromLong))]
        public DateTime StartTimestamp { get; set; }

        /// <summary>
        /// End timestamp for the challenge in milliseconds since epoch.
        /// </summary>
        [JsonPropertyName("endTimestamp")]
        [JsonConverter(typeof(DateTimeConverterFromLong))]
        public DateTime EndTimestamp { get; set; }

        /// <summary>
        /// Whether the challenge has a leaderboard.
        /// </summary>
        [JsonPropertyName("leaderboard")]
        public bool Leaderboard { get; set; }

        /// <summary>
        /// Thresholds for different challenge levels. Maps Level enum to threshold values.
        /// Not all the levels will be present in the dictionary.
        /// NOTE: HighestNotLeaderboardOnly, Highest and Lowest are not to be used as keys in this dictionary.
        /// </summary>
        [JsonPropertyName("thresholds")]
        public Dictionary<Level, double> Thresholds { get; set; }
    }
}