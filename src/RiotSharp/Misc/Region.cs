using Newtonsoft.Json;
using RiotSharp.Misc.Converters;

namespace RiotSharp.Misc
{
    /// <summary>
    /// Region for the API.
    /// </summary>
    [JsonConverter(typeof(RegionConverter))]
    public enum Region
    {
        /// <summary>
        /// Brasil.
        /// </summary>
        Br,

        /// <summary>
        /// North-eastern europe.
        /// </summary>
        Eune,

        /// <summary>
        /// Western europe.
        /// </summary>
        Euw,

        /// <summary>
        /// North america.
        /// </summary>
        Na,

        /// <summary>
        /// South korea.
        /// </summary>
        Kr,

        /// <summary>
        /// Latin America North.
        /// </summary>
        Lan,

        /// <summary>
        /// Latin America South.
        /// </summary>
        Las,

        /// <summary>
        /// Oceania.
        /// </summary>
        Oce,

        /// <summary>
        /// Russia.
        /// </summary>
        Ru,

        /// <summary>
        /// Turkey.
        /// </summary>
        Tr,

        /// <summary>
        /// Japan.
        /// </summary>
        Jp,

        /// <summary>
        /// Global.
        /// </summary>
        Global,

        /// <summary>
        /// Regional proxy for services only deployed in North America. For example the tournament and tournament stub services.
        /// </summary>
        Americas,

        /// <summary>
        /// Regional proxy for services only deployed in Europe.
        /// </summary>
        Europe,

        /// <summary>
        /// Regional proxy for services only deployed in Asia.
        /// </summary>
        Asia,

        /// <summary>
        /// Region associated with Platform.NoPlatform (e.g. platform of bot players).
        /// </summary>
        NoRegion,

        /// <summary>
        /// Asia Pacific.
        /// </summary>
        Ap,

        /// <summary>
        /// Europe.
        /// </summary>
        Eu,

        /// <summary>
        /// Latin America.
        /// </summary>
        Latam
    }
}
