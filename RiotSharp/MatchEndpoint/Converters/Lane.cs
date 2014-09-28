// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Lane.cs" company="">
//   
// </copyright>
// <summary>
//   Participant's lane (Match API).
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace RiotSharp.MatchEndpoint
{
    /// <summary>
    /// Participant's lane (Match API).
    /// </summary>
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
        Bottom
    }

    /// <summary>
    /// The lane extension.
    /// </summary>
    static class LaneExtension
    {
        /// <summary>
        /// The to custom string.
        /// </summary>
        /// <param name="lane">
        /// The lane.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
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
                default:
                    return string.Empty;
            }
        }
    }
}
