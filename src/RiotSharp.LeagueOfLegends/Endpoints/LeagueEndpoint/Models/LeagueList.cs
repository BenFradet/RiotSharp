using System.Text.Json.Serialization;
using RiotSharp.LeagueOfLegends.Endpoints.LeagueEndpoint.Enums;

namespace RiotSharp.LeagueOfLegends.Endpoints.LeagueEndpoint.Models
{
    /// <summary>
    /// Class representing a LeagueList in the API.
    /// </summary>
    public class LeagueList
    {
	    /// <summary>
	    /// The league id.
	    /// </summary>
	    [JsonPropertyName("leagueId")]
	    public required string LeagueId { get; set; }

        /// <summary>
        /// The requested league entries.
        /// </summary>
        [JsonPropertyName("entries")]
        public required List<LeagueItem> Entries { get; set; }
        
        /// <summary>
        /// League tier (eg: Challenger).
        /// </summary>
        [JsonPropertyName("tier")]
        public required Tier Tier { get; set; }

        /// <summary>
        /// This name is an internal place-holder name only.
        /// Display and localization of names in the game client are handled client-side.
        /// </summary>
        [JsonPropertyName("name")]
        public required string Name { get; set; }

        /// <summary>
        /// League queue (eg: RankedSolo5x5).
        /// </summary>
        [JsonPropertyName("queue")]
        public required Queue Queue { get; set; }
    }
}
