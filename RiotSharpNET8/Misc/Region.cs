using System.Text.Json.Serialization;
using RiotSharpNET8.Misc.Converters;

namespace RiotSharpNET8.Misc
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
        /// Japan.
        /// </summary>
        Jp,

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
        /// North america.
        /// </summary>
        Na,
        
        /// <summary>
        /// Oceania.
        /// </summary>
        Oce,

        /// <summary>
        /// Turkey.
        /// </summary>
        Tr,

        /// <summary>
        /// Russia.
        /// </summary>
        Ru,

        /// <summary>
        /// PH2 idk
        /// </summary>
        Ph,

        /// <summary>
        /// Sg idk
        /// </summary>
        Sg,

        /// <summary>
        /// Th idk, Thailand?
        /// </summary>
        Th,

        /// <summary>
        /// Tw idk, Taiwan?
        /// </summary>
        Tw,

        /// <summary>
        /// Vn idk, Vietnam?
        /// </summary>
        Vn,

        /// <summary>
        /// Middle East.
        /// </summary>
        Me,

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
        /// Regional proxy for services only deployed in SEA? (South East Asia)
        /// </summary>
        Sea,

        /// <summary>
        /// For some reason there is an Esports region.
        /// </summary>
        Esports,

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
