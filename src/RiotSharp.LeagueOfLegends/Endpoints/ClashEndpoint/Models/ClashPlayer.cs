using System.Text.Json.Serialization;
using RiotSharp.LeagueOfLegends.Endpoints.ClashEndpoint.Enums;

namespace RiotSharp.LeagueOfLegends.Endpoints.ClashEndpoint.Models
{
    /// <summary>
    /// The model class defining properties of active clash player
    /// </summary>
    public class ClashPlayer
    {
        /// <summary>
        /// Summoner Id
        /// </summary>
        [JsonPropertyName("puuid")]
        public required string Puuid { get; set; }
        
        /// <summary>
        /// Clash Team Id
        /// </summary>
        [JsonPropertyName("teamId")]
        public required string TeamId { get; set; }
        
        /// <summary>
        /// Selected position in a clash game
        /// </summary>
        [JsonPropertyName("position")]
        public required ClashPosition Position { get; set; }
        
        /// <summary>
        /// hierarchy role in the team
        /// </summary>
        [JsonPropertyName("role")]
        public required ClashRole Role { get; set; }
    }
}