// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LaneType.cs" company="">
//
// </copyright>
// <summary>
//   Lane's type (Match API).
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace RiotSharp.MatchEndpoint
{
    /// <summary>
    /// Lane's type (Match API).
    /// </summary>
    public enum LaneType
    {
        /// <summary>
        /// Corresponds to the bot lane.
        /// </summary>
        BotLane,

        /// <summary>
        /// Corresponds to the mid lane.
        /// </summary>
        MidLane,

        /// <summary>
        /// Corresponds to the top lane.
        /// </summary>
        TopLane
    }

    /// <summary>
    /// The lane type extension.
    /// </summary>
    static class LaneTypeExtension
    {
        /// <summary>
        /// The to custom string.
        /// </summary>
        /// <param name="laneType">
        /// The lane type.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public static string ToCustomString(this LaneType laneType)
        {
            switch (laneType)
            {
                case LaneType.BotLane:
                    return "BOT_LANE";
                case LaneType.MidLane:
                    return "MID_LANE";
                case LaneType.TopLane:
                    return "TOP_LANE";
                default:
                    return string.Empty;
            }
        }
    }
}
