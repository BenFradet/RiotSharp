using System;
using Newtonsoft.Json;

namespace RiotSharp.TeamEndpoint
{
    /// <summary>
    /// Information about team members (Team API).
    /// </summary>
    [Serializable]
    public class TeamMemberInfo
    {
        internal TeamMemberInfo() { }

        /// <summary>
        /// Date this team member was invited.
        /// </summary>
        [JsonProperty("inviteDate")]
        [JsonConverter(typeof(DateTimeConverterFromLong))]
        public DateTime InviteDate { get; set; }

        /// <summary>
        /// Date this team member joined the team.
        /// </summary>
        [JsonProperty("joinDate")]
        [JsonConverter(typeof(DateTimeConverterFromLong))]
        public DateTime JoinDate { get; set; }

        /// <summary>
        /// Id of the team member.
        /// </summary>
        [JsonProperty("playerId")]
        public long PlayerId { get; set; }

        /// <summary>
        /// Status of the team member (owner, member, etc).
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; set; }
    }
}
