using Newtonsoft.Json;
using RiotSharp.MatchEndpoint.Enums.Converters;

namespace RiotSharp.MatchEndpoint.Enums
{
    /// <summary>
    /// Type of monster (Match API).
    /// </summary>
    [JsonConverter(typeof(MonsterSubTypeConverter))]
    public enum MonsterSubType
    {
        /// <summary>
        /// Corresponds to the cloud drake.
        /// </summary>
        AirDragon,

        /// <summary>
        /// Corresponds to the ocean drake.
        /// </summary>
        WaterDragon,

        /// <summary>
        /// Corresponds to the mountain drake.
        /// </summary>
        EarthDragon,

        /// <summary>
        /// Corresponds to the infernal drake.
        /// </summary>
        FireDragon,

        /// <summary>
        /// Corresponds to the elder dragon.
        /// </summary>
        ElderDragon
    }

    static class MonsterSubTypeExtension
    {
        public static string ToCustomString(this MonsterSubType MonsterSubType)
        {
            switch (MonsterSubType)
            {
                case MonsterSubType.AirDragon:
                    return "AIR_DRAGON";
                case MonsterSubType.WaterDragon:
                    return "WATER_DRAGON";
                case MonsterSubType.EarthDragon:
                    return "EARTH_DRAGON";
                case MonsterSubType.FireDragon:
                    return "FIRE_DRAGON";
                case MonsterSubType.ElderDragon:
                    return "ELDER_DRAGON";
                default:
                    return string.Empty;
            }
        }
    }
}
