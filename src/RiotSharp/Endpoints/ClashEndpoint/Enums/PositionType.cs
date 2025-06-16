using Newtonsoft.Json;
using RiotSharp.Endpoints.ClashEndpoint.Enums.Converters;

namespace RiotSharp.Endpoints.ClashEndpoint.Enums
{
    /// <summary>
    /// Enum Representing Position types in a Clash Game
    /// </summary>
    [JsonConverter(typeof(PositionTypeConverter))]
    public enum PositionType
    {
        /// <summary>
        /// Player Hasn't Specified His/Her position yet
        /// </summary>
        Unselected,
        
        /// <summary>
        /// Fill position
        /// </summary>
        Fill,
        
        /// <summary>
        /// position Top lane
        /// </summary>
        Top,
        
        /// <summary>
        /// position Jungle
        /// </summary>
        Jungle,
        
        /// <summary>
        /// position Mid lane
        /// </summary>
        Middle,
        
        /// <summary>
        /// position Bot/Marksman/ADC
        /// </summary>
        Bottom,
        
        /// <summary>
        /// position Utility/Support
        /// </summary>
        Utility,
    }

    static class PositionTypeExtension
    {
        public static string ToCustomString(this PositionType positionType)
        {
            switch (positionType)
            {
                case PositionType.Unselected:
                    return "UNSELECTED";
                case PositionType.Fill:
                    return "FILL";
                case PositionType.Top:
                    return "TOP";
                case PositionType.Jungle:
                    return "JUNGLE";
                case PositionType.Middle:
                    return "MIDDLE";
                case PositionType.Bottom:
                    return "BOTTOM";
                case PositionType.Utility:
                    return "UTILITY";
                default:
                    return string.Empty;
            }
        }
    }
}