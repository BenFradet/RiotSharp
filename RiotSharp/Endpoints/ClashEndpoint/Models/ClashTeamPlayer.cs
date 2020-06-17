using Newtonsoft.Json;
using RiotSharp.Endpoints.ClashEndpoint.Enums;

namespace RiotSharp.Endpoints.ClashEndpoint.Models
{
    /// <summary>
    /// Model Representing a player in the clash team
    /// </summary>
    public class ClashTeamPlayer
    {
        /// <summary>
        /// Summoner Id
        /// </summary>
        [JsonProperty("summonerId")]
        public string SummonerId { get; set; }

        /// <summary>
        /// Position In a game
        /// </summary>
        [JsonProperty("position")]
        public PositionType Position { get; set; }
        
        /// <summary>
        /// hierarchy role in the team
        /// </summary>
        [JsonProperty("role")]
        public RoleType Role { get; set; }
    }
}