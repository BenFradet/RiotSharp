using System.Runtime.Serialization;

namespace RiotSharp.Endpoints.ClientEndpoint.Enums
{
    public enum PositionType
    {
        [EnumMember(Value = "")]
        Unknown,

        [EnumMember(Value = "TOP")]
        Top,

        [EnumMember(Value = "MIDDLE")]
        Middle,

        [EnumMember(Value = "BOTTOM")]
        Bottom,

        [EnumMember(Value = "SUPPORT")]
        Support,

        [EnumMember(Value = "JUNGLE")]
        Jungle
    }
}