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
        public List<ChallengeInfo> Challenges { get; set; }

        [JsonPropertyName("preferences")]
        public PlayerClientPreferences Preferences { get; set; }


        [JsonPropertyName("totalPoints")]

        public ChallengePoint TotalPoints { get; set; }


        [JsonPropertyName("categoryPoints")]

        public Dictionary<string, ChallengePoint> CategoryPoints { get; set; }

    }
}
