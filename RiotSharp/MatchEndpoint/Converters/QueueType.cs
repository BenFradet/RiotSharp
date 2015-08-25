namespace RiotSharp.MatchEndpoint
{
    /// <summary>
    /// Match queue type (Match API).
    /// </summary>
    public enum QueueType
    {
        /// <summary>
        /// Custom games.
        /// </summary>
        Custom,

        /// <summary>
        /// Normal games in blind mode 5vs5.
        /// </summary>
        Normal5x5Blind,

        /// <summary>
        /// Ranked games in solo queue 5vs5.
        /// </summary>
        RankedSolo5x5,

        /// <summary>
        /// Ranked games in premade 5vs5.
        /// </summary>
        RankedPremade5x5,

        /// <summary>
        /// Games against bots 5vs5.
        /// </summary>
        Bot5x5,

        /// <summary>
        /// Normal games 3vs3.
        /// </summary>
        Normal3x3,

        /// <summary>
        /// Ranked games in premade 3vs3.
        /// </summary>
        RankedPremade3x3,

        /// <summary>
        /// Normal games in draft mode 5vs5.
        /// </summary>
        Normal5x5Draft,

        /// <summary>
        /// Dominion games in blind mode 5vs5.
        /// </summary>
        Odin5x5Blind,

        /// <summary>
        /// Dominion games in draft mode 5vs5.
        /// </summary>
        Odin5x5Draft,

        /// <summary>
        /// Dominion games against mode 5vs5.
        /// </summary>
        BotOdin5x5,

        /// <summary>
        /// Introductory games against bots 5vs5.
        /// </summary>
        Bot5x5Intro,

        /// <summary>
        /// Games against bots in beginner difficulty 5vs5.
        /// </summary>
        Bot5x5Beginner,

        /// <summary>
        /// Games against bots in intermediate difficulty 5vs5.
        /// </summary>
        Bot5x5Intermediate,

        /// <summary>
        /// Ranked games in team 3vs3.
        /// </summary>
        RankedTeam3x3,

        /// <summary>
        /// Ranked games in team 5vs5.
        /// </summary>
        RankedTeam5x5,

        /// <summary>
        /// Games against bots 3vs3.
        /// </summary>
        BotTt3x3,

        /// <summary>
        /// Games using group finder 5vs5.
        /// </summary>
        GroupFinder5x5,

        /// <summary>
        /// ARAM games 5vs5.
        /// </summary>
        Aram5x5,

        /// <summary>
        /// One for all games 5vs5.
        /// </summary>
        OneForAll5x5,

        /// <summary>
        /// First blood mode 1vs1.
        /// </summary>
        FirstBlood1x1,

        /// <summary>
        /// First blood mode 2vs2.
        /// </summary>
        FirstBlood2x2,

        /// <summary>
        /// Hexakill games 6vs6.
        /// </summary>
        Sr6x6,

        /// <summary>
        /// Ultra rapid fire games 5vs5.
        /// </summary>
        Urf5x5,

        /// <summary>
        /// Ultra rapid fire games against bots 5vs5.
        /// </summary>
        BotUrf5x5,

        /// <summary>
        /// Games against nightmare bots rank 1 5vs5.
        /// </summary>
        NightmareBot5x5Rank1,

        /// <summary>
        /// Games against nightmare bots rank2 5vs5.
        /// </summary>
        NightmareBot5x5Rank2,

        /// <summary>
        /// Games against nightmare bots rank 5 5vs5.
        /// </summary>
        NightmareBot5x5Rank5,

        /// <summary>
        /// Butcher's Bridge games.
        /// </summary>
        BilgewaterAram5x5,

        /// <summary>
        /// Black Market Brawlers games.
        /// </summary>
        Bilgewater5x5
    }

    static class QueueTypeExtension
    {
        public static string ToCustomString(this QueueType queueType)
        {
            switch (queueType)
            {
                case QueueType.Aram5x5:
                    return "ARAM_5x5";
                case QueueType.Bot5x5:
                    return "BOT_5x5";
                case QueueType.Bot5x5Beginner:
                    return "BOT_5x5_BEGINNER";
                case QueueType.Bot5x5Intermediate:
                    return "BOT_5x5_INTERMEDIATE";
                case QueueType.Bot5x5Intro:
                    return "BOT_5x5_INTRO";
                case QueueType.BotOdin5x5:
                    return "BOT_ODIN_5x5";
                case QueueType.BotTt3x3:
                    return "BOT_TT_3x3";
                case QueueType.BotUrf5x5:
                    return "BOT_URF_5x5";
                case QueueType.Custom:
                    return "CUSTOM";
                case QueueType.FirstBlood1x1:
                    return "FIRSTBLOOD_1x1";
                case QueueType.FirstBlood2x2:
                    return "FIRSTBLOOD_2x2";
                case QueueType.GroupFinder5x5:
                    return "GROUP_FINDER_5x5";
                case QueueType.NightmareBot5x5Rank1:
                    return "NIGHTMARE_BOT_5x5_RANK1";
                case QueueType.NightmareBot5x5Rank2:
                    return "NIGHTMARE_BOT_5x5_RANK2";
                case QueueType.NightmareBot5x5Rank5:
                    return "NIGHTMARE_BOT_5x5_RANK5";
                case QueueType.Normal3x3:
                    return "NORMAL_3x3";
                case QueueType.Normal5x5Blind:
                    return "NORMAL_5x5_BLIND";
                case QueueType.Normal5x5Draft:
                    return "NORMAL_5x5_DRAFT";
                case QueueType.Odin5x5Blind:
                    return "ODIN_5x5_BLIND";
                case QueueType.Odin5x5Draft:
                    return "ODIN_5x5_DRAFT";
                case QueueType.OneForAll5x5:
                    return "ONEFORALL_5x5";
                case QueueType.RankedPremade3x3:
                    return "RANKED_PREMADE_3x3";
                case QueueType.RankedPremade5x5:
                    return "RANKED_PREMADE_5x5";
                case QueueType.RankedSolo5x5:
                    return "RANKED_SOLO_5x5";
                case QueueType.RankedTeam3x3:
                    return "RANKED_TEAM_3x3";
                case QueueType.RankedTeam5x5:
                    return "RANKED_TEAM_5x5";
                case QueueType.Sr6x6:
                    return "SR_6x6";
                case QueueType.Urf5x5:
                    return "URF_5x5";
                case QueueType.Bilgewater5x5:
                    return "BILGEWATER_5x5";
                case QueueType.BilgewaterAram5x5:
                    return "BILGEWATER_ARAM_5x5";
                default:
                    return string.Empty;
            }
        }
    }
}
