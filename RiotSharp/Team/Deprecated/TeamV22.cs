using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RiotSharp
{
    /// <summary>
    /// Class representing a Team in the API.
    /// </summary>
    [Obsolete("The team api v2.2 is deprecated, please use Team instead.")]
    [Serializable]
    public class TeamV22
    {
        internal TeamV22() { }

        /// <summary>
        /// Date of the team creation.
        /// </summary>
        [JsonProperty("createDate")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// Team id.
        /// </summary>
        [JsonProperty("fullId")]
        public string FullId { get; set; }

        /// <summary>
        /// Date of the last game.
        /// </summary>
        [JsonProperty("lastGameDate")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime LastGameDate { get; set; }

        /// <summary>
        /// Date when the last member joined the team.
        /// </summary>
        [JsonProperty("lastJoinDate")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime LastJoinDate { get; set; }

        /// <summary>
        /// Date when the team last joined their queue.
        /// </summary>
        [JsonProperty("lastJoinedRankedTeamQueueDate")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime LastJoinedRankedTeamQueueDate { get; set; }

        /// <summary>
        /// Match history.
        /// </summary>
        [JsonProperty("matchHistory")]
        public List<MatchHistorySummaryV22> MatchHistory { get; set; }

        /// <summary>
        /// Message of the day.
        /// </summary>
        [JsonProperty("messageOfDay")]
        public MessageOfDay MessageOfDay { get; set; }

        /// <summary>
        /// Last time the team was modified.
        /// </summary>
        [JsonProperty("modifyDate")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime ModifyDate { get; set; }

        /// <summary>
        /// Name of the team.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Roster of the team.
        /// </summary>
        [JsonProperty("roster")]
        public Roster Roster { get; set; }

        /// <summary>
        /// Date when the second last member joined the team..
        /// </summary>
        [JsonProperty("secondLastJoinDate")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime SecondLastJoinDate { get; set; }

        /// <summary>
        /// Status of the team.
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; set; }

        /// <summary>
        /// Tag of the team.
        /// </summary>
        [JsonProperty("tag")]
        public string Tag { get; set; }

        /// <summary>
        /// Stat summary of the team.
        /// </summary>
        [JsonProperty("teamStatSummary")]
        public TeamStatSummaryV22 TeamStatSummary { get; set; }

        /// <summary>
        /// Date when the third last member joined the team.
        /// </summary>
        [JsonProperty("thirdLastJoinDate")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime ThirdLastJoinDate { get; set; }
    }
}
