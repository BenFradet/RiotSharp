using Newtonsoft.Json;
using RiotSharp.Misc.Converters;

namespace RiotSharp.Misc
{
    /// <summary>
    /// Map of the game. Populate the mapId field
    /// </summary>
    [JsonConverter(typeof(MapTypeConverter))]
    public enum MapType
    {
        /// <summary>
        /// Original Summer variant
        /// </summary>
        SummonersRiftSummerVariant = 1,

        /// <summary>
        /// Original Autumn variant
        /// </summary>
        SummonersRiftAutumnVariant = 2,

        /// <summary>
        /// Tutorial Map
        /// </summary>
        TheProvingGrounds = 3,

        /// <summary>
        /// Original Version
        /// </summary>
        TwistedTreelineOriginal = 4,

        /// <summary>
        /// Dominion map
        /// </summary>
        TheCrystalScar = 8,

        /// <summary>
        /// Last TT map
        /// </summary>
        TwistedTreeline = 10,

        /// <summary>
        /// Current Version
        /// </summary>
        SummonersRift = 11,

        /// <summary>
        /// ARAM map
        /// </summary>
        HowlingAbyss = 12,

        /// <summary>
        /// Alternate ARAM map
        /// </summary>
        ButchersBridge = 14,

        /// <summary>
        /// Dark Star: Singularity map
        /// </summary>
        CosmicRuins = 16,

        /// <summary>
        /// Star Guardian Invasion map
        /// </summary>
        ValoranCityPark = 18,

        /// <summary>
        /// PROJECT: Hunters map
        /// </summary>
        Substructure43 = 19,

        /// <summary>
        /// Odyssey: Extraction map
        /// </summary>
        CrashSite = 20,

        /// <summary>
        /// Nexus Blitz map
        /// </summary>
        NexusBltiz = 21
    }
}