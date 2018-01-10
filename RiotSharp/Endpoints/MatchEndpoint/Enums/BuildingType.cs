using Newtonsoft.Json;
using RiotSharp.Endpoints.MatchEndpoint.Enums.Converters;

namespace RiotSharp.Endpoints.MatchEndpoint.Enums
{
    /// <summary>
    /// Building type (Match API).
    /// </summary>
    [JsonConverter(typeof(BuildingTypeConverter))]
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

    static class BuildingTypeExtension
    {
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
