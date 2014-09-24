using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace RiotSharp.TeamEndpoint
{
    /// <summary>
    /// Class representing a Team in the API.
    /// </summary>
    [Serializable]
    public class Team
    {
        internal Team() { }

        /// <summary>
        /// Date of the team creation.
        /// </summary>
        [JsonProperty("createDate")]
        [JsonConverter(typeof(DateTimeConverterFromLong))]
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
        [JsonConverter(typeof(DateTimeConverterFromLong))]
        public DateTime LastGameDate { get; set; }

        /// <summary>
        /// Date when the last member joined the team.
        /// </summary>
        [JsonProperty("lastJoinDate")]
        [JsonConverter(typeof(DateTimeConverterFromLong))]
        public DateTime LastJoinDate { get; set; }

        /// <summary>
        /// Date when the team last joined their queue.
        /// </summary>
        [JsonProperty("lastJoinedRankedTeamQueueDate")]
        [JsonConverter(typeof(DateTimeConverterFromLong))]
        public DateTime LastJoinedRankedTeamQueueDate { get; set; }

        /// <summary>
        /// Match history.
        /// </summary>
        [JsonProperty("matchHistory")]
        public List<MatchHistorySummary> MatchHistory { get; set; }

        /// <summary>
        /// Last time the team was modified.
        /// </summary>
        [JsonProperty("modifyDate")]
        [JsonConverter(typeof(DateTimeConverterFromLong))]
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
        [JsonConverter(typeof(DateTimeConverterFromLong))]
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
        [JsonProperty("teamStatDetails")]
        public List<TeamStatDetail> TeamStatDetails { get; set; }

        /// <summary>
        /// Date when the third last member joined the team.
        /// </summary>
        [JsonProperty("thirdLastJoinDate")]
        [JsonConverter(typeof(DateTimeConverterFromLong))]
        public DateTime ThirdLastJoinDate { get; set; }
    }
}
