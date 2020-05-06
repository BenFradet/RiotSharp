using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace RiotSharp.Endpoints.ClashEndpoint.Models
{
    public class ClashTeam
    {
        /// <summary>
        /// Clash team id
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Clash tournament id
        /// </summary>
        [JsonProperty("tournamentId")]
        public int TournamentId { get; set; }

        /// <summary>
        /// Clash team name
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// clash team icon id
        /// </summary>
        [JsonProperty("iconId")]
        public int IconId { get; set; }

        /// <summary>
        /// clash team tier
        /// </summary>
        [JsonProperty("tier")]
        public int Tier { get; set; }

        /// <summary>
        /// Summoner Id of the team captain
        /// </summary>
        [JsonProperty("captain")]
        public string CaptainId { get; set; }

        /// <summary>
        /// The team name 3 character long abbreviation
        /// </summary>
        [JsonProperty("abbreviation")]
        public string Abbreviation { get; set; }
        
        /// <summary>
        /// List containing infos about team players
        /// </summary>
        [JsonProperty("players")]
        public List<ClashTeamPlayer> Players { get; set; }
    }
}