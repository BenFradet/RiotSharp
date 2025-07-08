using System.Text.Json.Serialization;
using RiotSharp.LeagueOfLegends.Endpoints.ClashEndpoint.Enums;

namespace RiotSharp.LeagueOfLegends.Endpoints.ClashEndpoint.Models
{
    /// <summary>
    /// The model class defining properties of active clash player
    /// </summary>
    public class ClashPlayer
    {
        //puuid	string	
        // teamId	string	
        // position	string	(Legal values: UNSELECTED, FILL, TOP, JUNGLE, MIDDLE, BOTTOM, UTILITY)
        // role	string	(Legal values: CAPTAIN, MEMBER)
        // 


        /// <summary>
        /// Summoner Id
        /// </summary>
        [JsonPropertyName("puuid")]
        public string Puuid { get; set; }
        
        /// <summary>
        /// Clash Team Id
        /// </summary>
        [JsonPropertyName("teamId")]
        public string TeamId { get; set; }
        
        /// <summary>
        /// Selected position in a clash game
        /// </summary>
        [JsonPropertyName("position")]
        public ClashPosition Position { get; set; }
        
        /// <summary>
        /// hierarchy role in the team
        /// </summary>
        [JsonPropertyName("role")]
        public ClashRole Role { get; set; }
    }
}