using System.Text.Json.Serialization;

namespace RiotSharp.LeagueOfLegends.Endpoints.MatchEndpoint.Models
{
    /// <summary>
    /// Champion ban information (Match API).
    /// </summary>
    public class Ban
    {
        /// <summary>
        /// Champion ID that was banned.
        /// </summary>
        [JsonPropertyName("championId")]
        public int ChampionId { get; set; }

        /// <summary>
        /// Turn during which the champion was banned.
        /// </summary>
        [JsonPropertyName("pickTurn")]
        public int PickTurn { get; set; }
    }
}
