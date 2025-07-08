using System.Text.Json.Serialization;

namespace RiotSharp.LeagueOfLegends.Endpoints.ClashEndpoint.Models
{
    /// <summary>
    /// Model class representing Clash Tournament entity
    /// </summary>
    public class ClashTournament
    {
        /// <summary>
        /// Tournament Id
        /// </summary>
        [JsonPropertyName("id")]
        public int Id { get; set; }
        
        /// <summary>
        /// Tournament theme Id
        /// </summary>
        [JsonPropertyName("themeId")]
        public int ThemeId { get; set; }
        
        /// <summary>
        /// Tournament Name (ex: Piltover)
        /// </summary>
        [JsonPropertyName("nameKey")]
        public string NameKey { get; set; }
        
        /// <summary>
        /// Secondary name of a tournament (ex: Day 4)
        /// </summary>
        [JsonPropertyName("nameKeySecondary")]
        public string NameKeySecondary { get; set; }
        
        /// <summary>
        /// List of tournament phases
        /// </summary>
        [JsonPropertyName("schedule")]
        public List<ClashTournamentPhase> Schedule { get; set; }
    }
}