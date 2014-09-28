// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CapturePoint.cs" company="">
//
// </copyright>
// <summary>
//   Class representing a capture point in a dominion game (Match API).
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace RiotSharp.MatchEndpoint
{
    /// <summary>
    /// Class representing a capture point in a dominion game (Match API).
    /// </summary>
    public enum CapturePoint
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

    /// <summary>
    /// The capture point extension.
    /// </summary>
    static class CapturePointExtension
    {
        /// <summary>
        /// The to custom string.
        /// </summary>
        /// <param name="capturePoint">
        /// The capture point.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public static string ToCustomString(this CapturePoint capturePoint)
        {
            switch (capturePoint)
            {
                case CapturePoint.PointA:
                    return "POINT_A";
                case CapturePoint.PointB:
                    return "POINT_B";
                case CapturePoint.PointC:
                    return "POINT_C";
                case CapturePoint.PointD:
                    return "POINT_D";
                case CapturePoint.PointE:
                    return "POINT_E";
                default:
                    return string.Empty;
            }
        }
    }
}
