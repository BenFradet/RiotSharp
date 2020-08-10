using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace RiotSharp.Endpoints.ClashEndpoint.Models
{
    /// <summary>
    /// Model class representing Clash Tournament entity
    /// </summary>
    public class ClashTournament
    {
        /// <summary>
        /// Tournament Id
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }
        
        /// <summary>
        /// Tournament theme Id
        /// </summary>
        [JsonProperty("themeId")]
        public int ThemeId { get; set; }
        
        /// <summary>
        /// Tournament Name (ex: Piltover)
        /// </summary>
        [JsonProperty("nameKey")]
        public string NameKey { get; set; }
        
        /// <summary>
        /// Secondary name of a tournament (ex: Day 4)
        /// </summary>
        [JsonProperty("nameKeySecondary")]
        public string NameKeySecondary { get; set; }
        
        /// <summary>
        /// List of tournament phases
        /// </summary>
        [JsonProperty("schedule")]
        public List<ClashTournamentPhase> Schedule { get; set; }
    }
}