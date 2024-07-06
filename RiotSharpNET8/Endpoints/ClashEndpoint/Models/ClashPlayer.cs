using System.Text.Json.Serialization;
using RiotSharpNET8.Endpoints.ClashEndpoint.Enums;

namespace RiotSharpNET8.Endpoints.ClashEndpoint.Models
{
    /// <summary>
    /// The model class defining properties of active clash player
    /// </summary>
    public class ClashPlayer
    {
        /// <summary>
        /// Summoner Id
        /// </summary>
        [JsonPropertyName("summonerId")]
        public string SummonerId { get; set; }
        
        /// <summary>
        /// Clash Team Id
        /// </summary>
        [JsonPropertyName("teamId")]
        public string TeamId { get; set; }
        
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