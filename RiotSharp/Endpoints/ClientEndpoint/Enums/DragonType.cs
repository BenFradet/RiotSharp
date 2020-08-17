using System.Runtime.Serialization;

namespace RiotSharp.Endpoints.ClientEndpoint.Enums
{
    /// <summary>
    /// Represents the different types of dragons that can be killed.
    /// </summary>
    public enum DragonType
    {
        /// <summary>
        /// Represents the fire drake.
        /// </summary>
        [EnumMember(Value = "Fire")]
        Fire,

        /// <summary>
        /// Represents the ocean drake.
        /// </summary>
        [EnumMember(Value = "Water")]
        Ocean,

        /// <summary>
        /// Represents the wind drake.
        /// </summary>
        [EnumMember(Value = "Wind")]
        Wind,

        /// <summary>
        /// Represents the earth drake.
        /// </summary>
        [EnumMember(Value = "Earth")]
        Earth,

        /// <summary>
        /// Represents the elder drake.
        /// </summary>
        [EnumMember(Value = "Elder")]
        Elder
    }
}