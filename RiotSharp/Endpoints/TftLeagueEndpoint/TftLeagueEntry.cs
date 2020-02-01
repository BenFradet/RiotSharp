using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace RiotSharp.Endpoints.TftLeagueEndpoint
{
    public class TftLeagueEntry : TftLeagueItem
    {
        internal TftLeagueEntry() { }

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
