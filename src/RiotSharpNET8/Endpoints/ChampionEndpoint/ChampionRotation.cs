using System.Text.Json.Serialization;

namespace RiotSharpNET8.Endpoints.ChampionEndpoint
{
    /// <summary>
    /// Class representing Champions in the current rotation in the API.
    /// </summary>
    public class ChampionRotation
    {

        /// <summary>
        /// List of free champions.
        /// </summary>
        [JsonPropertyName("freeChampionIds")]
        public List<int> FreeChampionIds { get; set; }

        /// <summary>
        /// List of free champions for new players.
        /// </summary>
        [JsonPropertyName("freeChampionIdsForNewPlayers")]
        public List<int> FreeChampionIdsForNewPlayers { get; set; }

        /// <summary>
        /// Current max new player level.
        /// </summary>
        [JsonPropertyName("maxNewPlayerLevel")]
        public int MaxNewPlayerLevel { get; set; }
    }
}
