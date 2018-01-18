using Newtonsoft.Json;
using RiotSharp.Endpoints.MatchEndpoint.Enums.Converters;

namespace RiotSharp.Endpoints.MatchEndpoint.Enums
{
    /// <summary>
    /// Type of the ward (Match API).
    /// </summary>
    [JsonConverter(typeof(WardTypeConverter))]
    public enum WardType
    {
        /// <summary>
        /// Corresponds to green wards.
        /// </summary>
        SightWard,

        /// <summary>
        /// Corresponds to Teemo's mushrooms.
        /// </summary>
        TeemoMushroom,

        /// <summary>
        /// Undefined.
        /// </summary>
        Undefined,

        /// <summary>
        /// Corresponds to pink wards.
        /// </summary>
        VisionWard,

        /// <summary>
        /// Corresponds to warding totems.
        /// </summary>
        YellowTrinket,

        /// <summary>
        /// Corresponds to upgraded warding totems.
        /// </summary>
        YellowTrinketUpgrade,

        /// <summary>
        /// Corresponds to a blue trinket.
        /// </summary>
        BlueTrinket
    }

    static class WardTypeExtension
    {
        public static string ToCustomString(this WardType wardType)
        {
            switch (wardType)
            {
                case WardType.SightWard:
                    return "SIGHT_WARD";
                case WardType.TeemoMushroom:
                    return "TEEMO_MUSHROOM";
                case WardType.Undefined:
                    return "UNDEFINED";
                case WardType.VisionWard:
                    return "VISION_WARD";
                case WardType.YellowTrinket:
                    return "YELLOW_TRINKET";
                case WardType.YellowTrinketUpgrade:
                    return "YELLOW_TRINKET_UPGRADE";
                case WardType.BlueTrinket:
                    return "BLUE_TRINKET";
                default:
                    return string.Empty;
            }
        }
    }
}
