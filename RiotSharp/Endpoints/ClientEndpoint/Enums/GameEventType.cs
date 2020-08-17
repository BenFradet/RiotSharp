using System.Runtime.Serialization;

namespace RiotSharp.Endpoints.ClientEndpoint.Enums
{
    /// <summary>
    /// Represents the types of game events that can occur.
    /// </summary>
    public enum GameEventType
    {
        /// <summary>
        /// Represents the start of the game.
        /// </summary>
        [EnumMember(Value = "GameStart")]
        GameStart,

        /// <summary>
        /// Represents the spawn of the first wave of minions.
        /// </summary>
        [EnumMember(Value = "MinionsSpawning")]
        MinionsSpawning,

        /// <summary>
        /// Represents the destruction of the first tower.
        /// </summary>
        [EnumMember(Value = "FirstBrick")]
        FirstTurretKilled,

        /// <summary>
        /// Represents the destruction of a tower.
        /// </summary>
        [EnumMember(Value = "TurretKilled")]
        TurretKilled,

        /// <summary>
        /// Represents the destruction of an inhibitor.
        /// </summary>
        [EnumMember(Value = "InhibKilled")]
        InhibitorKilled,

        /// <summary>
        /// Represents the death of a dragon.
        /// </summary>
        [EnumMember(Value = "DragonKill")]
        DragonKilled,
        
        /// <summary>
        /// Represents the death of the rift herald.
        /// </summary>
        [EnumMember(Value = "HeraldKill")]
        HeraldKilled,

        /// <summary>
        /// Represents the death of the baron.
        /// </summary>
        [EnumMember(Value = "BaronKill")]
        BaronKilled,

        /// <summary>
        /// Represents the first kill in the game.
        /// </summary>
        [EnumMember(Value = "FirstBlood")]
        FirstBlood,

        /// <summary>
        /// Represents the death of a champion.
        /// </summary>
        [EnumMember(Value = "ChampionKill")]
        ChampionKilled,

        /// <summary>
        /// Represents a multi kill.
        /// </summary>
        [EnumMember(Value = "MultiKill")]
        MultiKill,

        /// <summary>
        /// Represents the death of an entire team.
        /// </summary>
        [EnumMember(Value = "Ace")]
        Aced
    }
}