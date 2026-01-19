using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;


namespace RiotSharp.LeagueOfLegends.Endpoints.ChallengesEndpoint.Models
{
    public class PlayerInfo
    {
        /// <summary>
		/// List of challenges associated with the player.
		/// </summary>
		[JsonPropertyName("challenges")]
        public required List<ChallengeInfo> Challenges { get; set; }

        [JsonPropertyName("preferences")]
        public required PlayerClientPreferences Preferences { get; set; }

        [JsonPropertyName("totalPoints")]
        public required ChallengePoint TotalPoints { get; set; }

        [JsonPropertyName("categoryPoints")]
        public required Dictionary<string, ChallengePoint> CategoryPoints { get; set; }
    }
}
