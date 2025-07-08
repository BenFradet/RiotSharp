using System.Text.Json.Serialization;
using RiotSharp.LeagueOfLegends.Misc.Converters;

namespace RiotSharp.LeagueOfLegends.Misc
{
    /// <summary>
    /// Map of the game. Populate the mapId field
    /// Last update: 24-08-2024
    /// </summary>
    [JsonConverter(typeof(MapTypeConverter))]
    public enum MapType
    {
        /// <summary>
        /// Summoner's Rift Summer Variant
        /// </summary>
        SummonersRiftSummerVariant = 1,

        /// <summary>
        /// Summoner's Rift Autumn Variant
        /// </summary>
        SummonersRiftAutumnVariant = 2,

        /// <summary>
        /// The Proving Grounds Tutorial Map
        /// </summary>
        TheProvingGrounds = 3,

        /// <summary>
        /// Twisted Treeline Original Version
        /// </summary>
        TwistedTreelineOriginal = 4,

        /// <summary>
        ///The Crystal Scar Dominion Map
        /// </summary>
        TheCrystalScar = 8,

        /// <summary>
        /// Twisted Treeline Current Version
        /// </summary>
        TwistedTreelineCurrent = 10,

        /// <summary>
        /// Summoner's Rift Current Version
        /// </summary>
        SummonersRift = 11,

        /// <summary>
        /// Howling Abyss ARAM Map
        /// </summary>
        HowlingAbyss = 12,
        
        /// <summary>
        /// Butcher's Bridge, alternate ARAM Map
        /// </summary>
        ButchersBridge = 14,

        /// <summary>
        /// Cosmic ruins, Dark Star: Singularity map
        /// </summary>
        CosmicRuins = 16,

        /// <summary>
        /// Valoran City Park, Star Guardian Invasion map
        /// </summary>
        ValoranCityPark = 18,

        /// <summary>
        /// Substructure 43, PROJECT: Hunters map
        /// </summary>
        Substructure43 = 19,

        /// <summary>
        /// CrashSite, Odyssey: Extraction map
        /// </summary>
        CrashSite = 20,
        
        /// <summary>
        /// Nexus Blitz map
        /// </summary>
        NexusBlitz = 21,

        /// <summary>
        /// Convergence, Teamfight Tactics map
        /// </summary>
        Convergence = 22,

        /// <summary>
        /// Rings of Wrath, Arena map
        /// </summary>
        RingsOfWrath = 30
    }
}
