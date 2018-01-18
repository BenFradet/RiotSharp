﻿using Newtonsoft.Json;
using RiotSharp.Endpoints.MatchEndpoint.Enums.Converters;

namespace RiotSharp.Endpoints.MatchEndpoint.Enums
{
    /// <summary>
    /// Type of level up (Match API).
    /// </summary>
    [JsonConverter(typeof(LevelUpTypeConverter))]
    public enum LevelUpType
    {
        /// <summary>
        /// When leveling up involves evolving (notably Kha'zix).
        /// </summary>
        Evolve,

        /// <summary>
        /// Normal leveling up.
        /// </summary>
        Normal
    }

    static class LevelUpTypeExtension
    {
        public static string ToCustomString(this LevelUpType levelUpType)
        {
            switch (levelUpType)
            {
                case LevelUpType.Evolve:
                    return "EVOLVE";
                case LevelUpType.Normal:
                    return "NORMAL";
                default:
                    return string.Empty;
            }
        }
    }
}
