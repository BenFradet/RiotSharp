using System.Collections.Generic;
using Newtonsoft.Json;
using RiotSharp.Endpoints.LeagueEndpoint.Enums;

namespace RiotSharp.Endpoints.LeagueEndpoint
{
    /// <summary>
    /// Class representing a LeagueList in the API.
    /// </summary>
    public class League
    {
        internal League() { }

        /// <summary>
        /// The requested league entries.
        /// </summary>
        [JsonProperty("entries")]
        public List<LeagueItem> Entries { get; set; }

        /// <summary>
        /// This name is an internal place-holder name only.
        /// Display and localization of names in the game client are handled client-side.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// The league id.
        /// </summary>
        [JsonProperty("leagueId")]
        public string LeagueId { get; set; }

        /// <summary>
        /// League queue (eg: RankedSolo5x5).
        /// </summary>
        [JsonProperty("queue")]
        public string Queue { get; set; }

        /// <summary>
        /// League tier (eg: Challenger).
        /// </summary>
        [JsonProperty("tier")]
        public Tier Tier { get; set; }
    }
}
