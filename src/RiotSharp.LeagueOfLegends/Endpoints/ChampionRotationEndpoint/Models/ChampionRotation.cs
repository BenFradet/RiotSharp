using System.Text.Json.Serialization;

namespace RiotSharp.LeagueOfLegends.Endpoints.ChampionRotationEndpoint.Models
{
    /// <summary>
    /// Class representing Champions in the current rotation in the API.
    /// </summary>
    public class ChampionRotation
    {
	    /// <summary>
	    /// Current max new player level.
	    /// </summary>
	    [JsonPropertyName("maxNewPlayerLevel")]
	    public required int MaxNewPlayerLevel { get; set; }

        /// <summary>
        /// List of free champions for new players.
        /// </summary>
        [JsonPropertyName("freeChampionIdsForNewPlayers")]
        public required List<int> FreeChampionIdsForNewPlayers { get; set; }
        
        /// <summary>
        /// List of free champions.
        /// </summary>s
        [JsonPropertyName("freeChampionIds")]
        public required List<int> FreeChampionIds { get; set; }
    }
}
