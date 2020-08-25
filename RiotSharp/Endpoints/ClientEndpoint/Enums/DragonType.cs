using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace RiotSharp.Endpoints.ClientEndpoint.Enums
{
    /// <summary>
    ///     Represents the different types of dragons that can be killed.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum DragonType
    {
        /// <summary>
        ///     Represents the fire drake.
        /// </summary>
        [EnumMember(Value = "Fire")]
        Fire,

        /// <summary>
        ///     Represents the ocean drake.
        /// </summary>
        [EnumMember(Value = "Water")]
        Ocean,

        /// <summary>
        ///     Represents the wind drake.
        /// </summary>
        [EnumMember(Value = "Air")]
        Wind,

        /// <summary>
        ///     Represents the mountain drake.
        /// </summary>
        [EnumMember(Value = "Earth")]
        Mountain,

        /// <summary>
        ///     Represents the elder drake.
        /// </summary>
        [EnumMember(Value = "Elder")]
        Elder
    }
}