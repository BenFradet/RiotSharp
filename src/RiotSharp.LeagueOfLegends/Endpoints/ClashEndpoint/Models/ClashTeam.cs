using System.Text.Json.Serialization;

namespace RiotSharp.LeagueOfLegends.Endpoints.ClashEndpoint.Models
{
    public class ClashTeam
    {
        /// <summary>
        /// Clash team id
        /// </summary>
        [JsonPropertyName("id")]
        public required string Id { get; set; }

        /// <summary>
        /// Clash tournament id
        /// </summary>
        [JsonPropertyName("tournamentId")]
        public required int TournamentId { get; set; }

        /// <summary>
        /// Clash team name
        /// </summary>
        [JsonPropertyName("name")]
        public required string Name { get; set; }

        /// <summary>
        /// clash team icon id
        /// </summary>
        [JsonPropertyName("iconId")]
        public required int IconId { get; set; }

        /// <summary>
        /// clash team tier
        /// </summary>
        [JsonPropertyName("tier")]
        public required int Tier { get; set; }

        /// <summary>
        /// Summoner Id of the team captain
        /// Really Riot. Why the fuck is this still a summoner id???
        /// Or it really is a puuid, but they dont care about the docs.
        /// </summary>
        [JsonPropertyName("captain")]
        public required string CaptainId { get; set; }

        /// <summary>
        /// The team name 3 character long abbreviation
        /// </summary>
        [JsonPropertyName("abbreviation")]
        public required string Abbreviation { get; set; }
        
        /// <summary>
        /// List containing infos about team players
        /// </summary>
        [JsonPropertyName("players")]
        public required List<ClashPlayer> Players { get; set; }
    }
}