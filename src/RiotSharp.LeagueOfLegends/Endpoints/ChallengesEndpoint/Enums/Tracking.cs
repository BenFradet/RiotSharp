using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using RiotSharp.LeagueOfLegends.Endpoints.ChallengesEndpoint.Enums.Converters;

namespace RiotSharp.LeagueOfLegends.Endpoints.ChallengesEndpoint.Enums
{
    /// <summary>
    /// Enum representing challenge tracking types
    /// </summary>
    [JsonConverter(typeof(TrackingConverter))]
    public enum Tracking
    {
        /// <summary>
        /// Stats are incremented without reset
        /// </summary>
        Lifetime,

        /// <summary>
        /// Stats are accumulated by season and reset at the beginning of new season
        /// </summary>
        Season
    }

    static class TrackingExtension
    {
        public static string ToCustomString(this Tracking tracking)
        {
            switch (tracking)
            {
                case Tracking.Lifetime:
                    return "LIFETIME";
                case Tracking.Season:
                    return "SEASON";
                default:
                    return string.Empty;
            }
        }
    }
}
