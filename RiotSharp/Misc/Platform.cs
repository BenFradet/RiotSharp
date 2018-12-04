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
        /// North America.
        /// </summary>
        NA1,

        /// <summary>
        /// Brasil.
        /// </summary>
        BR1,

        /// <summary>
        /// Latin America North.
        /// </summary>
        LA1,

        /// <summary>
        /// Latin America South.
        /// </summary>
        LA2,

        /// <summary>
        /// Oceania.
        /// </summary>
        OC1,

        /// <summary>
        /// North-eastern Europe.
        /// </summary>
        EUN1,

        /// <summary>
        /// Turkey.
        /// </summary>
        TR1,

        /// <summary>
        /// Russia.
        /// </summary>
        RU,

        /// <summary>
        /// Western Europe.
        /// </summary>
        EUW1,

        /// <summary>
        /// Korea.
        /// </summary>
        KR,

        /// <summary>
        /// No Platform (e.g. platformId of bot players).
        /// </summary>
        NoPlatform
    }
}
