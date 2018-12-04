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
        br,

        /// <summary>
        /// North-eastern europe.
        /// </summary>
        eune,

        /// <summary>
        /// Western europe.
        /// </summary>
        euw,

        /// <summary>
        /// North america.
        /// </summary>
        na,

        /// <summary>
        /// South korea.
        /// </summary>
        kr,

        /// <summary>
        /// Latin America North.
        /// </summary>
        lan,

        /// <summary>
        /// Latin America South.
        /// </summary>
        las,

        /// <summary>
        /// Oceania.
        /// </summary>
        oce,

        /// <summary>
        /// Russia.
        /// </summary>
        ru,

        /// <summary>
        /// Turkey.
        /// </summary>
        tr,

        /// <summary>
        /// Japan.
        /// </summary>
        jp,

        /// <summary>
        /// Global.
        /// </summary>
        global,

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
        NoRegion
    }
}
