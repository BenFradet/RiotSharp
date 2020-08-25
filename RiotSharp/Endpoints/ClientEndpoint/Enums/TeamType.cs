using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace RiotSharp.Endpoints.ClientEndpoint.Enums
{
    /// <summary>
    ///     Represents the team in which a <see cref="PlayerList.Player" /> is.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum TeamType
    {
        /// <summary>
        ///     Represents an unknown team.
        /// </summary>
        [EnumMember(Value = "UNKNOWN")]
        Unknown,

        /// <summary>
        ///     Represents the all team.
        /// </summary>
        [EnumMember(Value = "ALL")]
        All,

        /// <summary>
        ///     Represents the neutral team.
        /// </summary>
        [EnumMember(Value = "NEUTRAL")]
        Neutral,

        /// <summary>
        ///     Represents the chaos (red) team.
        /// </summary>
        [EnumMember(Value = "CHAOS")]
        Chaos,

        /// <summary>
        ///     Represents the order (blue) team.
        /// </summary>
        [EnumMember(Value = "ORDER")]
        Order
    }
}