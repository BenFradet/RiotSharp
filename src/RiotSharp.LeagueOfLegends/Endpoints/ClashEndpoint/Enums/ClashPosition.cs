using System.Text.Json.Serialization;
using RiotSharp.LeagueOfLegends.Endpoints.ClashEndpoint.Enums.Converters;

namespace RiotSharp.LeagueOfLegends.Endpoints.ClashEndpoint.Enums
{
    /// <summary>
    /// Enum Representing Position types in a Clash Game
    /// </summary>
    [JsonConverter(typeof(ClashPositionConverter))]
    public enum ClashPosition
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

    static class ClashPositionExtension
    {
        public static string ToCustomString(this ClashPosition positionType)
        {
            switch (positionType)
            {
                case ClashPosition.Unselected:
                    return "UNSELECTED";
                case ClashPosition.Fill:
                    return "FILL";
                case ClashPosition.Top:
                    return "TOP";
                case ClashPosition.Jungle:
                    return "JUNGLE";
                case ClashPosition.Middle:
                    return "MIDDLE";
                case ClashPosition.Bottom:
                    return "BOTTOM";
                case ClashPosition.Utility:
                    return "UTILITY";
                default:
                    return string.Empty;
            }
        }
    }
}