// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Queue.cs" company="">
//   
// </copyright>
// <summary>
//   Queue of the league (League API).
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace RiotSharp
{
    /// <summary>
    /// Queue of the league (League API).
    /// </summary>
    public enum Queue
    {
        /// <summary>
        /// Solo queue 5 vs 5.
        /// </summary>
        RankedSolo5x5, 

        /// <summary>
        /// Team 3 vs 3.
        /// </summary>
        RankedTeam3x3, 

        /// <summary>
        /// Team 5 vs 5.
        /// </summary>
        RankedTeam5x5
    }

    /// <summary>
    /// The queue extension.
    /// </summary>
    static class QueueExtension
    {
        /// <summary>
        /// The to custom string.
        /// </summary>
        /// <param name="queue">
        /// The queue.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public static string ToCustomString(this Queue queue)
        {
            switch (queue)
            {
                case Queue.RankedSolo5x5:
                    return "RANKED_SOLO_5x5";
                case Queue.RankedTeam3x3:
                    return "RANKED_TEAM_3x3";
                case Queue.RankedTeam5x5:
                    return "RANKED_TEAM_5x5";
                default:
                    return string.Empty;
            }
        }
    }
}
