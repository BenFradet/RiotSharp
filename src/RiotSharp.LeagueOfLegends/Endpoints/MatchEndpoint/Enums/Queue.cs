using System.Text.Json.Serialization;
using RiotSharp.LeagueOfLegends.Endpoints.MatchEndpoint.Enums.Converters;

namespace RiotSharp.LeagueOfLegends.Endpoints.MatchEndpoint.Enums
{
    /// <summary>
    /// Queue types for matchmaking.
    /// </summary>
    [JsonConverter(typeof(QueueConverter))]
    public enum Queue
    {
        /// <summary>
        /// Custom games
        /// </summary>s
        CustomGames = 0,

        /// <summary>
        /// 5v5 Blind Pick games (Deprecated in patch 7.19 in favor of queueId 430)
        /// </summary>
        [Obsolete("Deprecated in patch 7.19 in favor of BlindPick5v5")]
        BlindPick5v5_Old = 2,

        /// <summary>
        /// 5v5 Ranked Solo games (Deprecated in favor of queueId 420)
        /// </summary>
        [Obsolete("Deprecated in favor of RankedSolo5v5")]
        RankedSolo5v5_Old = 4,

        /// <summary>
        /// 5v5 Ranked Premade games (Game mode deprecated)
        /// </summary>
        [Obsolete("Game mode deprecated")]
        RankedPremade5v5 = 6,

        /// <summary>
        /// Co-op vs AI games (Deprecated in favor of queueId 32 and 33)
        /// </summary>
        [Obsolete("Deprecated in favor of queueId 32 and 33")]
        CoopVsAI_Old = 7,

        /// <summary>
        /// 3v3 Normal games (Deprecated in patch 7.19 in favor of queueId 460)
        /// </summary>
        [Obsolete("Deprecated in patch 7.19 in favor of TwistedTreeline3v3")]
        Normal3v3_Old = 8,

        /// <summary>
        /// 3v3 Ranked Flex games (Deprecated in patch 7.19 in favor of queueId 470)
        /// </summary>
        [Obsolete("Deprecated in patch 7.19 in favor of RankedFlex3v3")]
        RankedFlex3v3_Old = 9,

        /// <summary>
        /// 5v5 Draft Pick games (Deprecated in favor of queueId 400)
        /// </summary>
        [Obsolete("Deprecated in favor of DraftPick5v5")]
        DraftPick5v5_Old = 14,

        /// <summary>
        /// 5v5 Dominion Blind Pick games (Game mode deprecated)
        /// </summary>
        [Obsolete("Game mode deprecated")]
        DominionBlindPick5v5 = 16,

        /// <summary>
        /// 5v5 Dominion Draft Pick games (Game mode deprecated)
        /// </summary>
        [Obsolete("Game mode deprecated")]
        DominionDraftPick5v5 = 17,

        /// <summary>
        /// Dominion Co-op vs AI games (Game mode deprecated)
        /// </summary>
        [Obsolete("Game mode deprecated")]
        DominionCoopVsAI = 25,

        /// <summary>
        /// Co-op vs AI Intro Bot games (Deprecated in patch 7.19 in favor of queueId 830)
        /// </summary>
        [Obsolete("Deprecated in patch 7.19 in favor of CoopVsAIIntro")]
        CoopVsAIIntro_Old = 31,

        /// <summary>
        /// Co-op vs AI Beginner Bot games (Deprecated in patch 7.19 in favor of queueId 840)
        /// </summary>
        [Obsolete("Deprecated in patch 7.19 in favor of CoopVsAIBeginner")]
        CoopVsAIBeginner_Old = 32,

        /// <summary>
        /// Co-op vs AI Intermediate Bot games (Deprecated in patch 7.19 in favor of queueId 850)
        /// </summary>
        [Obsolete("Deprecated in patch 7.19 in favor of CoopVsAIIntermediate")]
        CoopVsAIIntermediate_Old = 33,

        /// <summary>
        /// 3v3 Ranked Team games (Game mode deprecated)
        /// </summary>
        [Obsolete("Game mode deprecated")]
        RankedTeam3v3 = 41,

        /// <summary>
        /// 5v5 Ranked Team games (Game mode deprecated)
        /// </summary>
        [Obsolete("Game mode deprecated")]
        RankedTeam5v5 = 42,

        /// <summary>
        /// Co-op vs AI games (Deprecated in patch 7.19 in favor of queueId 800)
        /// </summary>
        [Obsolete("Deprecated in patch 7.19 in favor of CoopVsAIIntermediate3v3")]
        CoopVsAI3v3_Old = 52,

        /// <summary>
        /// 5v5 Team Builder games (Game mode deprecated)
        /// </summary>
        [Obsolete("Game mode deprecated")]
        TeamBuilder5v5 = 61,

        /// <summary>
        /// 5v5 ARAM games (Deprecated in patch 7.19 in favor of queueId 450)
        /// </summary>
        [Obsolete("Deprecated in patch 7.19 in favor of ARAM")]
        ARAM_Old = 65,

        /// <summary>
        /// ARAM Co-op vs AI games (Game mode deprecated)
        /// </summary>
        [Obsolete("Game mode deprecated")]
        ARAMCoopVsAI = 67,

        /// <summary>
        /// One for All games (Deprecated in patch 8.6 in favor of queueId 1020)
        /// </summary>
        [Obsolete("Deprecated in patch 8.6 in favor of OneForAll")]
        OneForAll_Old = 70,

        /// <summary>
        /// 1v1 Snowdown Showdown games
        /// </summary>
        SnowdownShowdown1v1 = 72,

        /// <summary>
        /// 2v2 Snowdown Showdown games
        /// </summary>
        SnowdownShowdown2v2 = 73,

        /// <summary>
        /// 6v6 Hexakill games
        /// </summary>
        Hexakill6v6 = 75,

        /// <summary>
        /// Ultra Rapid Fire games
        /// </summary>
        URF = 76,

        /// <summary>
        /// One For All: Mirror Mode games
        /// </summary>
        OneForAllMirror = 78,

        /// <summary>
        /// Co-op vs AI Ultra Rapid Fire games
        /// </summary>
        CoopVsAIURF = 83,

        /// <summary>
        /// Doom Bots Rank 1 games (Deprecated in patch 7.19 in favor of queueId 950)
        /// </summary>
        [Obsolete("Deprecated in patch 7.19 in favor of DoomBotsVoting")]
        DoomBotsRank1 = 91,

        /// <summary>
        /// Doom Bots Rank 2 games (Deprecated in patch 7.19 in favor of queueId 950)
        /// </summary>
        [Obsolete("Deprecated in patch 7.19 in favor of DoomBotsVoting")]
        DoomBotsRank2 = 92,

        /// <summary>
        /// Doom Bots Rank 5 games (Deprecated in patch 7.19 in favor of queueId 950)
        /// </summary>
        [Obsolete("Deprecated in patch 7.19 in favor of DoomBotsVoting")]
        DoomBotsRank5 = 93,

        /// <summary>
        /// Ascension games (Deprecated in patch 7.19 in favor of queueId 910)
        /// </summary>
        [Obsolete("Deprecated in patch 7.19 in favor of Ascension")]
        Ascension_Old = 96,

        /// <summary>
        /// 6v6 Hexakill games
        /// </summary>
        Hexakill6v6_TwistedTreeline = 98,

        /// <summary>
        /// 5v5 ARAM games on Butcher's Bridge
        /// </summary>
        ARAMButchersBridge = 100,

        /// <summary>
        /// Legend of the Poro King games (Deprecated in patch 7.19 in favor of queueId 920)
        /// </summary>
        [Obsolete("Deprecated in patch 7.19 in favor of PoroKing")]
        PoroKing_Old = 300,

        /// <summary>
        /// Nemesis games
        /// </summary>
        Nemesis = 310,

        /// <summary>
        /// Black Market Brawlers games
        /// </summary>
        BlackMarketBrawlers = 313,

        /// <summary>
        /// Nexus Siege games (Deprecated in patch 7.19 in favor of queueId 940)
        /// </summary>
        [Obsolete("Deprecated in patch 7.19 in favor of NexusSiege")]
        NexusSiege_Old = 315,

        /// <summary>
        /// Definitely Not Dominion games
        /// </summary>
        DefinitelyNotDominion = 317,

        /// <summary>
        /// ARURF games (Deprecated in patch 7.19 in favor of queueId 900)
        /// </summary>
        [Obsolete("Deprecated in patch 7.19 in favor of ARURF")]
        ARURF_Old = 318,

        /// <summary>
        /// All Random games
        /// </summary>
        AllRandom = 325,

        /// <summary>
        /// 5v5 Draft Pick games
        /// </summary>
        DraftPick5v5 = 400,

        /// <summary>
        /// 5v5 Ranked Dynamic games (Game mode deprecated in patch 6.22)
        /// </summary>
        [Obsolete("Game mode deprecated in patch 6.22")]
        RankedDynamic5v5 = 410,

        /// <summary>
        /// 5v5 Ranked Solo games
        /// </summary>
        RankedSolo5v5 = 420,

        /// <summary>
        /// 5v5 Blind Pick games
        /// </summary>
        BlindPick5v5 = 430,

        /// <summary>
        /// 5v5 Ranked Flex games
        /// </summary>
        RankedFlex5v5 = 440,

        /// <summary>
        /// 5v5 ARAM games
        /// </summary>
        ARAM = 450,

        /// <summary>
        /// 3v3 Blind Pick games (Deprecated in patch 9.23)
        /// </summary>
        [Obsolete("Deprecated in patch 9.23")]
        TwistedTreeline3v3 = 460,

        /// <summary>
        /// 3v3 Ranked Flex games (Deprecated in patch 9.23)
        /// </summary>
        [Obsolete("Deprecated in patch 9.23")]
        RankedFlex3v3 = 470,

        /// <summary>
        /// Swiftplay Games
        /// </summary>
        Swiftplay = 480,

        /// <summary>
        /// Normal (Quickplay)
        /// </summary>
        NormalQuickplay = 490,

        /// <summary>
        /// Blood Hunt Assassin games
        /// </summary>
        BloodHuntAssassin = 600,

        /// <summary>
        /// Dark Star: Singularity games
        /// </summary>
        DarkStarSingularity = 610,

        /// <summary>
        /// Summoner's Rift Clash games
        /// </summary>
        ClashSummonersRift = 700,

        /// <summary>
        /// ARAM Clash games
        /// </summary>
        ClashARAM = 720,

        /// <summary>
        /// Co-op vs. AI Intermediate Bot games (Deprecated in patch 9.23)
        /// </summary>
        [Obsolete("Deprecated in patch 9.23")]
        CoopVsAIIntermediate3v3 = 800,

        /// <summary>
        /// Co-op vs. AI Intro Bot games (Deprecated in patch 9.23)
        /// </summary>
        [Obsolete("Deprecated in patch 9.23")]
        CoopVsAIIntro3v3 = 810,

        /// <summary>
        /// Co-op vs. AI Beginner Bot games
        /// </summary>
        CoopVsAIBeginner3v3 = 820,

        /// <summary>
        /// Co-op vs. AI Intro Bot games (Deprecated in March 2024 in favor of queueId 870)
        /// </summary>
        [Obsolete("Deprecated in March 2024 in favor of CoopVsAIIntro")]
        CoopVsAIIntro_Deprecated = 830,

        /// <summary>
        /// Co-op vs. AI Beginner Bot games (Deprecated in March 2024 in favor of queueId 880)
        /// </summary>
        [Obsolete("Deprecated in March 2024 in favor of CoopVsAIBeginner")]
        CoopVsAIBeginner_Deprecated = 840,

        /// <summary>
        /// Co-op vs. AI Intermediate Bot games (Deprecated in March 2024 in favor of queueId 890)
        /// </summary>
        [Obsolete("Deprecated in March 2024 in favor of CoopVsAIIntermediate")]
        CoopVsAIIntermediate_Deprecated = 850,

        /// <summary>
        /// Co-op vs. AI Intro Bot games
        /// </summary>
        CoopVsAIIntro = 870,

        /// <summary>
        /// Co-op vs. AI Beginner Bot games
        /// </summary>
        CoopVsAIBeginner = 880,

        /// <summary>
        /// Co-op vs. AI Intermediate Bot games
        /// </summary>
        CoopVsAIIntermediate = 890,

        /// <summary>
        /// ARURF games
        /// </summary>
        ARURF = 900,

        /// <summary>
        /// Ascension games
        /// </summary>
        Ascension = 910,

        /// <summary>
        /// Legend of the Poro King games
        /// </summary>
        PoroKing = 920,

        /// <summary>
        /// Nexus Siege games
        /// </summary>
        NexusSiege = 940,

        /// <summary>
        /// Doom Bots Voting games
        /// </summary>
        DoomBotsVoting = 950,

        /// <summary>
        /// Doom Bots Standard games
        /// </summary>
        DoomBotsStandard = 960,

        /// <summary>
        /// Star Guardian Invasion: Normal games
        /// </summary>
        StarGuardianInvasionNormal = 980,

        /// <summary>
        /// Star Guardian Invasion: Onslaught games
        /// </summary>
        StarGuardianInvasionOnslaught = 990,

        /// <summary>
        /// PROJECT: Hunters games
        /// </summary>
        ProjectHunters = 1000,

        /// <summary>
        /// Snow ARURF games
        /// </summary>
        SnowARURF = 1010,

        /// <summary>
        /// One for All games
        /// </summary>
        OneForAll = 1020,

        /// <summary>
        /// Odyssey Extraction: Intro games
        /// </summary>
        OdysseyExtractionIntro = 1030,

        /// <summary>
        /// Odyssey Extraction: Cadet games
        /// </summary>
        OdysseyExtractionCadet = 1040,

        /// <summary>
        /// Odyssey Extraction: Crewmember games
        /// </summary>
        OdysseyExtractionCrewmember = 1050,

        /// <summary>
        /// Odyssey Extraction: Captain games
        /// </summary>
        OdysseyExtractionCaptain = 1060,

        /// <summary>
        /// Odyssey Extraction: Onslaught games
        /// </summary>
        OdysseyExtractionOnslaught = 1070,

        /// <summary>
        /// Teamfight Tactics games
        /// </summary>
        TeamfightTactics = 1090,

        /// <summary>
        /// Ranked Teamfight Tactics games
        /// </summary>
        TeamfightTacticsRanked = 1100,

        /// <summary>
        /// Teamfight Tactics Tutorial games
        /// </summary>
        TeamfightTacticsTutorial = 1110,

        /// <summary>
        /// Teamfight Tactics test games
        /// </summary>
        TeamfightTacticsTest = 1111,

        /// <summary>
        /// Nexus Blitz games (Deprecated in patch 9.2)
        /// </summary>
        [Obsolete("Deprecated in patch 9.2")]
        NexusBlitz_Old = 1200,

        /// <summary>
        /// Teamfight Tactics Choncc's Treasure Mode
        /// </summary>
        TeamfightTacticsChonccsTreasure = 1210,

        /// <summary>
        /// Nexus Blitz games
        /// </summary>
        NexusBlitz = 1300,

        /// <summary>
        /// Ultimate Spellbook games
        /// </summary>
        UltimateSpellbook = 1400,

        /// <summary>
        /// Arena
        /// </summary>
        Arena = 1700,

        /// <summary>
        /// Arena (16 player lobby)
        /// </summary>
        Arena16Player = 1710,

        /// <summary>
        /// Swarm Mode 1 player
        /// </summary>
        Swarm1Player = 1810,

        /// <summary>
        /// Swarm Mode 2 players
        /// </summary>
        Swarm2Players = 1820,

        /// <summary>
        /// Swarm Mode 3 players
        /// </summary>
        Swarm3Players = 1830,

        /// <summary>
        /// Swarm Mode 4 players
        /// </summary>
        Swarm4Players = 1840,

        /// <summary>
        /// Pick URF games
        /// </summary>
        PickURF = 1900,

        /// <summary>
        /// Tutorial 1
        /// </summary>
        Tutorial1 = 2000,

        /// <summary>
        /// Tutorial 2
        /// </summary>
        Tutorial2 = 2010,

        /// <summary>
        /// Tutorial 3
        /// </summary>
        Tutorial3 = 2020,

        /// <summary>
        /// Brawl
        /// </summary>
        Brawl = 2300,

        /// <summary>
        /// ARAM: Mayhem
        /// </summary>
        ARAMMayhem = 2400
    }
}
