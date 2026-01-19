using System.Text.Json.Serialization;

namespace RiotSharp.LeagueOfLegends.Endpoints.MatchEndpoint.Models
{
    /// <summary>
    /// Class representing participant challenges/achievements in a match.
    /// </summary>
    public class Challenges
    {
        [JsonPropertyName("12AssistStreakCount")]
        public int? AssistStreakCount12 { get; set; }

        [JsonPropertyName("baronBuffGoldAdvantageOverThreshold")]
        public int? BaronBuffGoldAdvantageOverThreshold { get; set; }

        [JsonPropertyName("controlWardTimeCoverageInRiverOrEnemyHalf")]
        public float? ControlWardTimeCoverageInRiverOrEnemyHalf { get; set; }

        [JsonPropertyName("earliestBaron")]
        public int? EarliestBaron { get; set; }

        [JsonPropertyName("earliestDragonTakedown")]
        public int? EarliestDragonTakedown { get; set; }

        [JsonPropertyName("earliestElderDragon")]
        public int? EarliestElderDragon { get; set; }

        [JsonPropertyName("earlyLaningPhaseGoldExpAdvantage")]
        public int? EarlyLaningPhaseGoldExpAdvantage { get; set; }

        [JsonPropertyName("fasterSupportQuestCompletion")]
        public int? FasterSupportQuestCompletion { get; set; }

        [JsonPropertyName("fastestLegendary")]
        public int? FastestLegendary { get; set; }

        [JsonPropertyName("hadAfkTeammate")]
        public int? HadAfkTeammate { get; set; }

        [JsonPropertyName("highestChampionDamage")]
        public int? HighestChampionDamage { get; set; }

        [JsonPropertyName("highestCrowdControlScore")]
        public int? HighestCrowdControlScore { get; set; }

        [JsonPropertyName("highestWardKills")]
        public int? HighestWardKills { get; set; }

        [JsonPropertyName("junglerKillsEarlyJungle")]
        public int? JunglerKillsEarlyJungle { get; set; }

        [JsonPropertyName("killsOnLanersEarlyJungleAsJungler")]
        public int? KillsOnLanersEarlyJungleAsJungler { get; set; }

        [JsonPropertyName("laningPhaseGoldExpAdvantage")]
        public int? LaningPhaseGoldExpAdvantage { get; set; }

        [JsonPropertyName("legendaryCount")]
        public int? LegendaryCount { get; set; }

        [JsonPropertyName("maxCsAdvantageOnLaneOpponent")]
        public float? MaxCsAdvantageOnLaneOpponent { get; set; }

        [JsonPropertyName("maxLevelLeadLaneOpponent")]
        public int? MaxLevelLeadLaneOpponent { get; set; }

        [JsonPropertyName("mostWardsDestroyedOneSweeper")]
        public int? MostWardsDestroyedOneSweeper { get; set; }

        [JsonPropertyName("mythicItemUsed")]
        public int? MythicItemUsed { get; set; }

        [JsonPropertyName("playedChampSelectPosition")]
        public int? PlayedChampSelectPosition { get; set; }

        [JsonPropertyName("soloTurretsLategame")]
        public int? SoloTurretsLategame { get; set; }

        [JsonPropertyName("takedownsFirst25Minutes")]
        public int? TakedownsFirst25Minutes { get; set; }

        [JsonPropertyName("teleportTakedowns")]
        public int? TeleportTakedowns { get; set; }

        [JsonPropertyName("thirdInhibitorDestroyedTime")]
        public int? ThirdInhibitorDestroyedTime { get; set; }

        [JsonPropertyName("threeWardsOneSweeperCount")]
        public int? ThreeWardsOneSweeperCount { get; set; }

        [JsonPropertyName("visionScoreAdvantageLaneOpponent")]
        public float? VisionScoreAdvantageLaneOpponent { get; set; }

        [JsonPropertyName("InfernalScalePickup")]
        public int? InfernalScalePickup { get; set; }

        [JsonPropertyName("fistBumpParticipation")]
        public int? FistBumpParticipation { get; set; }

        [JsonPropertyName("voidMonsterKill")]
        public int? VoidMonsterKill { get; set; }

        [JsonPropertyName("abilityUses")]
        public int? AbilityUses { get; set; }

        [JsonPropertyName("acesBefore15Minutes")]
        public int? AcesBefore15Minutes { get; set; }

        [JsonPropertyName("alliedJungleMonsterKills")]
        public float? AlliedJungleMonsterKills { get; set; }

        [JsonPropertyName("baronTakedowns")]
        public int? BaronTakedowns { get; set; }

        [JsonPropertyName("blastConeOppositeOpponentCount")]
        public int? BlastConeOppositeOpponentCount { get; set; }

        [JsonPropertyName("bountyGold")]
        public int? BountyGold { get; set; }

        [JsonPropertyName("buffsStolen")]
        public int? BuffsStolen { get; set; }

        [JsonPropertyName("completeSupportQuestInTime")]
        public int? CompleteSupportQuestInTime { get; set; }

        [JsonPropertyName("controlWardsPlaced")]
        public int? ControlWardsPlaced { get; set; }

        [JsonPropertyName("damagePerMinute")]
        public float? DamagePerMinute { get; set; }

        [JsonPropertyName("damageTakenOnTeamPercentage")]
        public float? DamageTakenOnTeamPercentage { get; set; }

        [JsonPropertyName("dancedWithRiftHerald")]
        public int? DancedWithRiftHerald { get; set; }

        [JsonPropertyName("deathsByEnemyChamps")]
        public int? DeathsByEnemyChamps { get; set; }

        [JsonPropertyName("dodgeSkillShotsSmallWindow")]
        public int? DodgeSkillShotsSmallWindow { get; set; }

        [JsonPropertyName("doubleAces")]
        public int? DoubleAces { get; set; }

        [JsonPropertyName("dragonTakedowns")]
        public int? DragonTakedowns { get; set; }

        [JsonPropertyName("legendaryItemUsed")]
        public List<int>? LegendaryItemUsed { get; set; }

        [JsonPropertyName("effectiveHealAndShielding")]
        public float? EffectiveHealAndShielding { get; set; }

        [JsonPropertyName("elderDragonKillsWithOpposingSoul")]
        public int? ElderDragonKillsWithOpposingSoul { get; set; }

        [JsonPropertyName("elderDragonMultikills")]
        public int? ElderDragonMultikills { get; set; }

        [JsonPropertyName("enemyChampionImmobilizations")]
        public int? EnemyChampionImmobilizations { get; set; }

        [JsonPropertyName("enemyJungleMonsterKills")]
        public float? EnemyJungleMonsterKills { get; set; }

        [JsonPropertyName("epicMonsterKillsNearEnemyJungler")]
        public int? EpicMonsterKillsNearEnemyJungler { get; set; }

        [JsonPropertyName("epicMonsterKillsWithin30SecondsOfSpawn")]
        public int? EpicMonsterKillsWithin30SecondsOfSpawn { get; set; }

        [JsonPropertyName("epicMonsterSteals")]
        public int? EpicMonsterSteals { get; set; }

        [JsonPropertyName("epicMonsterStolenWithoutSmite")]
        public int? EpicMonsterStolenWithoutSmite { get; set; }

        [JsonPropertyName("firstTurretKilled")]
        public int? FirstTurretKilled { get; set; }

        [JsonPropertyName("firstTurretKilledTime")]
        public float? FirstTurretKilledTime { get; set; }

        [JsonPropertyName("flawlessAces")]
        public int? FlawlessAces { get; set; }

        [JsonPropertyName("fullTeamTakedown")]
        public int? FullTeamTakedown { get; set; }

        [JsonPropertyName("gameLength")]
        public float? GameLength { get; set; }

        [JsonPropertyName("getTakedownsInAllLanesEarlyJungleAsLaner")]
        public int? GetTakedownsInAllLanesEarlyJungleAsLaner { get; set; }

        [JsonPropertyName("goldPerMinute")]
        public float? GoldPerMinute { get; set; }

        [JsonPropertyName("hadOpenNexus")]
        public int? HadOpenNexus { get; set; }

        [JsonPropertyName("immobilizeAndKillWithAlly")]
        public int? ImmobilizeAndKillWithAlly { get; set; }

        [JsonPropertyName("initialBuffCount")]
        public int? InitialBuffCount { get; set; }

        [JsonPropertyName("initialCrabCount")]
        public int? InitialCrabCount { get; set; }

        [JsonPropertyName("jungleCsBefore10Minutes")]
        public float? JungleCsBefore10Minutes { get; set; }

        [JsonPropertyName("junglerTakedownsNearDamagedEpicMonster")]
        public int? JunglerTakedownsNearDamagedEpicMonster { get; set; }

        [JsonPropertyName("kda")]
        public float? Kda { get; set; }

        [JsonPropertyName("killAfterHiddenWithAlly")]
        public int? KillAfterHiddenWithAlly { get; set; }

        [JsonPropertyName("killedChampTookFullTeamDamageSurvived")]
        public int? KilledChampTookFullTeamDamageSurvived { get; set; }

        [JsonPropertyName("killingSprees")]
        public int? KillingSprees { get; set; }

        [JsonPropertyName("killParticipation")]
        public float? KillParticipation { get; set; }

        [JsonPropertyName("killsNearEnemyTurret")]
        public int? KillsNearEnemyTurret { get; set; }

        [JsonPropertyName("killsOnOtherLanesEarlyJungleAsLaner")]
        public int? KillsOnOtherLanesEarlyJungleAsLaner { get; set; }

        [JsonPropertyName("killsOnRecentlyHealedByAramPack")]
        public int? KillsOnRecentlyHealedByAramPack { get; set; }

        [JsonPropertyName("killsUnderOwnTurret")]
        public int? KillsUnderOwnTurret { get; set; }

        [JsonPropertyName("killsWithHelpFromEpicMonster")]
        public int? KillsWithHelpFromEpicMonster { get; set; }

        [JsonPropertyName("knockEnemyIntoTeamAndKill")]
        public int? KnockEnemyIntoTeamAndKill { get; set; }

        [JsonPropertyName("kTurretsDestroyedBeforePlatesFall")]
        public int? KTurretsDestroyedBeforePlatesFall { get; set; }

        [JsonPropertyName("landSkillShotsEarlyGame")]
        public int? LandSkillShotsEarlyGame { get; set; }

        [JsonPropertyName("laneMinionsFirst10Minutes")]
        public int? LaneMinionsFirst10Minutes { get; set; }

        [JsonPropertyName("lostAnInhibitor")]
        public int? LostAnInhibitor { get; set; }

        [JsonPropertyName("maxKillDeficit")]
        public int? MaxKillDeficit { get; set; }

        [JsonPropertyName("mejaisFullStackInTime")]
        public int? MejaisFullStackInTime { get; set; }

        [JsonPropertyName("moreEnemyJungleThanOpponent")]
        public float? MoreEnemyJungleThanOpponent { get; set; }

        /// <summary>
        /// This is an offshoot of the OneStone challenge. The code checks if a spell with the same instance ID does the final point of damage to at least 2 Champions.
        /// </summary>
        [JsonPropertyName("multiKillOneSpell")]
        public int? MultiKillOneSpell { get; set; }

        [JsonPropertyName("multikills")]
        public int? Multikills { get; set; }

        [JsonPropertyName("multikillsAfterAggressiveFlash")]
        public int? MultikillsAfterAggressiveFlash { get; set; }

        [JsonPropertyName("multiTurretRiftHeraldCount")]
        public int? MultiTurretRiftHeraldCount { get; set; }

        [JsonPropertyName("outerTurretExecutesBefore10Minutes")]
        public int? OuterTurretExecutesBefore10Minutes { get; set; }

        [JsonPropertyName("outnumberedKills")]
        public int? OutnumberedKills { get; set; }

        [JsonPropertyName("outnumberedNexusKill")]
        public int? OutnumberedNexusKill { get; set; }

        [JsonPropertyName("perfectDragonSoulsTaken")]
        public int? PerfectDragonSoulsTaken { get; set; }

        [JsonPropertyName("perfectGame")]
        public int? PerfectGame { get; set; }

        [JsonPropertyName("pickKillWithAlly")]
        public int? PickKillWithAlly { get; set; }

        [JsonPropertyName("poroExplosions")]
        public int? PoroExplosions { get; set; }

        [JsonPropertyName("quickCleanse")]
        public int? QuickCleanse { get; set; }

        [JsonPropertyName("quickFirstTurret")]
        public int? QuickFirstTurret { get; set; }

        [JsonPropertyName("quickSoloKills")]
        public int? QuickSoloKills { get; set; }

        [JsonPropertyName("riftHeraldTakedowns")]
        public int? RiftHeraldTakedowns { get; set; }

        [JsonPropertyName("saveAllyFromDeath")]
        public int? SaveAllyFromDeath { get; set; }

        [JsonPropertyName("scuttleCrabKills")]
        public int? ScuttleCrabKills { get; set; }

        [JsonPropertyName("shortestTimeToAceFromFirstTakedown")]
        public float? ShortestTimeToAceFromFirstTakedown { get; set; }

        [JsonPropertyName("skillshotsDodged")]
        public int? SkillshotsDodged { get; set; }

        [JsonPropertyName("skillshotsHit")]
        public int? SkillshotsHit { get; set; }

        [JsonPropertyName("snowballsHit")]
        public int? SnowballsHit { get; set; }

        [JsonPropertyName("soloBaronKills")]
        public int? SoloBaronKills { get; set; }

        [JsonPropertyName("SWARM_DefeatAatrox")]
        public int? SwarmDefeatAatrox { get; set; }

        [JsonPropertyName("SWARM_DefeatBriar")]
        public int? SwarmDefeatBriar { get; set; }

        [JsonPropertyName("SWARM_DefeatMiniBosses")]
        public int? SwarmDefeatMiniBosses { get; set; }

        [JsonPropertyName("SWARM_EvolveWeapon")]
        public int? SwarmEvolveWeapon { get; set; }

        [JsonPropertyName("SWARM_Have3Passives")]
        public int? SwarmHave3Passives { get; set; }

        [JsonPropertyName("SWARM_KillEnemy")]
        public int? SwarmKillEnemy { get; set; }

        [JsonPropertyName("SWARM_PickupGold")]
        public float? SwarmPickupGold { get; set; }

        [JsonPropertyName("SWARM_ReachLevel50")]
        public int? SwarmReachLevel50 { get; set; }

        [JsonPropertyName("SWARM_Survive15Min")]
        public int? SwarmSurvive15Min { get; set; }

        [JsonPropertyName("SWARM_WinWith5EvolvedWeapons")]
        public int? SwarmWinWith5EvolvedWeapons { get; set; }

        [JsonPropertyName("soloKills")]
        public int? SoloKills { get; set; }

        [JsonPropertyName("stealthWardsPlaced")]
        public int? StealthWardsPlaced { get; set; }

        [JsonPropertyName("survivedSingleDigitHpCount")]
        public int? SurvivedSingleDigitHpCount { get; set; }

        [JsonPropertyName("survivedThreeImmobilizesInFight")]
        public int? SurvivedThreeImmobilizesInFight { get; set; }

        [JsonPropertyName("takedownOnFirstTurret")]
        public int? TakedownOnFirstTurret { get; set; }

        [JsonPropertyName("takedowns")]
        public int? Takedowns { get; set; }

        [JsonPropertyName("takedownsAfterGainingLevelAdvantage")]
        public int? TakedownsAfterGainingLevelAdvantage { get; set; }

        [JsonPropertyName("takedownsBeforeJungleMinionSpawn")]
        public int? TakedownsBeforeJungleMinionSpawn { get; set; }

        [JsonPropertyName("takedownsFirstXMinutes")]
        public int? TakedownsFirstXMinutes { get; set; }

        [JsonPropertyName("takedownsInAlcove")]
        public int? TakedownsInAlcove { get; set; }

        [JsonPropertyName("takedownsInEnemyFountain")]
        public int? TakedownsInEnemyFountain { get; set; }

        [JsonPropertyName("teamBaronKills")]
        public int? TeamBaronKills { get; set; }

        [JsonPropertyName("teamDamagePercentage")]
        public float? TeamDamagePercentage { get; set; }

        [JsonPropertyName("teamElderDragonKills")]
        public int? TeamElderDragonKills { get; set; }

        [JsonPropertyName("teamRiftHeraldKills")]
        public int? TeamRiftHeraldKills { get; set; }

        [JsonPropertyName("tookLargeDamageSurvived")]
        public int? TookLargeDamageSurvived { get; set; }

        [JsonPropertyName("turretPlatesTaken")]
        public int? TurretPlatesTaken { get; set; }

        /// <summary>
        /// Any player who damages a tower that is destroyed within 30 seconds of a Rift Herald charge will receive credit.
        /// </summary>
        [JsonPropertyName("turretsTakenWithRiftHerald")]
        public int? TurretsTakenWithRiftHerald { get; set; }

        [JsonPropertyName("turretTakedowns")]
        public int? TurretTakedowns { get; set; }

        [JsonPropertyName("twentyMinionsIn3SecondsCount")]
        public int? TwentyMinionsIn3SecondsCount { get; set; }

        [JsonPropertyName("twoWardsOneSweeperCount")]
        public int? TwoWardsOneSweeperCount { get; set; }

        [JsonPropertyName("unseenRecalls")]
        public int? UnseenRecalls { get; set; }

        [JsonPropertyName("visionScorePerMinute")]
        public float? VisionScorePerMinute { get; set; }

        [JsonPropertyName("wardsGuarded")]
        public int? WardsGuarded { get; set; }

        [JsonPropertyName("wardTakedowns")]
        public int? WardTakedowns { get; set; }

        [JsonPropertyName("wardTakedownsBefore20M")]
        public int? WardTakedownsBefore20M { get; set; }
    }
}
