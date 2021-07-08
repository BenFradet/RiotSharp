using System;
using System.Collections.Generic;
using System.Text;

namespace RiotSharp.Endpoints.MatchEndpoint.Enums
{
    /// <summary>
    /// Type of a game for filtering porpuses (Match Api - Matches By Puuid)
    /// </summary>
    public enum MatchFilterType
    {
        /// <summary>
        /// Filter for ranked games
        /// </summary>
        Ranked,
        /// <summary>
        /// Filter for normal games
        /// </summary>
        Normal,
        /// <summary>
        /// Filter for tournament games
        /// </summary>
        Tourney,
        /// <summary>
        /// Filter for tutorial games
        /// </summary>
        Tutorial
    }

    static class MatchFilterTypeExtension
    {
        public static string ToCustomString(this MatchFilterType matchFilterType)
        {
            switch (matchFilterType)
            {
                case MatchFilterType.Normal:
                    return "normal";
                case MatchFilterType.Ranked:
                    return "ranked";
                case MatchFilterType.Tourney:
                    return "tourney";
                case MatchFilterType.Tutorial:
                    return "tourney";
                default:
                    return string.Empty;
            }
        }
    }
}
