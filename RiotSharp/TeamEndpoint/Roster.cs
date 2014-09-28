// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Roster.cs" company="">
//   
// </copyright>
// <summary>
//   Roster of the team (Team API).
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;

using Newtonsoft.Json;

namespace RiotSharp.TeamEndpoint
{
    /// <summary>
    /// Roster of the team (Team API).
    /// </summary>
    [Serializable]
    public class Roster
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Roster"/> class.
        /// </summary>
        internal Roster() { }

        /// <summary>
        /// List of the team members of the roster.
        /// </summary>
        [JsonProperty("memberList")]
        public List<TeamMemberInfo> MemberList { get; set; }

        /// <summary>
        /// Id of the owner of the team.
        /// </summary>
        [JsonProperty("ownerId")]
        public long OwnerId { get; set; }
    }
}
