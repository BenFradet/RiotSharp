using Newtonsoft.Json;
using RiotSharp.Misc.Converters;

namespace RiotSharp.Misc
{
    /// <summary>
    /// Participant's lane (Match API).
    /// </summary>
    [JsonConverter(typeof(LaneConverter))]
    public enum Lane
    {
        /// <summary>
        /// Corresponds to mid lane.
        /// </summary>
        Mid,

        /// <summary>
        /// Corresponds to mid lane.
        /// </summary>
        Middle,

        /// <summary>
        /// Corresponds to top lane.
        /// </summary>
        Top,

        /// <summary>
        /// Corresponds to jungle.
        /// </summary>
        Jungle,

        /// <summary>
        /// Corresponds to bot lane.
        /// </summary>
        Bot,

        /// <summary>
        /// Corresponds to bot lane.
        /// </summary>
        Bottom,

        /// <summary>
        /// Corresponds to ARAM lane.
        /// </summary>
        None
    }

    static class LaneExtension
    {
        public static string ToCustomString(this Lane lane)
        {
            switch (lane)
            {
                case Lane.Bot:
                    return "BOT";
                case Lane.Bottom:
                    return "BOTTOM";
                case Lane.Jungle:
                    return "JUNGLE";
                case Lane.Mid:
                    return "MID";
                case Lane.Middle:
                    return "MIDDLE";
                case Lane.Top:
                    return "TOP";
                case Lane.None:
                    return "NONE";
                default:
                    return string.Empty;
            }
        }
    }
}
