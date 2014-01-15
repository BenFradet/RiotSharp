using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace RiotSharp
{
    /// <summary>
    /// Roster of the team (Team API).
    /// </summary>
    public class Roster : Thing
    {
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
