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

    static class LaneTypeExtension
    {
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
