using System.Runtime.Serialization;

namespace RiotSharp.Endpoints.ClientEndpoint.Enums
{
    public enum TeamType
    {
        [EnumMember(Value = "UNKNOWN")]
        Unknown,

        [EnumMember(Value = "ALL")]
        All,

        [EnumMember(Value = "NEUTRAL")]
        Neutral,

        [EnumMember(Value = "CHAOS")]
        Chaos,

        [EnumMember(Value = "ORDER")]
        Order
    }
}