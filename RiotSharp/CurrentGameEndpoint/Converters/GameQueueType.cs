namespace RiotSharp.CurrentGameEndpoint.Converters
{
    /// <summary>
    /// queueType and gameQueueConfigId subtype of CurrentGame API
    /// </summary>
    public enum GameQueueType
    {
        /// <summary>
        /// Custom games
        /// </summary>
        Custom = 0,

        /// <summary>
        /// Normal 5v5 Blind Pick games
        /// </summary>
        Normal5x5Blind = 2,

        /// <summary>
        /// Historical Summoner's Rift Coop vs AI games
        /// </summary>
        Bot5x5 = 7,

        /// <summary>
        /// Summoner's Rift Coop vs AI Intro Bot games
        /// </summary>
        Bot5x5Intro = 31,

        /// <summary>
        /// Summoner's Rift Coop vs AI Beginner Bot games
        /// </summary>
        Bot5x5Beginner = 32,

        /// <summary>
        /// Historical Summoner's Rift Coop vs AI Intermediate Bot games
        /// </summary>
        Bot5x5Intermediate = 33,

        /// <summary>
        /// Normal 3v3 games
        /// </summary>
        Normal3x3 = 8,

        /// <summary>
        /// Normal 5v5 Draft Pick games
        /// </summary>
        Normal5x5Draft = 14,

        /// <summary>
        /// Dominion 5v5 Blind Pick games
        /// </summary>
        Odin5x5Blind = 16,

        /// <summary>
        /// Dominion 5v5 Draft Pick games
        /// </summary>
        Odin5x5Draft = 17,

        /// <summary>
        /// Dominion Coop vs AI games
        /// </summary>
        BotOdin5x5 = 25,

        /// <summary>
        /// Ranked Solo 5v5 games
        /// </summary>
        RankedSolo5x5 = 4,

        /// <summary>
        /// Ranked Premade 3v3 games
        /// </summary>
        RankedPremade3x3 = 9,

        /// <summary>
        /// Ranked Premade 5v5 games
        /// </summary>
        RankedPremade5x5 = 6,

        /// <summary>
        /// Ranked Team 3v3 games
        /// </summary>
        RankedTeam3x3 = 41,

        /// <summary>
        /// Ranked Team 5v5 games
        /// </summary>
        RankedTeam5x5 = 42,

        /// <summary>
        /// Twisted Treeline Coop vs AI games
        /// </summary>
        BotTt3x3 = 52,

        /// <summary>
        /// Team Builder games
        /// </summary>
        GroupFinder5x5 = 61,

        /// <summary>
        /// ARAM games
        /// </summary>
        Aram5x5 = 65,

        /// <summary>
        /// One for All games
        /// </summary>
        Oneforall5x5 = 70,

        /// <summary>
        /// Snowdown Showdown 1v1 games
        /// </summary>
        Firstblood1x1 = 72,

        /// <summary>
        /// Snowdown Showdown 2v2 games
        /// </summary>
        Firstblood2x2 = 73,

        /// <summary>
        /// Summoner's Rift 6x6 Hexakill games
        /// </summary>
        Sr6x6 = 75,

        /// <summary>
        /// Ultra Rapid Fire games
        /// </summary>
        Urf5x5 = 76,

        /// <summary>
        /// Ultra Rapid Fire games played against AI games
        /// </summary>
        BotUrf5x5 = 83,

        /// <summary>
        /// Doom Bots Rank 1 games
        /// </summary>
        NightmareBot5x5Rank1 = 91,

        /// <summary>
        /// Doom Bots Rank 2 games
        /// </summary>
        NightmareBot5x5Rank2 = 92,

        /// <summary>
        /// Doom Bots Rank 5 games
        /// </summary>
        NightmareBot5x5Rank5 = 93,

        /// <summary>
        /// Ascension games
        /// </summary>
        Ascension5x5 = 96,

        /// <summary>
        /// Twisted Treeline 6x6 Hexakill games
        /// </summary>
        Hexakill = 98,

        /// <summary>
        /// Butcher's Bridge games
        /// </summary>
        BilgewaterAram5x5 = 100,

        /// <summary>
        /// King Poro games
        /// </summary>
        KingPoro5x5 = 300,

        /// <summary>
        /// Black Market Brawlers games
        /// </summary>
        Bilgewater5x5 = 313
    }
}
