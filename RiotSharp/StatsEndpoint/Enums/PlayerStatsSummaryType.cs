using Newtonsoft.Json;
using RiotSharp.StatsEndpoint.Enums.Converters;

namespace RiotSharp.StatsEndpoint.Enums
{
    /// <summary>
    /// Type of player stats (Stats API).
    /// </summary>
    [JsonConverter(typeof(PlayerStatsSummaryTypeConverter))]
    public enum PlayerStatsSummaryType
    {
        /// <summary>
        /// ARAM/Howling Abyss games.
        /// </summary>
        AramUnranked5x5,

        /// <summary>
        /// Team Builder games.
        /// </summary>
        CAP5x5,

        /// <summary>
        /// Summoner's Rift and Crystal Scar games played against AI.
        /// </summary>
        CoopVsAI,

        /// <summary>
        /// Twisted Treeline games played against AI.
        /// </summary>
        CoopVsAI3x3,

        /// <summary>
        /// Dominion/Crystal Scar games.
        /// </summary>
        OdinUnranked,

        /// <summary>
        /// Twisted Treeline ranked premade games.
        /// </summary>
        RankedPremade3x3,

        /// <summary>
        /// Summoner's Rift ranked premade games.
        /// </summary>
        RankedPremade5x5,

        /// <summary>
        /// Summoner's Rift ranked solo queue games.
        /// </summary>
        RankedSolo5x5,

        /// <summary>
        /// Twisted Treeline ranked team games.
        /// </summary>
        RankedTeam3x3,

        /// <summary>
        /// Summoner's Rift ranked team games.
        /// </summary>
        RankedTeam5x5,

        /// <summary>
        /// Summoner's Rift unranked games.
        /// </summary>
        Unranked,

        /// <summary>
        /// Twisted Treeline unranked games.
        /// </summary>
        Unranked3x3,

        /// <summary>
        /// One for All games.
        /// </summary>
        OneForAll5x5,

        /// <summary>
        /// Snowdown Showdown 1x1 games.
        /// </summary>
        FirstBlood1x1,

        /// <summary>
        /// Snowdown Showdown 2x2 games.
        /// </summary>
        FirstBlood2x2,

        /// <summary>
        /// Summoner's Rift 6x6 Hexakill games.
        /// </summary>
        SummonersRift6x6,

        /// <summary>
        /// Ultra Rapid Fire games.
        /// </summary>
        URF,

        /// <summary>
        /// Ultra Rapid Fire games played against AI.
        /// </summary>
        URFBots,

        /// <summary>
        /// Summoner's Rift games played against Nightmare AI.
        /// </summary>
        NightmareBot,

        /// <summary>
        /// Ascension games.
        /// </summary>
        Ascension,

        /// <summary>
        /// Twisted Treeline 6x6 Hexakill games.
        /// </summary>
        Hexakill,

        /// <summary>
        /// King Poro games.
        /// </summary>
        KingPoro,

        /// <summary>
        /// Nemesis games.
        /// </summary>
        CounterPick,

        /// <summary>
        /// Black Market Brawlers games.
        /// </summary>
        Bilgewater,

        /// <summary>
        /// Siege games.
        /// </summary>
        Siege,

        /// <summary>
        /// New Summoner's Rift ranked games.
        /// </summary>
        RankedFlexSR,

        /// <summary>
        /// New Twisted Treeline ranked games.
        /// </summary>
        RankedFlexTT
    }
}
