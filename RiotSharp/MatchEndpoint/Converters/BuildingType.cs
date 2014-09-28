// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BuildingType.cs" company="">
//   
// </copyright>
// <summary>
//   Building type (Match API).
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace RiotSharp.MatchEndpoint
{
    /// <summary>
    /// Building type (Match API).
    /// </summary>
    public enum BuildingType
    {
        /// <summary>
        /// Inhibitors.
        /// </summary>
        InhibitorBuilding, 

        /// <summary>
        /// Towers.
        /// </summary>
        TowerBuilding
    }

    /// <summary>
    /// The building type extension.
    /// </summary>
    static class BuildingTypeExtension
    {
        /// <summary>
        /// The to custom string.
        /// </summary>
        /// <param name="buildingType">
        /// The building type.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public static string ToCustomString(this BuildingType buildingType)
        {
            switch (buildingType)
            {
                case BuildingType.InhibitorBuilding:
                    return "INHIBITOR_BUILDING";
                case BuildingType.TowerBuilding:
                    return "TOWER_BUILDING";
                default:
                    return string.Empty;
            }
        }
    }
}
