using Newtonsoft.Json;

namespace RiotSharp.Endpoints.MatchEndpoint
{
    /// <summary>
    /// Class gathering statistics about a participant (Match API).
    /// </summary>
    public class ParticipantStats
    {
        internal ParticipantStats() { }

        /// <summary>
        /// Number of assists.
        /// </summary>
        [JsonProperty("assists")]
        public long Assists { get; set; }

        /// <summary>
        /// Champion level achieved.
        /// </summary>
        [JsonProperty("champLevel")]
        public long ChampLevel { get; set; }

        /// <summary>
        /// If game was a dominion game, player's combat score, otherwise 0.
        /// </summary>
        [JsonProperty("combatPlayerScore")]
        public long CombatPlayerScore { get; set; }

        /// <summary>
        /// Number of deaths.
        /// </summary>
        [JsonProperty("deaths")]
        public long Deaths { get; set; }

        /// <summary>
        /// Number of double kills.
        /// </summary>
        [JsonProperty("doubleKills")]
        public long DoubleKills { get; set; }

        /// <summary>
        /// Flag indicating if participant got an assist on first blood.
        /// </summary>
        [JsonProperty("firstBloodAssist")]
        public bool FirstBloodAssist { get; set; }

        /// <summary>
        /// Flag indicating if participant got first blood.
        /// </summary>
        [JsonProperty("firstBloodKill")]
        public bool FirstBloodKill { get; set; }

        /// <summary>
        /// Flag indicating if participant got an assist on the first inhibitor.
        /// </summary>
        [JsonProperty("firstInhibitorAssist")]
        public bool FirstInhibitorAssist { get; set; }

        /// <summary>
        /// Flag indicating if participant destroyed the first inhibitor.
        /// </summary>
        [JsonProperty("firstInhibitorKill")]
        public bool FirstInhibitorKill { get; set; }

        /// <summary>
        /// Flag indicating if participant got an assist on the first tower.
        /// </summary>
        [JsonProperty("firstTowerAssist")]
        public bool FirstTowerAssist { get; set; }

        /// <summary>
        /// Flag indicating if participant destroyed the first tower.
        /// </summary>
        [JsonProperty("firstTowerKill")]
        public bool FirstTowerKill { get; set; }

        /// <summary>
        /// Gold earned.
        /// </summary>
        [JsonProperty("goldEarned")]
        public long GoldEarned { get; set; }

        /// <summary>
        /// Gold spent.
        /// </summary>
        [JsonProperty("goldSpent")]
        public long GoldSpent { get; set; }

        /// <summary>
        /// Numer of inhibitor kills.
        /// </summary>
        [JsonProperty("inhibitorKills")]
        public long InhibitorKills { get; set; }

        /// <summary>
        /// First item ID.
        /// </summary>
        [JsonProperty("item0")]
        public long Item0 { get; set; }

        /// <summary>
        /// Second item ID.
        /// </summary>
        [JsonProperty("item1")]
        public long Item1 { get; set; }

        /// <summary>
        /// Third item ID.
        /// </summary>
        [JsonProperty("item2")]
        public long Item2 { get; set; }

        /// <summary>
        /// Fourth item ID.
        /// </summary>
        [JsonProperty("item3")]
        public long Item3 { get; set; }

        /// <summary>
        /// Fifth item ID.
        /// </summary>
        [JsonProperty("item4")]
        public long Item4 { get; set; }

        /// <summary>
        /// Sixth item ID.
        /// </summary>
        [JsonProperty("item5")]
        public long Item5 { get; set; }

        /// <summary>
        /// Seventh item ID.
        /// </summary>
        [JsonProperty("item6")]
        public long Item6 { get; set; }

        /// <summary>
        /// Number of killing sprees.
        /// </summary>
        [JsonProperty("killingSprees")]
        public long KillingSprees { get; set; }

        /// <summary>
        /// Number of kills.
        /// </summary>
        [JsonProperty("kills")]
        public long Kills { get; set; }

        /// <summary>
        /// Largest critical strike.
        /// </summary>
        [JsonProperty("largestCriticalStrike")]
        public long LargestCriticalStrike { get; set; }

        /// <summary>
        /// Largest killing spree.
        /// </summary>
        [JsonProperty("largestKillingSpree")]
        public long LargestKillingSpree { get; set; }

        /// <summary>
        /// Largest multi kill.
        /// </summary>
        [JsonProperty("largestMultiKill")]
        public long LargestMultiKill { get; set; }

        /// <summary>
        /// Magic damage dealt.
        /// </summary>
        [JsonProperty("magicDamageDealt")]
        public long MagicDamageDealt { get; set; }

        /// <summary>
        /// Magic damage dealt to champions.
        /// </summary>
        [JsonProperty("magicDamageDealtToChampions")]
        public long MagicDamageDealtToChampions { get; set; }

        /// <summary>
        /// Magic damage taken.
        /// </summary>
        [JsonProperty("magicDamageTaken")]
        public long MagicDamageTaken { get; set; }

        /// <summary>
        /// Minions kiled.
        /// </summary>
        [JsonProperty("totalMinionsKilled")]
        public long TotalMinionsKilled { get; set; }

        /// <summary>
        /// Neutral minions killed.
        /// </summary>
        [JsonProperty("neutralMinionsKilled")]
        public long NeutralMinionsKilled { get; set; }

        /// <summary>
        /// Neutral jungle minions killed in the enemy team's jungle.
        /// </summary>
        [JsonProperty("neutralMinionsKilledEnemyJungle")]
        public long NeutralMinionsKilledEnemyJungle { get; set; }

        /// <summary>
        /// Neutral jungle minions killed in your team's jungle.
        /// </summary>
        [JsonProperty("neutralMinionsKilledTeamJungle")]
        public long NeutralMinionsKilledJungle { get; set; }

        /// <summary>
        /// If game was a dominion game, number of node captures.
        /// </summary>
        [JsonProperty("nodeCapture")]
        public long NodeCapture { get; set; }

        /// <summary>
        /// If game was a dominion game, number of node capture assists.
        /// </summary>
        [JsonProperty("nodeCaptureAssist")]
        public long NodeCaptureAssist { get; set; }

        /// <summary>
        /// If game was a dominion game, number of node neutralizations.
        /// </summary>
        [JsonProperty("nodeNeutralize")]
        public long NodeNeutralize { get; set; }

        /// <summary>
        /// If game was a dominion game, number of node neutralization assists.
        /// </summary>
        [JsonProperty("nodeNeutralizeAssist")]
        public long NodeNeutralizeAssist { get; set; }

        /// <summary>
        /// If game was a dominion game, player's objectives score, otherwise 0.
        /// </summary>
        [JsonProperty("objectivePlayerScore")]
        public long ObjectivePlayerScore { get; set; }

        /// <summary>
        /// Number of penta kills.
        /// </summary>
        [JsonProperty("pentaKills")]
        public long PentaKills { get; set; }

        /// <summary>
        /// Physical damage dealt.
        /// </summary>
        [JsonProperty("physicalDamageDealt")]
        public long PhysicalDamageDealt { get; set; }

        /// <summary>
        /// Physical damage dealt to champions.
        /// </summary>
        [JsonProperty("physicalDamageDealtToChampions")]
        public long PhysicalDamageDealtToChampions { get; set; }

        /// <summary>
        /// Physical damage taken.
        /// </summary>
        [JsonProperty("physicalDamageTaken")]
        public long PhysicalDamageTaken { get; set; }

        /// <summary>
        /// Number of quadra kills.
        /// </summary>
        [JsonProperty("quadraKills")]
        public long QuadraKills { get; set; }

        /// <summary>
        /// Number of sight wards purchased.
        /// </summary>
        [JsonProperty("sightWardsBoughtInGame")]
        public long SightWardsBoughtInGame { get; set; }

        /// <summary>
        /// If game was a dominion game, number of completed team objectives (i.e., quests).
        /// </summary>
        [JsonProperty("teamObjective")]
        public long TeamObjective { get; set; }

        /// <summary>
        /// Total damage dealt.
        /// </summary>
        [JsonProperty("totalDamageDealt")]
        public long TotalDamageDealt { get; set; }

        /// <summary>
        /// Total damage dealt to champions.
        /// </summary>
        [JsonProperty("totalDamageDealtToChampions")]
        public long TotalDamageDealtToChampions { get; set; }

        /// <summary>
        /// Total damage taken.
        /// </summary>
        [JsonProperty("totalDamageTaken")]
        public long TotalDamageTaken { get; set; }

        /// <summary>
        /// Total heal.
        /// </summary>
        [JsonProperty("totalHeal")]
        public long TotalHeal { get; set; }

        /// <summary>
        /// If game was a dominion game, player's total score, otherwise 0.
        /// </summary>
        [JsonProperty("totalPlayerScore")]
        public long TotalPlayerScore { get; set; }

        /// <summary>
        /// If game was a dominion game, team rank of the player's total score (e.g., 1-5).
        /// </summary>
        [JsonProperty("totalScoreRank")]
        public long TotalScoreRank { get; set; }

        /// <summary>
        /// Total time crowd control dealt.
        /// </summary>
        [JsonProperty("totalTimeCrowdControlDealt")]
        public long TotalTimeCrowdControlDealt { get; set; }

        /// <summary>
        /// Total units healed.
        /// </summary>
        [JsonProperty("totalUnitsHealed")]
        public long TotalUnitsHealed { get; set; }

        /// <summary>
        /// Number of tower kills.
        /// </summary>
        [JsonProperty("towerKills")]
        public long TowerKills { get; set; }

        /// <summary>
        /// Number of triple kills.
        /// </summary>
        [JsonProperty("tripleKills")]
        public long TripleKills { get; set; }

        /// <summary>
        /// True damage dealt.
        /// </summary>
        [JsonProperty("trueDamageDealt")]
        public long TrueDamageDealt { get; set; }

        /// <summary>
        /// True damage dealt to champions.
        /// </summary>
        [JsonProperty("trueDamageDealtToChampions")]
        public long TrueDamageDealtToChampions { get; set; }

        /// <summary>
        /// True damage taken.
        /// </summary>
        [JsonProperty("trueDamageTaken")]
        public long TrueDamageTaken { get; set; }

        /// <summary>
        /// Number of unreal kills.
        /// </summary>
        [JsonProperty("unrealKills")]
        public long UnrealKills { get; set; }

        /// <summary>
        /// Vision score.
        /// </summary>
        [JsonProperty("visionScore")]
        public long VisionScore { get; set; }

        /// <summary>
        /// Number of vision wards purchased.
        /// </summary>
        [JsonProperty("visionWardsBoughtInGame")]
        public long VisionWardsBoughtInGame { get; set; }

        /// <summary>
        /// Number of wards killed.
        /// </summary>
        [JsonProperty("wardsKilled")]
        public long WardsKilled { get; set; }

        /// <summary>
        /// Number of wards placed.
        /// </summary>
        [JsonProperty("wardsPlaced")]
        public long WardsPlaced { get; set; }

        /// <summary>
        /// Flag indicating whether or not the participant won.
        /// </summary>
        [JsonProperty("win")]
        public bool Winner { get; set; }

        #region Perk Stats
        /// <summary>
        /// Primary rune path.
        /// </summary>
        [JsonProperty("perkPrimaryStyle")]
        public int PerkPrimaryStyle { get; set; }
        /// <summary>
        /// Secondary rune path.
        /// </summary>
        [JsonProperty("perkSubStyle")]
        public int PerkSubStyle { get; set; }

        /// <summary>
        /// Primary path keystone rune.
        /// </summary>
        [JsonProperty("perk0")]
        public int Perk0 { get; set; }
        /// <summary>
        /// Primary path rune.
        /// </summary>
        [JsonProperty("perk1")]
        public int Perk1 { get; set; }
        /// <summary>
        /// Primary path rune.
        /// </summary>
        [JsonProperty("perk2")]
        public int Perk2 { get; set; }
        /// <summary>
        /// Primary path rune.
        /// </summary>
        [JsonProperty("perk3")]
        public int Perk3 { get; set; }
        /// <summary>
        /// Secondary path rune.
        /// </summary>
        [JsonProperty("perk4")]
        public int Perk4 { get; set; }
        /// <summary>
        /// Secondary path rune.
        /// </summary>
        [JsonProperty("perk5")]
        public int Perk5 { get; set; }

        /// <summary>
        /// Post game rune stat of Perk1.
        /// </summary>
        [JsonProperty("perk1Var1")]
        public int Perk1Var1 { get; set; }
        /// <summary>
        /// Post game rune stat of Perk1.
        /// </summary>
        [JsonProperty("perk1Var2")]
        public int Perk1Var2 { get; set; }
        /// <summary>
        /// Post game rune stat of Perk1.
        /// </summary>
        [JsonProperty("perk1Var3")]
        public int Perk1Var3 { get; set; }

        /// <summary>
        /// Post game rune stat of Perk2.
        /// </summary>
        [JsonProperty("perk2Var1")]
        public int Perk2Var1 { get; set; }
        /// <summary>
        /// Post game rune stat of Perk2.
        /// </summary>
        [JsonProperty("perk2Var2")]
        public int Perk2Var2 { get; set; }
        /// <summary>
        /// Post game rune stat of Perk2.
        /// </summary>
        [JsonProperty("perk2Var3")]
        public int Perk2Var3 { get; set; }

        /// <summary>
        /// Post game rune stat of Perk3.
        /// </summary>
        [JsonProperty("perk3Var1")]
        public int Perk3Var1 { get; set; }
        /// <summary>
        /// Post game rune stat of Perk3.
        /// </summary>
        [JsonProperty("perk3Var2")]
        public int Perk3Var2 { get; set; }
        /// <summary>
        /// Post game rune stat of Perk3.
        /// </summary>
        [JsonProperty("perk3Var3")]
        public int Perk3Var3 { get; set; }

        /// <summary>
        /// Post game rune stat of Perk4.
        /// </summary>
        [JsonProperty("perk4Var1")]
        public int Perk4Var1 { get; set; }
        /// <summary>
        /// Post game rune stat of Perk4.
        /// </summary>
        [JsonProperty("perk4Var2")]
        public int Perk4Var2 { get; set; }
        /// <summary>
        /// Post game rune stat of Perk4.
        /// </summary>
        [JsonProperty("perk4Var3")]
        public int Perk4Var3 { get; set; }

        /// <summary>
        /// Post game rune stat of Perk5.
        /// </summary>
        [JsonProperty("perk5Var1")]
        public int Perk5Var1 { get; set; }
        /// <summary>
        /// Post game rune stat of Perk5.
        /// </summary>
        [JsonProperty("perk5Var2")]
        public int Perk5Var2 { get; set; }
        /// <summary>
        /// Post game rune stat of Perk5.
        /// </summary>
        [JsonProperty("perk5Var3")]
        public int Perk5Var3 { get; set; }

        /// <summary>
        /// Rune stat
        /// </summary>
        [JsonProperty("statPerk0")]
        public int StatPerk0 { get; set; }

        /// <summary>
        /// Rune stat
        /// </summary>
        [JsonProperty("statPerk1")]
        public int StatPerk1 { get; set; }

        /// <summary>
        /// Rune stat
        /// </summary>
        [JsonProperty("statPerk2")]
        public int StatPerk2 { get; set; }
        #endregion
    }
}
