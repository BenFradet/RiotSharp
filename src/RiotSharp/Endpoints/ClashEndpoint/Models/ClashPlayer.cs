using Newtonsoft.Json;
using RiotSharp.Endpoints.ClashEndpoint.Enums;

namespace RiotSharp.Endpoints.ClashEndpoint.Models
{
    /// <summary>
    /// The model class defining properties of active clash player
    /// </summary>
    public class ClashPlayer
    {
        /// <summary>
        /// Summoner Id
        /// </summary>
        [JsonProperty("summonerId")]
        public string SummonerId { get; set; }
        
        /// <summary>
        /// Clash Team Id
        /// </summary>
        [JsonProperty("teamId")]
        public string TeamId { get; set; }
        
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