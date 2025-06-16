using Newtonsoft.Json;

namespace RiotSharp.Endpoints.LeagueEndpoint
{
    /// <summary>
    /// Team or summoner in a league (League API).
    /// </summary>
    public class LeagueEntry : LeagueItem
    {
        internal LeagueEntry()
        {
        }

        /// <summary>
        /// The Id of the league of the participant.
        /// </summary>
        [JsonProperty("leagueId")]
        public string LeagueId { get; set; }

        /// <summary>
        /// The queue type of the league.
        /// </summary>
        [JsonProperty("queueType")]
        public string QueueType { get; set; }

        ///<summary>
        /// The league tier of the participant.
        /// </summary>
        [JsonProperty("tier")]
        public string Tier { get; set; }
    }
}
