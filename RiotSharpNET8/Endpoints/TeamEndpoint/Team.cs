using System.Text.Json.Serialization;
using RiotSharpNET8.Misc.Converters;

namespace RiotSharpNET8.Endpoints.TeamEndpoint
{
    /// <summary>
    /// Class representing a Team in the API.
    /// </summary>
    public class Team
    {
        internal Team() { }

        /// <summary>
        /// Date of the team creation.
        /// </summary>
        [JsonPropertyName("createDate")]
        [JsonConverter(typeof(DateTimeConverterFromLong))]
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// Team id.
        /// </summary>
        [JsonPropertyName("fullId")]
        public string FullId { get; set; }

        /// <summary>
        /// Date of the last game.
        /// </summary>
        [JsonPropertyName("lastGameDate")]
        [JsonConverter(typeof(DateTimeConverterFromLong))]
        public DateTime LastGameDate { get; set; }

        /// <summary>
        /// Date when the last member joined the team.
        /// </summary>
        [JsonPropertyName("lastJoinDate")]
        [JsonConverter(typeof(DateTimeConverterFromLong))]
        public DateTime LastJoinDate { get; set; }

        /// <summary>
        /// Date when the team last joined their queue.
        /// </summary>
        [JsonPropertyName("lastJoinedRankedTeamQueueDate")]
        [JsonConverter(typeof(DateTimeConverterFromLong))]
        public DateTime LastJoinedRankedTeamQueueDate { get; set; }

        /// <summary>
        /// Match history.
        /// </summary>
        [JsonPropertyName("matchHistory")]
        public List<MatchHistorySummary> MatchHistory { get; set; }

        /// <summary>
        /// Last time the team was modified.
        /// </summary>
        [JsonPropertyName("modifyDate")]
        [JsonConverter(typeof(DateTimeConverterFromLong))]
        public DateTime ModifyDate { get; set; }

        /// <summary>
        /// Name of the team.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Roster of the team.
        /// </summary>
        [JsonPropertyName("roster")]
        public Roster Roster { get; set; }

        /// <summary>
        /// Date when the second last member joined the team..
        /// </summary>
        [JsonPropertyName("secondLastJoinDate")]
        [JsonConverter(typeof(DateTimeConverterFromLong))]
        public DateTime SecondLastJoinDate { get; set; }

        /// <summary>
        /// Status of the team.
        /// </summary>
        [JsonPropertyName("status")]
        public string Status { get; set; }

        /// <summary>
        /// Tag of the team.
        /// </summary>
        [JsonPropertyName("tag")]
        public string Tag { get; set; }

        /// <summary>
        /// Stat summary of the team.
        /// </summary>
        [JsonPropertyName("teamStatDetails")]
        public List<TeamStatDetail> TeamStatDetails { get; set; }

        /// <summary>
        /// Date when the third last member joined the team.
        /// </summary>
        [JsonPropertyName("thirdLastJoinDate")]
        [JsonConverter(typeof(DateTimeConverterFromLong))]
        public DateTime ThirdLastJoinDate { get; set; }
    }
}
