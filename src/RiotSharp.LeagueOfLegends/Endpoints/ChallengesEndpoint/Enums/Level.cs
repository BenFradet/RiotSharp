using RiotSharp.LeagueOfLegends.Endpoints.ChallengesEndpoint.Enums.Converters;
using RiotSharp.LeagueOfLegends.Endpoints.ClashEndpoint.Enums;
using RiotSharp.LeagueOfLegends.Endpoints.ClashEndpoint.Enums.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RiotSharp.LeagueOfLegends.Endpoints.ChallengesEndpoint.Enums
{
    /// <summary>
    /// Enum Representing Challenge Levels
    /// </summary>
    [JsonConverter(typeof(LevelConverter))]
    public enum Level
    {
        None,

        Iron,

        Bronze,

        Silver,

        Gold,

        Platinum,

        Diamond,

        Master,

        Grandmaster,

        Challenger,

        HighestNotLeaderboardOnly,

        Highest,

        Lowest
    }

    static class LevelExtension
    {
        public static string ToCustomString(this Level level)
        {
            switch (level)
            {
                case Level.None:
                    return "NONE";
                case Level.Iron:
                    return "IRON";
                case Level.Bronze:
                    return "BRONZE";
                case Level.Silver:
                    return "SILVER";
                case Level.Gold:
                    return "GOLD";
                case Level.Platinum:
                    return "PLATINUM";
                case Level.Diamond:
                    return "DIAMOND";
                case Level.Master:
                    return "MASTER";
                case Level.Grandmaster:
                    return "GRANDMASTER";
                case Level.Challenger:
                    return "CHALLENGER";
                case Level.HighestNotLeaderboardOnly:
                    return "HIGHEST_NOT_LEADERBOARD_ONLY";
                case Level.Highest:
                    return "HIGHEST";
                case Level.Lowest:
                    return "LOWEST";
                default:
                    return string.Empty;
            }
        }
    }
}

