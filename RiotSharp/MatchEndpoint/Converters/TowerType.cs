// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TowerType.cs" company="">
//
// </copyright>
// <summary>
//   Type of tower (Match API).
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace RiotSharp.MatchEndpoint
{
    /// <summary>
    /// Type of tower (Match API).
    /// </summary>
    public enum TowerType
    {
        /// <summary>
        /// Represents inhibitor turrets.
        /// </summary>
        BaseTurret,

        /// <summary>
        /// Represents inner turrets.
        /// </summary>
        InnerTurret,

        /// <summary>
        /// Represents nexus turrets.
        /// </summary>
        NexusTurret,

        /// <summary>
        /// Represents outer turrets.
        /// </summary>
        OuterTurret,

        /// <summary>
        /// Undefined turrets?
        /// </summary>
        UndefinedTurret
    }

    /// <summary>
    /// The tower type extension.
    /// </summary>
    static class TowerTypeExtension
    {
        /// <summary>
        /// The to custom string.
        /// </summary>
        /// <param name="towerType">
        /// The tower type.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public static string ToCustomString(this TowerType towerType)
        {
            switch (towerType)
            {
                case TowerType.BaseTurret:
                    return "BASE_TURRET";
                case TowerType.InnerTurret:
                    return "INNER_TURRET";
                case TowerType.NexusTurret:
                    return "NEXUS_TURRET";
                case TowerType.OuterTurret:
                    return "OUTER_TURRET";
                case TowerType.UndefinedTurret:
                    return "UNDEFINED_TURRET";
                default:
                    return string.Empty;
            }
        }
    }
}
