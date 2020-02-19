using Newtonsoft.Json;
using RiotSharp.Misc.Converters;

namespace RiotSharp.Misc
{
    /// <summary>
    /// Platform for the API.
    /// </summary>
    [JsonConverter(typeof(PlatformConverter))]
    public enum Platform
    {
        /// <summary>
        /// Brasil
        /// </summary>
        BR1,

        /// <summary>
        /// Europe North-East
        /// </summary>
        EUN1,

        /// <summary>
        /// Europe West
        /// </summary>
        EUW1,

        /// <summary>
        /// Japan
        /// </summary>
        JP1,

        /// <summary>
        /// Korea
        /// </summary>
        KR,

        /// <summary>
        /// Latin America North
        /// </summary>
        LA1,

        /// <summary>
        /// Latin America South
        /// </summary>
        LA2,

        /// <summary>
        /// North America
        /// </summary>
        NA1,

        /// <summary>
        /// Oceania
        /// </summary>
        OC1,

        /// <summary>
        /// Turkey
        /// </summary>
        TR1,

        /// <summary>
        /// Rusia
        /// </summary>
        RU,

        /// <summary>
        /// No Platform (e.g. platformId of bot players).
        /// </summary>
        NoPlatform
    }
}
