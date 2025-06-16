using System.Text.Json.Serialization;

namespace RiotSharpNET8.Endpoints.SpectatorEndpoint
{
    /// <summary>
    /// Class representing a BannedChampion in the API.
    /// </summary>
    public class BannedChampion
    {
        /// <summary>
        /// The ID of the banned champion
        /// </summary>
        [JsonPropertyName("championId")]
        public long ChampionId { get; set; }

        /// <summary>
        /// The turn during which the champion was banned
        /// </summary>
        [JsonPropertyName("pickTurn")]
        public int PickTurn { get; set; }

        /// <summary>
        /// The ID of the team that banned the champion
        /// </summary>
        [JsonPropertyName("teamId")]
        public long TeamId { get; set; }
    }
}
