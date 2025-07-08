using System.Text.Json.Serialization;
using RiotSharp.LeagueOfLegends.Endpoints.ClashEndpoint.Enums.Converters;

namespace RiotSharp.LeagueOfLegends.Endpoints.ClashEndpoint.Enums
{
    /// <summary>
    /// Enum specifying summoner's hierarchical role in a clash.
    /// Basically this value holds an information about user being a
    /// captain of a clash team or not.
    /// </summary>
    [JsonConverter(typeof(ClashRoleConverter))]
    public enum ClashRole
    {
        /// <summary>
        /// Clash team captain
        /// </summary>
        Captain,
        
        /// <summary>
        /// Clash team Member
        /// </summary>
        Member
    }

    static class ClashRoleExtension
    {
        public static string ToCustomString(this ClashRole roleType)
        {
            switch (roleType)
            {
                case ClashRole.Captain:
                    return "CAPTAIN";
                case ClashRole.Member:
                    return "MEMBER";
                default:
                    return string.Empty;
            }
        }
    }
}