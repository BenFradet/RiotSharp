namespace RiotSharp.GameEndpoint
{
    /// <summary>
    /// Game subtype of the game (Game API).
    /// </summary>
    public enum GameSubType
    {
        /// <summary>
        /// Custom games.
        /// </summary>
        None,

        /// <summary>
        /// Summoner's Rift unranked games.
        /// </summary>
        Normal,

        /// <summary>
        /// Summoner's Rift and Crystal Scar games played against AI.
        /// </summary>
        Bot,

        /// <summary>
        /// Summoner's Rift ranked solo queue games.
        /// </summary>
        RankedSolo5x5,

        /// <summary>
        /// Twisted treeline ranked premade games.
        /// </summary>
        RankedPremade3x3,

        /// <summary>
        /// Summoner's rift ranked premade games.
        /// </summary>
        RankedPremade5x5,

        /// <summary>
        /// Dominion/Crystal Scar games.
        /// </summary>
        OdinUnranked,

        /// <summary>
        /// Twisted Treeline ranked team games.
        /// </summary>
        RankedTeam3x3,

        /// <summary>
        /// Summoner's Rift ranked team games.
        /// </summary>
        RankedTeam5x5,

        /// <summary>
        /// Twisted Treeline unranked games.
        /// </summary>
        Normal3x3,

        /// <summary>
        /// Twisted Treeline games played against AI.
        /// </summary>
        Bot3x3,

        /// <summary>
        /// ARAM/Howling Abyss games.
        /// </summary>
        AramUnranked5x5,

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
        /// Hexakill games
        /// </summary>
        Hexakill,

        /// <summary>
        /// Team Builder games
        /// </summary>
        TeamBuilder5x5,

        /// <summary>
        /// URF games
        /// </summary>
        URF,

        /// <summary>
        /// URF Bots games
        /// </summary>
        URF_BOT,

        /// <summary>
        /// Nightmare bots games.
        /// </summary>
        NightmareBot,

        /// <summary>
        /// Ascension mode games.
        /// </summary>
        Ascension,

        /// <summary>
        /// King Poro games.
        /// </summary>
        KingPoro,

        /// <summary>
        /// Black Market Brawlers games.
        /// </summary>
        Bilgewater,

        /// <summary>
        /// Counter Pick games.
        /// </summary>
        CounterPick
    }
}
