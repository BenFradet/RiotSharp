using Newtonsoft.Json;
using RiotSharp.Endpoints.MatchEndpoint.Enums.Converters;

namespace RiotSharp.Endpoints.MatchEndpoint.Enums
{
    /// <summary>
    /// Type of monster (Match API).
    /// </summary>
    [JsonConverter(typeof(MonsterTypeConverter))]
    public enum MonsterType
    {
        /// <summary>
        /// Corresponds to the baron Nashor.
        /// </summary>
        BaronNashor,

        /// <summary>
        /// Corresponds to the blue golem.
        /// </summary>
        BlueGolem,

        /// <summary>
        /// Corresponds to the dragon.
        /// </summary>
        Dragon,

        /// <summary>
        /// Corresponds to the red lizard.
        /// </summary>
        RedLizard,

        /// <summary>
        /// Corresponds to Vilemaw (on the 3vs3 map).
        /// </summary>
        Vilemaw,

        /// <summary>
        /// Corresponds to Rift Herald.
        /// </summary>
        RiftHerald
    }

    static class MonsterTypeExtension
    {
        public static string ToCustomString(this MonsterType monsterType)
        {
            switch (monsterType)
            {
                case MonsterType.BaronNashor:
                    return "BARON_NASHOR";
                case MonsterType.BlueGolem:
                    return "BLUE_GOLEM";
                case MonsterType.Dragon:
                    return "DRAGON";
                case MonsterType.RedLizard:
                    return "RED_LIZARD";
                case MonsterType.Vilemaw:
                    return "VILEMAW";
                case MonsterType.RiftHerald:
                    return "RIFTHERALD";
                default:
                    return string.Empty;
            }
        }
    }
}
