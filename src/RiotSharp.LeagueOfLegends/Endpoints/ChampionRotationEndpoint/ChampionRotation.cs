using System.Text.Json.Serialization;

namespace RiotSharp.LeagueOfLegends.Endpoints.ChampionRotationEndpoint
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
	    public int MaxNewPlayerLevel { get; set; }

        /// <summary>
        /// List of free champions for new players.
        /// </summary>
        [JsonPropertyName("freeChampionIdsForNewPlayers")]
        public List<int> FreeChampionIdsForNewPlayers { get; set; }
        
        /// <summary>
        /// List of free champions.
        /// </summary>s
        [JsonPropertyName("freeChampionIds")]
        public List<int> FreeChampionIds { get; set; }

    }
}
