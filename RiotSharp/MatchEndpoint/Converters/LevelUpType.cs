// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LevelUpType.cs" company="">
//
// </copyright>
// <summary>
//   Type of level up (Match API).
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace RiotSharp.MatchEndpoint
{
    /// <summary>
    /// Type of level up (Match API).
    /// </summary>
    public enum LevelUpType
    {
        /// <summary>
        /// When leveling up involves evolving (notably Kha'zix).
        /// </summary>
        Evolve,

        /// <summary>
        /// Normal leveling up.
        /// </summary>
        Normal
    }

    /// <summary>
    /// The level up type extension.
    /// </summary>
    static class LevelUpTypeExtension
    {
        /// <summary>
        /// The to custom string.
        /// </summary>
        /// <param name="levelUpType">
        /// The level up type.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public static string ToCustomString(this LevelUpType levelUpType)
        {
            switch (levelUpType)
            {
                case LevelUpType.Evolve:
                    return "EVOLVE";
                case LevelUpType.Normal:
                    return "NORMAL";
                default:
                    return string.Empty;
            }
        }
    }
}
