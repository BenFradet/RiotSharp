using System.Runtime.Serialization;

namespace RiotSharp.Endpoints.ClientEndpoint.Enums
{
    public enum TerrainType
    {
        [EnumMember(Value = "Default")]
        Default,

        [EnumMember(Value = "Fire")]
        Fire,

        [EnumMember(Value = "Water")]
        Water,

        [EnumMember(Value = "Wind")]
        Wind,

        [EnumMember(Value = "Earth")]
        Earth
    }
}