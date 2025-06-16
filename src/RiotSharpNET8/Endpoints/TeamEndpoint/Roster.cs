using System.Text.Json.Serialization;

namespace RiotSharpNET8.Endpoints.TeamEndpoint
{
    /// <summary>
    /// Roster of the team (Team API).
    /// </summary>
    public class Roster
    {
        /// <summary>
        /// List of the team members of the roster.
        /// </summary>
        [JsonPropertyName("memberList")]
        public List<TeamMemberInfo> MemberList { get; set; }

        /// <summary>
        /// Id of the owner of the team.
        /// </summary>
        [JsonPropertyName("ownerId")]
        public long OwnerId { get; set; }
    }
}
