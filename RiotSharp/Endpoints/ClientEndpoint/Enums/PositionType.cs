using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace RiotSharp.Endpoints.ClientEndpoint.Enums
{
    /// <summary>
    ///     Represents the position a <see cref="PlayerList.Player" /> has been assigned to.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum PositionType
    {
        /// <summary>
        ///     Represents no specific assignment (e.g. in blind pick mode).
        /// </summary>
        [EnumMember(Value = "")]
        Unknown,

        /// <summary>
        ///     Represents the top lange position.
        /// </summary>
        [EnumMember(Value = "TOP")]
        Top,

        /// <summary>
        ///     Represents the mid lane position.
        /// </summary>
        [EnumMember(Value = "MIDDLE")]
        Middle,

        /// <summary>
        ///     Represents the bottom carry position (e.g. ad carry).
        /// </summary>
        [EnumMember(Value = "BOTTOM")]
        Bottom,

        /// <summary>
        ///     Represents the bottom support position.
        /// </summary>
        [EnumMember(Value = "UTILITY")]
        Support,

        /// <summary>
        ///     Represents the jungle position.
        /// </summary>
        [EnumMember(Value = "JUNGLE")]
        Jungle
    }
}