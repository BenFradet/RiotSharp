// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MonsterType.cs" company="">
//
// </copyright>
// <summary>
//   Type of monster (Match API).
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace RiotSharp.MatchEndpoint
{
    /// <summary>
    /// Type of monster (Match API).
    /// </summary>
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
        Vilemaw
    }

    /// <summary>
    /// The monster type extension.
    /// </summary>
    static class MonsterTypeExtension
    {
        /// <summary>
        /// The to custom string.
        /// </summary>
        /// <param name="monsterType">
        /// The monster type.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
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
                default:
                    return string.Empty;
            }
        }
    }
}
