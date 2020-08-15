using System.Runtime.Serialization;

namespace RiotSharp.Endpoints.ClientEndpoint.Enums
{
    public enum GameEventType
    {
        [EnumMember(Value = "GameStart")]
        GameStart,
        
        [EnumMember(Value = "MinionsSpawning")]
        MinionsSpawning,
        
        [EnumMember(Value = "FirstBrick")]
        FirstTower,
        
        [EnumMember(Value = "TurretKilled")]
        TurretKilled,
        
        [EnumMember(Value = "InhibKilled")]
        InhibitorKilled,
        
        [EnumMember(Value = "DragonKill")]
        DragonKilled,
        
        [EnumMember(Value = "HeraldKill")]
        HeraldKilled,
        
        [EnumMember(Value = "BaronKill")]
        BaronKilled,
        
        [EnumMember(Value = "ChampionKill")]
        ChampionKilled,
        
        [EnumMember(Value = "MultiKill")]
        MultiKill,
        
        [EnumMember(Value = "Ace")]
        Aced,
    }
}