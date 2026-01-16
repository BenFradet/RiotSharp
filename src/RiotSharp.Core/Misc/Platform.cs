using System.Text.Json.Serialization;
using RiotSharp.Core.Misc.Converters;

namespace RiotSharp.Core.Misc
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
        /// Japan.
        /// </summary>
        JP1,

        /// <summary>
        /// Philippines.
        /// </summary>
        PH2,

        /// <summary>
        /// Singapore.
        /// </summary>
        SG2,

        /// <summary>
        /// Thailand.
        /// </summary>
        TH2,

        /// <summary>
        /// Taiwan.
        /// </summary>
        TW2,

        /// <summary>
        /// Vietnam.
        /// </summary>
        VN2,

        /// <summary>
        /// No Platform (e.g. platformId of bot players).
        /// </summary>
        NoPlatform
    }
}
