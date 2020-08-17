using System.Runtime.Serialization;

namespace RiotSharp.Endpoints.ClientEndpoint.Enums
{
    public enum ResourceType
    {
        [EnumMember(Value = "NONE")]
        None,
        
        [EnumMember(Value = "MANA")]
        Mana,
        
        [EnumMember(Value = "ENERGY")]
        Energy,
        
        [EnumMember(Value = "SHIELD")]
        Shield,
        
        [EnumMember(Value = "BATTLEFURY")]
        BattleFury,
        
        [EnumMember(Value = "DRAGONFURY")]
        DragonFury,
        
        [EnumMember(Value = "RAGE")]
        Rage,
        
        [EnumMember(Value = "HEAT")]
        Heat,
        
        [EnumMember(Value = "GNARFURY")]
        GnarFury,
        
        [EnumMember(Value = "FEROCITY")]
        Ferocity,
        
        [EnumMember(Value = "BLOODWELL")]
        BloodWell,
        
        [EnumMember(Value = "WIND")]
        Wind,
        
        [EnumMember(Value = "AMMO")]
        Ammo,
        
        [EnumMember(Value = "OTHER")]
        Other,
        
        [EnumMember(Value = "MAX")]
        Max,
    }
}