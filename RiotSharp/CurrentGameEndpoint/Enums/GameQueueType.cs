using Newtonsoft.Json;
using RiotSharp.CurrentGameEndpoint.Enums.Converters;

namespace RiotSharp.CurrentGameEndpoint.Enums
{
    /// <summary>
    /// queueType and gameQueueConfigId subtype of CurrentGame API
    /// </summary>
    [JsonConverter(typeof(GameQueueTypeConverter))]
    public enum GameQueueType
    {
        /// <summary>
        /// Custom games.
        /// </summary>
        Custom = 0,

        /// <summary>
        /// Normal 3v3 games.
        /// </summary>
        Normal3x3 = 8,

        /// <summary>
        /// Normal 5v5 Blind Pick games.
        /// </summary>
        Normal5x5Blind = 2,

        /// <summary>
        /// Normal 5v5 Draft Pick games.
        /// </summary>
        Normal5x5Draft = 14,

        /// <summary>
        /// Ranked Solo 5v5 games, deprecated.
        /// </summary>
        RankedSolo5x5 = 4,

        /// <summary>
        /// Ranked Premade 5v5 games, deprecated.
        /// </summary>
        RankedPremade5x5 = 6,

        /// <summary>
        /// Used for both historical Ranked Premade 3v3 games and current Ranked Flex Twisted Treeline games.
        /// </summary>
        RankedFlexTT = 9,

        /// <summary>
        /// Ranked Team 3v3 games, deprecated.
        /// </summary>
        RankedTeam3x3 = 41,

        /// <summary>
        /// Ranked Team 5v5 games.
        /// </summary>
        RankedTeam5x5 = 42,

        /// <summary>
        /// Dominion 5v5 Blind Pick games.
        /// </summary>
        Odin5x5Blind = 16,

        /// <summary>
        /// Dominion 5v5 Draft Pick games.
        /// </summary>
        Odin5x5Draft = 17,

        /// <summary>
        /// Historical Summoner's Rift Coop vs AI games, deprecated.
        /// </summary>
        Bot5x5 = 7,

        /// <summary>
        /// Dominion Coop vs AI games.
        /// </summary>
        BotOdin5x5 = 25,

        /// <summary>
        /// Summoner's Rift Coop vs AI Intro Bot games.
        /// </summary>
        Bot5x5Intro = 31,

        /// <summary>
        /// Summoner's Rift Coop vs AI Beginner Bot games.
        /// </summary>
        Bot5x5Beginner = 32,

        /// <summary>
        /// Historical Summoner's Rift Coop vs AI Intermediate Bot games.
        /// </summary>
        Bot5x5Intermediate = 33,

        /// <summary>
        /// Twisted Treeline Coop vs AI games.
        /// </summary>
        BotTt3x3 = 52,

        /// <summary>
        /// Team Builder games.
        /// </summary>
        GroupFinder5x5 = 61,

        /// <summary>
        /// ARAM games.
        /// </summary>
        Aram5x5 = 65,

        /// <summary>
        /// One for All games.
        /// </summary>
        Oneforall5x5 = 70,

        /// <summary>
        /// Snowdown Showdown 1v1 games.
        /// </summary>
        Firstblood1x1 = 72,

        /// <summary>
        /// Snowdown Showdown 2v2 games.
        /// </summary>
        Firstblood2x2 = 73,

        /// <summary>
        /// Summoner's Rift 6x6 Hexakill games.
        /// </summary>
        Sr6x6 = 75,

        /// <summary>
        /// Ultra Rapid Fire games.
        /// </summary>
        Urf5x5 = 76,

        /// <summary>
        /// One for All (Mirror mode).
        /// </summary>
        OneForAllMirrorMode = 78,

        /// <summary>
        /// Ultra Rapid Fire games played against AI games.
        /// </summary>
        BotUrf5x5 = 83,

        /// <summary>
        /// Doom Bots Rank 1 games.
        /// </summary>
        NightmareBot5x5Rank1 = 91,

        /// <summary>
        /// Doom Bots Rank 2 games.
        /// </summary>
        NightmareBot5x5Rank2 = 92,

        /// <summary>
        /// Doom Bots Rank 5 games.
        /// </summary>
        NightmareBot5x5Rank5 = 93,

        /// <summary>
        /// Ascension games.
        /// </summary>
        Ascension5x5 = 96,

        /// <summary>
        /// Twisted Treeline 6x6 Hexakill games.
        /// </summary>
        Hexakill = 98,

        /// <summary>
        /// Butcher's Bridge games.
        /// </summary>
        BilgewaterAram5x5 = 100,

        /// <summary>
        /// King Poro games.
        /// </summary>
        KingPoro5x5 = 300,

        /// <summary>
        /// Nemesis games.
        /// </summary>
        CounterPick = 310,

        /// <summary>
        /// Black Market Brawlers games.
        /// </summary>
        Bilgewater5x5 = 313,

        /// <summary>
        /// Nexus Siege games.
        /// </summary>
        Siege = 315,

        /// <summary>
        /// Definitely Not Dominion games.
        /// </summary>
        DefinitelyNotDominion5x5 = 317,

        /// <summary>
        /// All Random URF games.
        /// </summary>
        ARURF5x5 = 318,

        /// <summary>
        /// Normal 5v5 Draft Pick games.
        /// </summary>
        TeamBuilderDraftUnranked5x5 = 400,

        /// <summary>
        /// Ranked 5v5 Draft Pick games, deprecated.
        /// </summary>
        TeamBuilderDraftRanked5x5 = 410,

        /// <summary>
        /// Ranked Solo games from current season that use Team Builder matchmaking.
        /// </summary>
        TeamBuilderRankedSolo = 420,

        /// <summary>
        /// Ranked Flex Summoner's Rift games.
        /// </summary>
        RankedFlexSR = 440,

        /// <summary>
        /// Darkstar games.
        /// </summary>
        Darkstar = 610
    }
}
