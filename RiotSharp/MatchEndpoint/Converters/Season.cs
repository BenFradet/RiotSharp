namespace RiotSharp.MatchEndpoint
{
    /// <summary>
    /// Season (Match API).
    /// </summary>
    public enum Season
    {
        /// <summary>
        /// Pre season 3.
        /// </summary>
        PreSeason3,

        /// <summary>
        /// Season 3.
        /// </summary>
        Season3,

        /// <summary>
        /// Pre season 2014.
        /// </summary>
        PreSeason2014,

        /// <summary>
        /// Season 2014
        /// </summary>
        Season2014,

        /// <summary>
        /// Pre season 2015.
        /// </summary>
        PreSeason2015,

        /// <summary>
        /// Season 2015
        /// </summary>
        Season2015
    }

    static class SeasonExtension
    {
        public static string ToCustomString(this Season season)
        {
            switch (season)
            {
                case Season.PreSeason3:
                    return "PRESEASON3";
                    break;
                case Season.Season3:
                    return "SEASON3";
                    break;
                case Season.PreSeason2014:
                    return "PRESEASON2014";
                    break;
                case Season.Season2014:
                    return "SEASON2014";
                    break;
                case Season.PreSeason2015:
                    return "PRESEASON2015";
                    break;
                case Season.Season2015:
                    return "PRESEASON";
                    break;
                default:
                    return string.Empty;
                    break;
            }
        }
    }
}
