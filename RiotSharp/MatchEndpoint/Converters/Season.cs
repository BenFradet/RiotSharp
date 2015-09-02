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
                case Season.Season3:
                    return "SEASON3";
                case Season.PreSeason2014:
                    return "PRESEASON2014";
                case Season.Season2014:
                    return "SEASON2014";
                case Season.PreSeason2015:
                    return "PRESEASON2015";
                case Season.Season2015:
                    return "SEASON2015";
                default:
                    return string.Empty;
            }
        }
    }
}
