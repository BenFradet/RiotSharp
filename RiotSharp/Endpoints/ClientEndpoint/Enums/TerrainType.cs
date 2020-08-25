using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace RiotSharp.Endpoints.ClientEndpoint.Enums
{
    /// <summary>
    ///     Represents the current terrain of the map.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum TerrainType
    {
        /// <summary>
        ///     Represents the default terrain.
        /// </summary>
        [EnumMember(Value = "Default")]
        Default,

        /// <summary>
        ///     Represents the fire map.
        /// </summary>
        [EnumMember(Value = "Fire")]
        Fire,

        /// <summary>
        ///     Represents the ocean map.
        /// </summary>
        [EnumMember(Value = "Water")]
        Ocean,

        /// <summary>
        ///     Represents the wind map.
        /// </summary>
        [EnumMember(Value = "Air")]
        Wind,

        /// <summary>
        ///     Represents the mountain map.
        /// </summary>
        [EnumMember(Value = "Mountain")]
        Mountain
    }
}