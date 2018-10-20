using Newtonsoft.Json;
using System.Collections.Generic;

namespace RiotSharp.Endpoints.ChampionEndpoint
{
    /// <summary>
    /// Class representing Champions in the current rotation in the API.
    /// </summary>
    public class ChampionRotation
    {

        /// <summary>
        /// List of free champions.
        /// </summary>
        [JsonProperty("freeChampionIds")]
        public List<int> FreeChampionIds { get; set; }

        /// <summary>
        /// List of free champions for new players.
        /// </summary>
        [JsonProperty("freeChampionIdsForNewPlayers")]
        public List<int> FreeChampionIdsForNewPlayers { get; set; }

        /// <summary>
        /// Current max new player level.
        /// </summary>
        [JsonProperty("maxNewPlayerLevel")]
        public int MaxNewPlayerLevel { get; set; }
    }
}
