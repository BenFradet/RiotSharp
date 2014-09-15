using System;
using Newtonsoft.Json;

namespace RiotSharp.StatsEndpoint
{
    /// <summary>
    /// AggregatedStat (Stats API).
    /// </summary>
    [Serializable]
    public class AggregatedStat
    {
        internal AggregatedStat() { }

        /// <summary>
        /// Number of assists per game on average, dominion only.
        /// </summary>
        [JsonProperty("averageAssists")]
        public int AverageAssists { get; set; }

        /// <summary>
        /// Number of champions killed per game on average, dominion only.
        /// </summary>
        [JsonProperty("averageChampionsKilled")]
        public int AverageChampionsKilled { get; set; }

        /// <summary>
        /// Combat score per game on average, dominion only.
        /// </summary>
        [JsonProperty("averageCombatPlayerScore")]
        public int AverageCombatPlayerScore { get; set; }

        /// <summary>
        /// Number of nodes captured per game on average, dominion only.
        /// </summary>
        [JsonProperty("averageNodeCapture")]
        public int AverageNodeCapture { get; set; }

        /// <summary>
        /// Number of assists on nodes captured per game on average, dominion only.
        /// </summary>
        [JsonProperty("averageNodeCaptureAssist")]
        public int AverageNodeCaptureAssist { get; set; }

        /// <summary>
        /// Number of nodes neutralized per game on average, dominion only.
        /// </summary>
        [JsonProperty("averageNodeNeutralize")]
        public int AverageNodeNeutralize { get; set; }

        /// <summary>
        /// Number of assists on nodes neutralized per game on average, dominion only.
        /// </summary>
        [JsonProperty("averageNodeNeutralizeAssist")]
        public int AverageNodeNeutralizeAssist { get; set; }

        /// <summary>
        /// Number of deaths per game on average, dominion only.
        /// </summary>
        [JsonProperty("averageNumDeaths")]
        public int AverageNumDeaths { get; set; }

        /// <summary>
        /// Objective score per game on average, dominion only.
        /// </summary>
        [JsonProperty("averageObjectivePlayerScore")]
        public int AverageObjectivePlayerScore { get; set; }

        /// <summary>
        /// Number of team objectives per game on average, dominion only.
        /// </summary>
        [JsonProperty("averageTeamObjective")]
        public int AverageTeamObjective { get; set; }

        /// <summary>
        /// Total score per game on average, dominion only.
        /// </summary>
        [JsonProperty("averageTotalPlayerScore")]
        public int AverageTotalPlayerScore { get; set; }

        /// <summary>
        /// Number of bot games played.
        /// </summary>
        [JsonProperty("botGamesPlayed")]
        public int BotGamesPlayed { get; set; }

        /// <summary>
        /// Number of killing sprees.
        /// </summary>
        [JsonProperty("killingSpree")]
        public int KillingSpree { get; set; }

        /// <summary>
        /// Maximum number of assists in a game, dominion only.
        /// </summary>
        [JsonProperty("maxAssists")]
        public int MaxAssists { get; set; }

        /// <summary>
        /// Maximum number of champions killed in a game.
        /// </summary>
        [JsonProperty("maxChampionsKilled")]
        public int MaxChampionsKilled { get; set; }

        /// <summary>
        /// Maximum combat player score in a game, dominion only.
        /// </summary>
        [JsonProperty("maxCombatPlayerScore")]
        public int MaxCombatPlayerScore { get; set; }

        /// <summary>
        /// Largest critical strike.
        /// </summary>
        [JsonProperty("maxLargestCriticalStrike")]
        public int MaxLargestCriticalStrike { get; set; }

        /// <summary>
        /// Largest killing spree.
        /// </summary>
        [JsonProperty("maxLargestKillingSpree")]
        public int MaxLargestKillingSpree { get; set; }

        /// <summary>
        /// Maximum number of nodes captured in a game, dominion only.
        /// </summary>
        [JsonProperty("maxNodeCapture")]
        public int MaxNodeCapture { get; set; }

        /// <summary>
        /// Maximum number of assists on nodes captured in a game, dominion only.
        /// </summary>
        [JsonProperty("maxNodeCaptureAssist")]
        public int MaxNodeCaptureAssist { get; set; }

        /// <summary>
        /// Maximum number of nodes neutralized in a game, dominion only.
        /// </summary>
        [JsonProperty("maxNodeNeutralize")]
        public int MaxNodeNeutralize { get; set; }

        /// <summary>
        /// Maximum number of assists on nodes neutralized in a game, dominion only.
        /// </summary>
        [JsonProperty("maxNodeNeutralizeAssist")]
        public int MaxNodeNeutralizeAssist { get; set; }

        /// <summary>
        /// Maximum objective score in a game, dominion only.
        /// </summary>
        [JsonProperty("maxObjectivePlayerscore")]
        public int MaxObjectivePlayerScore { get; set; }

        /// <summary>
        /// Maximum number of team objectives in a game, dominion only.
        /// </summary>
        [JsonProperty("maxTeamObjective")]
        public int MaxTeamObjective { get; set; }

        /// <summary>
        /// Maximum number of times played.
        /// </summary>
        [JsonProperty("maxTimePlayed")]
        public int MaxTimePlayed { get; set; }

        /// <summary>
        /// Longest time you have spent alive in a game.
        /// </summary>
        [JsonProperty("maxTimeSpentLiving")]
        public int MaxTimeSpentLiving { get; set; }

        /// <summary>
        /// Maximum total score in a game, dominion only.
        /// </summary>
        [JsonProperty("maxTotalPlayerScore")]
        public int MaxTotalPlayerScore { get; set; }

        /// <summary>
        /// Maximum number of champions killed per session.
        /// </summary>
        [JsonProperty("mostChampionKillsPerSession")]
        public int MostChampionKillsPerSession { get; set; }

        /// <summary>
        /// Maximum number of spells cast per sessions.
        /// </summary>
        [JsonProperty("mostSpellsCast")]
        public int MostSpellsCast { get; set; }

        /// <summary>
        /// Number of normal games played.
        /// </summary>
        [JsonProperty("normalGamesPlayed")]
        public int NormalGamesPlayed { get; set; }

        /// <summary>
        /// Number of ranked premade games played.
        /// </summary>
        [JsonProperty("rankedPremadeGamesPlayed")]
        public int RankedPremadeGamesPlayed { get; set; }

        /// <summary>
        /// Number of ranked solo games played.
        /// </summary>
        [JsonProperty("rankedSoloGamesPlayed")]
        public int RankedSoloGamesPlayed { get; set; }

        /// <summary>
        /// Total number of assists.
        /// </summary>
        [JsonProperty("totalAssists")]
        public int TotalAssists { get; set; }

        /// <summary>
        /// Total number of champion kills.
        /// </summary>
        [JsonProperty("totalChampionKills")]
        public int TotalChampionKills { get; set; }

        /// <summary>
        /// Total number of damages dealt.
        /// </summary>
        [JsonProperty("totalDamageDealt")]
        public int TotalDamageDealt { get; set; }

        /// <summary>
        /// Total number of damages taken.
        /// </summary>
        [JsonProperty("totalDamageTaken")]
        public int TotalDamageTaken { get; set; }

        /// <summary>
        /// Total number of double kills.
        /// </summary>
        [JsonProperty("totalDoubleKills")]
        public int TotalDoubleKills { get; set; }

        /// <summary>
        /// Total number of first bloods.
        /// </summary>
        [JsonProperty("totalFirstBlood")]
        public int TotalFirstBlood { get; set; }

        /// <summary>
        /// Total gold earned.
        /// </summary>
        [JsonProperty("totalGoldEarned")]
        public int TotalGoldEarned { get; set; }

        /// <summary>
        /// Total heal.
        /// </summary>
        [JsonProperty("totalHeal")]
        public int TotalHeal { get; set; }

        /// <summary>
        /// Total number of magic damages dealt.
        /// </summary>
        [JsonProperty("totalMagicDamageDealt")]
        public int TotalMagicDamageDealt { get; set; }

        /// <summary>
        /// Total number of minions killed.
        /// </summary>
        [JsonProperty("totalMinionKills")]
        public int TotalMinionKills { get; set; }

        /// <summary>
        /// Total number of neutral minions killed.
        /// </summary>
        [JsonProperty("totalNeutralMinionsKilled")]
        public int TotalNeutralMinionsKilled { get; set; }

        /// <summary>
        /// Total number of nodes captured, dominion only.
        /// </summary>
        [JsonProperty("totalNodeCapture")]
        public int TotalNodeCapture { get; set; }

        /// <summary>
        /// Total number of nodes neutralized, dominion only.
        /// </summary>
        [JsonProperty("totalNodeNeutralize")]
        public int TotalNodeNeutralize { get; set; }

        /// <summary>
        /// Total number of penta kills.
        /// </summary>
        [JsonProperty("totalPentaKills")]
        public int TotalPentaKills { get; set; }

        /// <summary>
        /// Total number of physical damages dealt.
        /// </summary>
        [JsonProperty("totalPhysicalDamageDealt")]
        public int TotalPhysicalDamageDealt { get; set; }

        /// <summary>
        /// Total number of quadra kills.
        /// </summary>
        [JsonProperty("totalQuadraKills")]
        public int TotalQuadraKills { get; set; }

        /// <summary>
        /// Total number of sessions lost.
        /// </summary>
        [JsonProperty("totalSessionsLost")]
        public int TotalSessionsLost { get; set; }

        /// <summary>
        /// Total number of sessions played.
        /// </summary>
        [JsonProperty("totalSessionsPlayed")]
        public int TotalSessionsPlayed { get; set; }

        /// <summary>
        /// Total number of sessions won.
        /// </summary>
        [JsonProperty("totalSessionsWon")]
        public int TotalSessionsWon { get; set; }

        /// <summary>
        /// Total number of triple kills.
        /// </summary>
        [JsonProperty("totalTripleKills")]
        public int TotalTripleKills { get; set; }

        /// <summary>
        /// Total number of turrets killed.
        /// </summary>
        [JsonProperty("totalTurretsKilled")]
        public int TotalTurretsKilled { get; set; }

        /// <summary>
        /// Total number of unreal kills.
        /// </summary>
        [JsonProperty("totalUnrealKills")]
        public int TotalUnrealKills { get; set; }
    }
}
