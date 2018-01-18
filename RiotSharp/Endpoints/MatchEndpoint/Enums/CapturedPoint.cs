using Newtonsoft.Json;
using RiotSharp.Endpoints.MatchEndpoint.Enums.Converters;

namespace RiotSharp.Endpoints.MatchEndpoint.Enums
{
    /// <summary>
    /// Class representing a capture point in a dominion game (Match API).
    /// </summary>
    [JsonConverter(typeof(CapturedPointConverter))]
    public enum CapturedPoint
    {
        /// <summary>
        /// Point A.
        /// </summary>
        PointA,

        /// <summary>
        /// Point B.
        /// </summary>
        PointB,

        /// <summary>
        /// Point C.
        /// </summary>
        PointC,

        /// <summary>
        /// Point D.
        /// </summary>
        PointD,

        /// <summary>
        /// Point E.
        /// </summary>
        PointE
    }

    static class CapturedPointExtension
    {
        public static string ToCustomString(this CapturedPoint capturePoint)
        {
            switch (capturePoint)
            {
                case CapturedPoint.PointA:
                    return "POINT_A";
                case CapturedPoint.PointB:
                    return "POINT_B";
                case CapturedPoint.PointC:
                    return "POINT_C";
                case CapturedPoint.PointD:
                    return "POINT_D";
                case CapturedPoint.PointE:
                    return "POINT_E";
                default:
                    return string.Empty;
            }
        }
    }
}
