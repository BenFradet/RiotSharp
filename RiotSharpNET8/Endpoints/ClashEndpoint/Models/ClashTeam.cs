using System.Text.Json.Serialization;

namespace RiotSharpNET8.Endpoints.ClashEndpoint.Models
{
    public class ClashTeam
    {
        /// <summary>
        /// Clash team id
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary>
        /// Clash tournament id
        /// </summary>
        [JsonPropertyName("tournamentId")]
        public int TournamentId { get; set; }

        /// <summary>
        /// Clash team name
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// clash team icon id
        /// </summary>
        [JsonPropertyName("iconId")]
        public int IconId { get; set; }

        /// <summary>
        /// clash team tier
        /// </summary>
        [JsonPropertyName("tier")]
        public int Tier { get; set; }

        /// <summary>
        /// Summoner Id of the team captain
        /// </summary>
        [JsonPropertyName("captain")]
        public string CaptainId { get; set; }

        /// <summary>
        /// The team name 3 character long abbreviation
        /// </summary>
        [JsonPropertyName("abbreviation")]
        public string Abbreviation { get; set; }
        
        /// <summary>
        /// List containing infos about team players
        /// </summary>
        [JsonPropertyName("players")]
        public List<ClashTeamPlayer> Players { get; set; }
    }
}