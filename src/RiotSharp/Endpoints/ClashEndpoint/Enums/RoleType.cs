using Newtonsoft.Json;
using RiotSharp.Endpoints.ClashEndpoint.Enums.Converters;

namespace RiotSharp.Endpoints.ClashEndpoint.Enums
{
    /// <summary>
    /// Enum specifying summoner's hierarchical role in a clash.
    /// Basically this value holds an information about user being a
    /// captain of a clash team or not.
    /// </summary>
    [JsonConverter(typeof(RoleTypeConverter))]
    public enum RoleType
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

    static class RoleTypeExtension
    {
        public static string ToCustomString(this RoleType roleType)
        {
            switch (roleType)
            {
                case RoleType.Captain:
                    return "CAPTAIN";
                case RoleType.Member:
                    return "MEMBER";
                default:
                    return string.Empty;
            }
        }
    }
}