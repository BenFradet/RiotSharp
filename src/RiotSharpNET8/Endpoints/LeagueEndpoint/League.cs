using System.Text.Json.Serialization;
using RiotSharpNET8.Endpoints.LeagueEndpoint.Enums;

namespace RiotSharpNET8.Endpoints.LeagueEndpoint
{
    /// <summary>
    /// Class representing a LeagueList in the API.
    /// </summary>
    public class League
    {
        /// <summary>
        /// The requested league entries.
        /// </summary>
        [JsonPropertyName("entries")]
        public List<LeagueItem> Entries { get; set; }

        /// <summary>
        /// This name is an internal place-holder name only.
        /// Display and localization of names in the game client are handled client-side.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// The league id.
        /// </summary>
        [JsonPropertyName("leagueId")]
        public string LeagueId { get; set; }

        /// <summary>
        /// League queue (eg: RankedSolo5x5).
        /// </summary>
        [JsonPropertyName("queue")]
        public string Queue { get; set; }

        /// <summary>
        /// League tier (eg: Challenger).
        /// </summary>
        [JsonPropertyName("tier")]
        public Tier Tier { get; set; }
    }
}
