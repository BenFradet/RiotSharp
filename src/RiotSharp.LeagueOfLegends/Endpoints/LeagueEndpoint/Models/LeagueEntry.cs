
using System.Text.Json.Serialization;
using RiotSharp.LeagueOfLegends.Endpoints.LeagueEndpoint.Enums;

namespace RiotSharp.LeagueOfLegends.Endpoints.LeagueEndpoint.Models
{
    /// <summary>
    /// Team or summoner in a league (League API).
    /// </summary>
    public class LeagueEntry : LeagueItem
    {
        /// <summary>
        /// The Id of the league of the participant.
        /// </summary>
        [JsonPropertyName("leagueId")]
        public string LeagueId { get; set; }

        /// <summary>
        /// The queue type of the league.
        /// </summary>
        [JsonPropertyName("queueType")]
        public Queue QueueType { get; set; }

        ///<summary>
        /// The league tier of the participant.
        /// </summary>
        [JsonPropertyName("tier")]
        public string Tier { get; set; }
    }
}
