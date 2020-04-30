using Newtonsoft.Json;
using RiotSharp.Endpoints.LeagueEndpoint.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace RiotSharp.Endpoints.TftLeagueEndpoint
{
    public class TftLeague
    {
        internal TftLeague() { }

        /// <summary>
        /// The requested tft league entries.
        /// </summary>
        [JsonProperty("entries")]
        public List<TftLeagueItem> Entries { get; set; }

        /// <summary>
        /// This name is an internal place-holder name only.
        /// Display and localization of names in the game client are handled client-side.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// The tft league id.
        /// </summary>
        [JsonProperty("leagueId")]
        public string LeagueId { get; set; }

        /// <summary>
        /// Tft league queue (eg: RankedSolo5x5).
        /// </summary>
        [JsonProperty("queue")]
        public string Queue { get; set; }

        /// <summary>
        /// Tft League tier (eg: Challenger).
        /// </summary>
        [JsonProperty("tier")]
        public Tier Tier { get; set; }
    }
}
