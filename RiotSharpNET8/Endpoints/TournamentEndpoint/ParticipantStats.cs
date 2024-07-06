using System.Text.Json.Serialization;

namespace RiotSharpNET8.Endpoints.TournamentEndpoint
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
        [JsonPropertyName("assists")]
        public long Assists { get; set; }

        /// <summary>
        /// Champion level achieved.
        /// </summary>
        [JsonPropertyName("champLevel")]
        public long ChampLevel { get; set; }

        /// <summary>
        /// If game was a dominion game, player's combat score, otherwise 0.
        /// </summary>
        [JsonPropertyName("combatPlayerScore")]
        public long CombatPlayerScore { get; set; }

        /// <summary>
        /// Number of deaths.
        /// </summary>
        [JsonPropertyName("deaths")]
        public long Deaths { get; set; }

        /// <summary>
        /// Number of double kills.
        /// </summary>
        [JsonPropertyName("doubleKills")]
        public long DoubleKills { get; set; }

        /// <summary>
        /// Flag indicating if participant got an assist on first blood.
        /// </summary>
        [JsonPropertyName("firstBloodAssist")]
        public bool FirstBloodAssist { get; set; }

        /// <summary>
        /// Flag indicating if participant got first blood.
        /// </summary>
        [JsonPropertyName("firstBloodKill")]
        public bool FirstBloodKill { get; set; }

        /// <summary>
        /// Flag indicating if participant got an assist on the first inhibitor.
        /// </summary>
        [JsonPropertyName("firstInhibitorAssist")]
        public bool FirstInhibitorAssist { get; set; }

        /// <summary>
        /// Flag indicating if participant destroyed the first inhibitor.
        /// </summary>
        [JsonPropertyName("firstInhibitorKill")]
        public bool FirstInhibitorKill { get; set; }

        /// <summary>
        /// Flag indicating if participant got an assist on the first tower.
        /// </summary>
        [JsonPropertyName("firstTowerAssist")]
        public bool FirstTowerAssist { get; set; }

        /// <summary>
        /// Flag indicating if participant destroyed the first tower.
        /// </summary>
        [JsonPropertyName("firstTowerKill")]
        public bool FirstTowerKill { get; set; }

        /// <summary>
        /// Gold earned.
        /// </summary>
        [JsonPropertyName("goldEarned")]
        public long GoldEarned { get; set; }

        /// <summary>
        /// Gold spent.
        /// </summary>
        [JsonPropertyName("goldSpent")]
        public long GoldSpent { get; set; }

        /// <summary>
        /// Numer of inhibitor kills.
        /// </summary>
        [JsonPropertyName("inhibitorKills")]
        public long InhibitorKills { get; set; }

        /// <summary>
        /// First item ID.
        /// </summary>
        [JsonPropertyName("item0")]
        public long Item0 { get; set; }

        /// <summary>
        /// Second item ID.
        /// </summary>
        [JsonPropertyName("item1")]
        public long Item1 { get; set; }

        /// <summary>
        /// Third item ID.
        /// </summary>
        [JsonPropertyName("item2")]
        public long Item2 { get; set; }

        /// <summary>
        /// Fourth item ID.
        /// </summary>
        [JsonPropertyName("item3")]
        public long Item3 { get; set; }

        /// <summary>
        /// Fifth item ID.
        /// </summary>
        [JsonPropertyName("item4")]
        public long Item4 { get; set; }

        /// <summary>
        /// Sixth item ID.
        /// </summary>
        [JsonPropertyName("item5")]
        public long Item5 { get; set; }

        /// <summary>
        /// Seventh item ID.
        /// </summary>
        [JsonPropertyName("item6")]
        public long Item6 { get; set; }

        /// <summary>
        /// Number of killing sprees.
        /// </summary>
        [JsonPropertyName("killingSprees")]
        public long KillingSprees { get; set; }

        /// <summary>
        /// Number of kills.
        /// </summary>
        [JsonPropertyName("kills")]
        public long Kills { get; set; }

        /// <summary>
        /// Largest critical strike.
        /// </summary>
        [JsonPropertyName("largestCriticalStrike")]
        public long LargestCriticalStrike { get; set; }

        /// <summary>
        /// Largest killing spree.
        /// </summary>
        [JsonPropertyName("largestKillingSpree")]
        public long LargestKillingSpree { get; set; }

        /// <summary>
        /// Largest multi kill.
        /// </summary>
        [JsonPropertyName("largestMultiKill")]
        public long LargestMultiKill { get; set; }

        /// <summary>
        /// Magic damage dealt.
        /// </summary>
        [JsonPropertyName("magicDamageDealt")]
        public long MagicDamageDealt { get; set; }

        /// <summary>
        /// Magic damage dealt to champions.
        /// </summary>
        [JsonPropertyName("magicDamageDealtToChampions")]
        public long MagicDamageDealtToChampions { get; set; }

        /// <summary>
        /// Magic damage taken.
        /// </summary>
        [JsonPropertyName("magicDamageTaken")]
        public long MagicDamageTaken { get; set; }

        /// <summary>
        /// Minions kiled.
        /// </summary>
        [JsonPropertyName("totalMinionsKilled")]
        public long TotalMinionsKilled { get; set; }

        /// <summary>
        /// Neutral minions killed.
        /// </summary>
        [JsonPropertyName("neutralMinionsKilled")]
        public long NeutralMinionsKilled { get; set; }

        /// <summary>
        /// Neutral jungle minions killed in the enemy team's jungle.
        /// </summary>
        [JsonPropertyName("neutralMinionsKilledEnemyJungle")]
        public long NeutralMinionsKilledEnemyJungle { get; set; }

        /// <summary>
        /// Neutral jungle minions killed in your team's jungle.
        /// </summary>
        [JsonPropertyName("neutralMinionsKilledTeamJungle")]
        public long NeutralMinionsKilledJungle { get; set; }

        /// <summary>
        /// If game was a dominion game, number of node captures.
        /// </summary>
        [JsonPropertyName("nodeCapture")]
        public long NodeCapture { get; set; }

        /// <summary>
        /// If game was a dominion game, number of node capture assists.
        /// </summary>
        [JsonPropertyName("nodeCaptureAssist")]
        public long NodeCaptureAssist { get; set; }

        /// <summary>
        /// If game was a dominion game, number of node neutralizations.
        /// </summary>
        [JsonPropertyName("nodeNeutralize")]
        public long NodeNeutralize { get; set; }

        /// <summary>
        /// If game was a dominion game, number of node neutralization assists.
        /// </summary>
        [JsonPropertyName("nodeNeutralizeAssist")]
        public long NodeNeutralizeAssist { get; set; }

        /// <summary>
        /// If game was a dominion game, player's objectives score, otherwise 0.
        /// </summary>
        [JsonPropertyName("objectivePlayerScore")]
        public long ObjectivePlayerScore { get; set; }

        /// <summary>
        /// Number of penta kills.
        /// </summary>
        [JsonPropertyName("pentaKills")]
        public long PentaKills { get; set; }

        /// <summary>
        /// Physical damage dealt.
        /// </summary>
        [JsonPropertyName("physicalDamageDealt")]
        public long PhysicalDamageDealt { get; set; }

        /// <summary>
        /// Physical damage dealt to champions.
        /// </summary>
        [JsonPropertyName("physicalDamageDealtToChampions")]
        public long PhysicalDamageDealtToChampions { get; set; }

        /// <summary>
        /// Physical damage taken.
        /// </summary>
        [JsonPropertyName("physicalDamageTaken")]
        public long PhysicalDamageTaken { get; set; }

        /// <summary>
        /// Number of quadra kills.
        /// </summary>
        [JsonPropertyName("quadraKills")]
        public long QuadraKills { get; set; }

        /// <summary>
        /// Number of sight wards purchased.
        /// </summary>
        [JsonPropertyName("sightWardsBoughtInGame")]
        public long SightWardsBoughtInGame { get; set; }

        /// <summary>
        /// If game was a dominion game, number of completed team objectives (i.e., quests).
        /// </summary>
        [JsonPropertyName("teamObjective")]
        public long TeamObjective { get; set; }

        /// <summary>
        /// Total damage dealt.
        /// </summary>
        [JsonPropertyName("totalDamageDealt")]
        public long TotalDamageDealt { get; set; }

        /// <summary>
        /// Total damage dealt to champions.
        /// </summary>
        [JsonPropertyName("totalDamageDealtToChampions")]
        public long TotalDamageDealtToChampions { get; set; }

        /// <summary>
        /// Total damage taken.
        /// </summary>
        [JsonPropertyName("totalDamageTaken")]
        public long TotalDamageTaken { get; set; }

        /// <summary>
        /// Total heal.
        /// </summary>
        [JsonPropertyName("totalHeal")]
        public long TotalHeal { get; set; }

        /// <summary>
        /// If game was a dominion game, player's total score, otherwise 0.
        /// </summary>
        [JsonPropertyName("totalPlayerScore")]
        public long TotalPlayerScore { get; set; }

        /// <summary>
        /// If game was a dominion game, team rank of the player's total score (e.g., 1-5).
        /// </summary>
        [JsonPropertyName("totalScoreRank")]
        public long TotalScoreRank { get; set; }

        /// <summary>
        /// Total time crowd control dealt.
        /// </summary>
        [JsonPropertyName("totalTimeCrowdControlDealt")]
        public long TotalTimeCrowdControlDealt { get; set; }

        /// <summary>
        /// Total units healed.
        /// </summary>
        [JsonPropertyName("totalUnitsHealed")]
        public long TotalUnitsHealed { get; set; }

        /// <summary>
        /// Number of tower kills.
        /// </summary>
        [JsonPropertyName("towerKills")]
        public long TowerKills { get; set; }

        /// <summary>
        /// Number of triple kills.
        /// </summary>
        [JsonPropertyName("tripleKills")]
        public long TripleKills { get; set; }

        /// <summary>
        /// True damage dealt.
        /// </summary>
        [JsonPropertyName("trueDamageDealt")]
        public long TrueDamageDealt { get; set; }

        /// <summary>
        /// True damage dealt to champions.
        /// </summary>
        [JsonPropertyName("trueDamageDealtToChampions")]
        public long TrueDamageDealtToChampions { get; set; }

        /// <summary>
        /// True damage taken.
        /// </summary>
        [JsonPropertyName("trueDamageTaken")]
        public long TrueDamageTaken { get; set; }

        /// <summary>
        /// Number of unreal kills.
        /// </summary>
        [JsonPropertyName("unrealKills")]
        public long UnrealKills { get; set; }

        /// <summary>
        /// Vision score.
        /// </summary>
        [JsonPropertyName("visionScore")]
        public long VisionScore { get; set; }

        /// <summary>
        /// Number of vision wards purchased.
        /// </summary>
        [JsonPropertyName("visionWardsBoughtInGame")]
        public long VisionWardsBoughtInGame { get; set; }

        /// <summary>
        /// Number of wards killed.
        /// </summary>
        [JsonPropertyName("wardsKilled")]
        public long WardsKilled { get; set; }

        /// <summary>
        /// Number of wards placed.
        /// </summary>
        [JsonPropertyName("wardsPlaced")]
        public long WardsPlaced { get; set; }

        /// <summary>
        /// Flag indicating whether or not the participant won.
        /// </summary>
        [JsonPropertyName("win")]
        public bool Winner { get; set; }

        #region Perk Stats
        /// <summary>
        /// Primary rune path.
        /// </summary>
        [JsonPropertyName("perkPrimaryStyle")]
        public int PerkPrimaryStyle { get; set; }
        /// <summary>
        /// Secondary rune path.
        /// </summary>
        [JsonPropertyName("perkSubStyle")]
        public int PerkSubStyle { get; set; }

        /// <summary>
        /// Primary path keystone rune.
        /// </summary>
        [JsonPropertyName("perk0")]
        public int Perk0 { get; set; }
        /// <summary>
        /// Primary path rune.
        /// </summary>
        [JsonPropertyName("perk1")]
        public int Perk1 { get; set; }
        /// <summary>
        /// Primary path rune.
        /// </summary>
        [JsonPropertyName("perk2")]
        public int Perk2 { get; set; }
        /// <summary>
        /// Primary path rune.
        /// </summary>
        [JsonPropertyName("perk3")]
        public int Perk3 { get; set; }
        /// <summary>
        /// Secondary path rune.
        /// </summary>
        [JsonPropertyName("perk4")]
        public int Perk4 { get; set; }
        /// <summary>
        /// Secondary path rune.
        /// </summary>
        [JsonPropertyName("perk5")]
        public int Perk5 { get; set; }

        /// <summary>
        /// Post game rune stat of Perk1.
        /// </summary>
        [JsonPropertyName("perk1Var1")]
        public int Perk1Var1 { get; set; }
        /// <summary>
        /// Post game rune stat of Perk1.
        /// </summary>
        [JsonPropertyName("perk1Var2")]
        public int Perk1Var2 { get; set; }
        /// <summary>
        /// Post game rune stat of Perk1.
        /// </summary>
        [JsonPropertyName("perk1Var3")]
        public int Perk1Var3 { get; set; }

        /// <summary>
        /// Post game rune stat of Perk2.
        /// </summary>
        [JsonPropertyName("perk2Var1")]
        public int Perk2Var1 { get; set; }
        /// <summary>
        /// Post game rune stat of Perk2.
        /// </summary>
        [JsonPropertyName("perk2Var2")]
        public int Perk2Var2 { get; set; }
        /// <summary>
        /// Post game rune stat of Perk2.
        /// </summary>
        [JsonPropertyName("perk2Var3")]
        public int Perk2Var3 { get; set; }

        /// <summary>
        /// Post game rune stat of Perk3.
        /// </summary>
        [JsonPropertyName("perk3Var1")]
        public int Perk3Var1 { get; set; }
        /// <summary>
        /// Post game rune stat of Perk3.
        /// </summary>
        [JsonPropertyName("perk3Var2")]
        public int Perk3Var2 { get; set; }
        /// <summary>
        /// Post game rune stat of Perk3.
        /// </summary>
        [JsonPropertyName("perk3Var3")]
        public int Perk3Var3 { get; set; }

        /// <summary>
        /// Post game rune stat of Perk4.
        /// </summary>
        [JsonPropertyName("perk4Var1")]
        public int Perk4Var1 { get; set; }
        /// <summary>
        /// Post game rune stat of Perk4.
        /// </summary>
        [JsonPropertyName("perk4Var2")]
        public int Perk4Var2 { get; set; }
        /// <summary>
        /// Post game rune stat of Perk4.
        /// </summary>
        [JsonPropertyName("perk4Var3")]
        public int Perk4Var3 { get; set; }

        /// <summary>
        /// Post game rune stat of Perk5.
        /// </summary>
        [JsonPropertyName("perk5Var1")]
        public int Perk5Var1 { get; set; }
        /// <summary>
        /// Post game rune stat of Perk5.
        /// </summary>
        [JsonPropertyName("perk5Var2")]
        public int Perk5Var2 { get; set; }
        /// <summary>
        /// Post game rune stat of Perk5.
        /// </summary>
        [JsonPropertyName("perk5Var3")]
        public int Perk5Var3 { get; set; }

        /// <summary>
        /// Rune stat
        /// </summary>
        [JsonPropertyName("statPerk0")]
        public int StatPerk0 { get; set; }

        /// <summary>
        /// Rune stat
        /// </summary>
        [JsonPropertyName("statPerk1")]
        public int StatPerk1 { get; set; }

        /// <summary>
        /// Rune stat
        /// </summary>
        [JsonPropertyName("statPerk2")]
        public int StatPerk2 { get; set; }
        #endregion
    }
}
