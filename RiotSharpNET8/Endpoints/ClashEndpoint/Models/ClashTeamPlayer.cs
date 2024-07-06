using System.Text.Json.Serialization;
using RiotSharpNET8.Endpoints.ClashEndpoint.Enums;

namespace RiotSharpNET8.Endpoints.ClashEndpoint.Models
{
    /// <summary>
    /// Model Representing a player in the clash team
    /// </summary>
    public class ClashTeamPlayer
    {
        /// <summary>
        /// Summoner Id
        /// </summary>
        [JsonPropertyName("summonerId")]
        public string SummonerId { get; set; }

        /// <summary>
        /// Position In a game
        /// </summary>
        [JsonPropertyName("position")]
        public PositionType Position { get; set; }
        
        /// <summary>
        /// hierarchy role in the team
        /// </summary>
        [JsonPropertyName("role")]
        public RoleType Role { get; set; }
    }
}