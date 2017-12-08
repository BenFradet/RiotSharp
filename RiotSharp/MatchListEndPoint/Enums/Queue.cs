﻿using Newtonsoft.Json;

namespace RiotSharp
{
    /// <summary>
    /// Queue of the league (League API).
    /// </summary>
    [JsonConverter(typeof(QueueConverter))]
    public enum Queue
    {
        /// <summary>
        /// Solo queue 5 vs 5.
        /// </summary>
        RankedSolo5x5,

        /// <summary>
        /// Team 3 vs 3.
        /// </summary>
        RankedTeam3x3,

        /// <summary>
        /// Team 5 vs 5.
        /// </summary>
        RankedTeam5x5,

        /// <summary>
        /// Team 5 v 5 - Dynamic Queue - Ranked
        /// </summary>
        TeamBuilderDraftRanked5x5,

        /// <summary>
        /// Team 5 v 5 - Dynamic Queue - Unranked
        /// </summary>
        TeamBuilderDraftUnranked5x5,

        /// <summary>
        /// New Summoner's Rift ranked games.
        /// </summary>
        RankedFlexSR,

        /// <summary>
        /// New Twisted Treeline ranked games.
        /// </summary>
        RankedFlexTT,

        /// <summary>
        /// Ranked Solo games from current season that use Team Builder matchmaking
        /// </summary>
        TeamBuilderRankedSolo,

        /// <summary>
        /// Used for both historical Ranked Premade 3v3 games
        /// </summary>
        RankedPremade3x3,

        /// <summary>
        /// Ranked Premade 5v5 games
        /// </summary>
        RankedPremade5x5,

        /// <summary>
        /// Darkstar games
        /// </summary>
        Darkstar
    }
    
    static class QueueExtension
    {
        public static string ToCustomString(this Queue queue)
        {
            switch (queue)
            {
                case Queue.RankedSolo5x5:
                    return "RANKED_SOLO_5x5";
                case Queue.RankedTeam3x3:
                    return "RANKED_TEAM_3x3";
                case Queue.RankedTeam5x5:
                    return "RANKED_TEAM_5x5";
                case Queue.TeamBuilderDraftRanked5x5:
                    return "TEAM_BUILDER_DRAFT_RANKED_5x5";
                case Queue.TeamBuilderDraftUnranked5x5:
                    return "TEAM_BUILDER_DRAFT_UNRANKED_5x5";
                case Queue.RankedFlexSR:
                    return "RANKED_FLEX_SR";
                case Queue.RankedFlexTT:
                    return "RANKED_FLEX_TT";
                case Queue.TeamBuilderRankedSolo:
                    return "TEAM_BUILDER_RANKED_SOLO";
                case Queue.Darkstar:
                    return "DARKSTAR_3x3";
                default:
                    return string.Empty;
            }
        }
    }
}
