// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TeamMemberInfo.cs" company="">
//
// </copyright>
// <summary>
//   Information about team members (Team API).
// </summary>
// --------------------------------------------------------------------------------------------------------------------

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
        /// <summary>
        /// Initializes a new instance of the <see cref="TeamMemberInfo"/> class.
        /// </summary>
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
