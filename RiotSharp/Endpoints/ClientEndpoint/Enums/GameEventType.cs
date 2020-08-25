using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using RiotSharp.Endpoints.ClientEndpoint.GameEvents;

namespace RiotSharp.Endpoints.ClientEndpoint.Enums
{
    /// <summary>
    ///     Represents the types of game events that can occur.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum GameEventType
    {
        /// <summary>
        ///     Represents the start of the game.
        /// </summary>
        [EnumMember(Value = "GameStart")]
        GameStart,

        /// <summary>
        ///     Represents the spawn of the first wave of minions.
        /// </summary>
        [EnumMember(Value = "MinionsSpawning")]
        MinionsSpawning,

        /// <summary>
        ///     Represents the destruction of the first tower.
        /// </summary>
        [EnumMember(Value = "FirstBrick")]
        FirstTurretKilled,

        /// <summary>
        ///     Represents the destruction of a tower.
        /// </summary>
        [EnumMember(Value = "TurretKilled")]
        TurretKilled,

        /// <summary>
        ///     Represents the destruction of an inhibitor.
        /// </summary>
        [EnumMember(Value = "InhibKilled")]
        InhibitorKilled,

        /// <summary>
        ///     Represents the death of a dragon.
        /// </summary>
        [EnumMember(Value = "DragonKill")]
        DragonKilled,

        /// <summary>
        ///     Represents the death of the rift herald.
        /// </summary>
        [EnumMember(Value = "HeraldKill")]
        HeraldKilled,

        /// <summary>
        ///     Represents the death of the baron.
        /// </summary>
        [EnumMember(Value = "BaronKill")]
        BaronKilled,

        /// <summary>
        ///     Represents the first kill in the game.
        /// </summary>
        [EnumMember(Value = "FirstBlood")]
        FirstBlood,

        /// <summary>
        ///     Represents the death of a champion.
        /// </summary>
        [EnumMember(Value = "ChampionKill")]
        ChampionKilled,

        /// <summary>
        ///     Represents a multi kill.
        /// </summary>
        [EnumMember(Value = "MultiKill")]
        MultiKill,

        /// <summary>
        ///     Represents the death of an entire team.
        /// </summary>
        [EnumMember(Value = "Ace")]
        Aced,

        /// <summary>
        ///     Represents the end of the game.
        /// </summary>
        [EnumMember(Value = "GameEnd")]
        GameEnd
    }

    internal static class GameEventTypeExtensions
    {
        private static readonly Dictionary<GameEventType, Func<GameEvent>> EventFactory = new Dictionary<GameEventType, Func<GameEvent>>
                                                                                          {
                                                                                              {GameEventType.GameStart, () => new GameStartedEvent()},
                                                                                              {GameEventType.MinionsSpawning, () => new MinionsSpawningEvent()},
                                                                                              {
                                                                                                  GameEventType.FirstTurretKilled,
                                                                                                  () => new FirstTurretKilledEvent()
                                                                                              },
                                                                                              {GameEventType.TurretKilled, () => new TurretKilledEvent()},
                                                                                              {GameEventType.InhibitorKilled, () => new InhibitorKilledEvent()},
                                                                                              {GameEventType.DragonKilled, () => new DragonKilledEvent()},
                                                                                              {GameEventType.HeraldKilled, () => new HeraldKilledEvent()},
                                                                                              {GameEventType.BaronKilled, () => new BaronKilledEvent()},
                                                                                              {GameEventType.FirstBlood, () => new FirstBloodEvent()},
                                                                                              {GameEventType.ChampionKilled, () => new ChampionKilledEvent()},
                                                                                              {GameEventType.MultiKill, () => new MultiKillEvent()},
                                                                                              {GameEventType.Aced, () => new AcedEvent()},
                                                                                              {GameEventType.GameEnd, () => new GameEndEvent()}
                                                                                          };

        public static GameEvent CreateGameEvent(this GameEventType thisGameEventType)
        {
            if (!EventFactory.TryGetValue(thisGameEventType, out var eventConstructor))
            {
                throw new Exception($"Unknown {nameof(GameEventType)} \"{thisGameEventType}\"!");
            }

            return eventConstructor();
        }
    }
}