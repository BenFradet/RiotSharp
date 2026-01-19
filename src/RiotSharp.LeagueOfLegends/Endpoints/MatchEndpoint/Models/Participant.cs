using RiotSharp.Core.Misc.Converters;
using RiotSharp.LeagueOfLegends.Misc;
using System.Text.Json.Serialization;

namespace RiotSharp.LeagueOfLegends.Endpoints.MatchEndpoint.Models
{
    /// <summary>
    /// Class representing a participant in a match (Match API).
    /// </summary>
    public class Participant
    {
        /// <summary>
        /// Yellow crossed swords ping count.
        /// </summary>
        [JsonPropertyName("allInPings")]
        public required int AllInPings { get; set; }

        /// <summary>
        /// Green flag ping count.
        /// </summary>
        [JsonPropertyName("assistMePings")]
        public required int AssistMePings { get; set; }

        /// <summary>
        /// Number of assists.
        /// </summary>
        [JsonPropertyName("assists")]
        public required int Assists { get; set; }

        /// <summary>
        /// Number of baron kills.
        /// </summary>
        [JsonPropertyName("baronKills")]
        public required int BaronKills { get; set; }

        /// <summary>
        /// Level of bounty on the champion.
        /// </summary>
        [JsonPropertyName("bountyLevel")]
        public required int BountyLevel { get; set; }

        /// <summary>
        /// Experience of the champion.
        /// </summary>
        [JsonPropertyName("champExperience")]
        public required int ChampExperience { get; set; }

        /// <summary>
        /// Champion level achieved.
        /// </summary>
        [JsonPropertyName("champLevel")]
        public required int ChampLevel { get; set; }

        /// <summary>
        /// Champion ID. Prior to patch 11.4 (Feb 18, 2021), this field returned invalid championIds.
        /// </summary>
        [JsonPropertyName("championId")]
        public required int ChampionId { get; set; }

        /// <summary>
        /// Champion name.
        /// </summary>
        [JsonPropertyName("championName")]
        public required string ChampionName { get; set; }

        /// <summary>
        /// Blue generic ping (ALT+click).
        /// </summary>
        [JsonPropertyName("commandPings")]
        public required int CommandPings { get; set; }

        /// <summary>
        /// Champion transformation (0 = None, 1 = Slayer, 2 = Assassin). Currently only for Kayn.
        /// </summary>
        [JsonPropertyName("championTransform")]
        public required int ChampionTransform { get; set; }

        /// <summary>
        /// Consumables purchased.
        /// </summary>
        [JsonPropertyName("consumablesPurchased")]
        public required int ConsumablesPurchased { get; set; }

        /// <summary>
        /// Challenges data.
        /// </summary>
        [JsonPropertyName("challenges")]
        public required Challenges Challenges { get; set; }

        /// <summary>
        /// Damage dealt to buildings.
        /// </summary>
        [JsonPropertyName("damageDealtToBuildings")]
        public required int DamageDealtToBuildings { get; set; }

        /// <summary>
        /// Damage dealt to objectives.
        /// </summary>
        [JsonPropertyName("damageDealtToObjectives")]
        public required int DamageDealtToObjectives { get; set; }

        /// <summary>
        /// Damage dealt to turrets.
        /// </summary>
        [JsonPropertyName("damageDealtToTurrets")]
        public required int DamageDealtToTurrets { get; set; }

        /// <summary>
        /// Damage self mitigated.
        /// </summary>
        [JsonPropertyName("damageSelfMitigated")]
        public required int DamageSelfMitigated { get; set; }

        /// <summary>
        /// Danger Pings
        /// </summary>
        [JsonPropertyName("dangerPings")]
        public required int DangerPings { get; set; }

        /// <summary>
        /// Number of deaths.
        /// </summary>
        [JsonPropertyName("deaths")]
        public int Deaths { get; set; }

        /// <summary>
        /// Number of detector wards placed.
        /// </summary>
        [JsonPropertyName("detectorWardsPlaced")]
        public int DetectorWardsPlaced { get; set; }

        /// <summary>
        /// Number of double kills.
        /// </summary>
        [JsonPropertyName("doubleKills")]
        public required int DoubleKills { get; set; }

        /// <summary>
        /// Number of dragon kills.
        /// </summary>
        [JsonPropertyName("dragonKills")]
        public required int DragonKills { get; set; }

        /// <summary>
        /// Whether the participant is eligible for progression.
        /// </summary>
        [JsonPropertyName("eligibleForProgression")]
        public required bool EligibleForProgression { get; set; }

        /// <summary>
        /// Yellow questionmark ping count.
        /// </summary>
        [JsonPropertyName("enemyMissingPings")]
        public required int EnemyMissingPings { get; set; }

        /// <summary>
        /// Red eyeball ping count.
        /// </summary>
        [JsonPropertyName("enemyVisionPings")]
        public required int EnemyVisionPings { get; set; }

        /// <summary>
        /// Flag indicating if participant got an assist on first blood.
        /// </summary>
        [JsonPropertyName("firstBloodAssist")]
        public required bool FirstBloodAssist { get; set; }

        /// <summary>
        /// Flag indicating if participant got first blood.
        /// </summary>
        [JsonPropertyName("firstBloodKill")]
        public required bool FirstBloodKill { get; set; }

        /// <summary>
        /// Flag indicating if participant got an assist on first tower.
        /// </summary>
        [JsonPropertyName("firstTowerAssist")]
        public required bool FirstTowerAssist { get; set; }

        /// <summary>
        /// Flag indicating if participant got first tower.
        /// </summary>
        [JsonPropertyName("firstTowerKill")]
        public required bool FirstTowerKill { get; set; }

        /// <summary>
        /// Flag indicating if game ended in early surrender.
        /// </summary>
        [JsonPropertyName("gameEndedInEarlySurrender")]
        public required bool GameEndedInEarlySurrender { get; set; }

        /// <summary>
        /// Flag indicating if game ended in surrender.
        /// </summary>
        [JsonPropertyName("gameEndedInSurrender")]
        public required bool GameEndedInSurrender { get; set; }


        /// <summary>
        /// Yellow circle with horizontal line ping count.
        /// </summary>
        [JsonPropertyName("getBackPings")]
        public required int GetBackPings { get; set; }

        /// <summary>
        /// Gold earned.
        /// </summary>
        [JsonPropertyName("goldEarned")]
        public required int GoldEarned { get; set; }

        /// <summary>
        /// Gold spent.
        /// </summary>
        [JsonPropertyName("goldSpent")]
        public required int GoldSpent { get; set; }

        /// <summary>
        /// Hold ping count.
        /// </summary>
        [JsonPropertyName("holdPings")]
        public required int HoldPings { get; set; }

        /// <summary>
        /// Individual position of the player. Support marked as "UTILITY", ADC as "BOTTOM".
        /// </summary>
        /// <remarks> Should be an enum. But documentation is lacking so cannot be done.</remarks>
        [JsonPropertyName("individualPosition")]
        public required string IndividualPosition { get; set; }

        /// <summary>
        /// Number of inhibitor kills.
        /// </summary>
        [JsonPropertyName("inhibitorKills")]
        public required int InhibitorKills { get; set; }

        /// <summary>
        /// Number of inhibitor takedowns.
        /// </summary>
        [JsonPropertyName("inhibitorTakedowns")]
        public required int InhibitorTakedowns { get; set; }

        /// <summary>
        /// Number of inhibitors lost.
        /// </summary>
        [JsonPropertyName("inhibitorsLost")]
        public required int InhibitorsLost { get; set; }

        /// <summary>
        /// First item ID.
        /// </summary>
        [JsonPropertyName("item0")]
        public required int Item0 { get; set; }

        /// <summary>
        /// Second item ID.
        /// </summary>
        [JsonPropertyName("item1")]
        public required int Item1 { get; set; }

        /// <summary>
        /// Third item ID.
        /// </summary>
        [JsonPropertyName("item2")]
        public required int Item2 { get; set; }

        /// <summary>
        /// Fourth item ID.
        /// </summary>
        [JsonPropertyName("item3")]
        public required int Item3 { get; set; }

        /// <summary>
        /// Fifth item ID.
        /// </summary>
        [JsonPropertyName("item4")]
        public required int Item4 { get; set; }

        /// <summary>
        /// Sixth item ID.
        /// </summary>
        [JsonPropertyName("item5")]
        public required int Item5 { get; set; }

        /// <summary>
        /// Seventh item ID (trinket).
        /// </summary>
        [JsonPropertyName("item6")]
        public required int Item6 { get; set; }

        /// <summary>
        /// Items purchased.
        /// </summary>
        [JsonPropertyName("itemsPurchased")]
        public required int ItemsPurchased { get; set; }

        /// <summary>
        /// Number of killing sprees.
        /// </summary>
        [JsonPropertyName("killingSprees")]
        public required int KillingSprees { get; set; }

        /// <summary>
        /// Number of kills.
        /// </summary>
        [JsonPropertyName("kills")]
        public required int Kills { get; set; }

        /// <summary>
        /// Lane assignment.
        /// </summary>
        [JsonPropertyName("lane")]
        public required Lane Lane { get; set; }

        /// <summary>
        /// Largest critical strike.
        /// </summary>
        [JsonPropertyName("largestCriticalStrike")]
        public required int LargestCriticalStrike { get; set; }

        /// <summary>
        /// Largest killing spree.
        /// </summary>
        [JsonPropertyName("largestKillingSpree")]
        public required int LargestKillingSpree { get; set; }

        /// <summary>
        /// Largest multi kill.
        /// </summary>
        [JsonPropertyName("largestMultiKill")]
        public required int LargestMultiKill { get; set; }

        /// <summary>
        /// Longest time spent living (in seconds).
        /// </summary>
        [JsonPropertyName("longestTimeSpentLiving")]
        public required int LongestTimeSpentLiving { get; set; }

        /// <summary>
        /// Magic damage dealt.
        /// </summary>
        [JsonPropertyName("magicDamageDealt")]
        public required int MagicDamageDealt { get; set; }

        /// <summary>
        /// Magic damage dealt to champions.
        /// </summary>
        [JsonPropertyName("magicDamageDealtToChampions")]
        public required int MagicDamageDealtToChampions { get; set; }

        /// <summary>
        /// Magic damage taken.
        /// </summary>
        [JsonPropertyName("magicDamageTaken")]
        public required int MagicDamageTaken { get; set; }

        /// <summary>
        /// Missions data.
        /// </summary>
        [JsonPropertyName("missions")]
        public required Missions Missions { get; set; }

        /// <summary>
        /// Green ward ping count.
        /// </summary>
        [JsonPropertyName("needVisionPings")]
        public required int NeedVisionPings { get; set; }

        /// <summary>
        /// Neutral minions killed (jungle monsters).
        /// </summary>
        [JsonPropertyName("neutralMinionsKilled")]
        public required int NeutralMinionsKilled { get; set; }

        /// <summary>
        /// Number of nexus kills.
        /// </summary>
        [JsonPropertyName("nexusKills")]
        public required int NexusKills { get; set; }

        /// <summary>
        /// Number of nexus takedowns.
        /// </summary>
        [JsonPropertyName("nexusTakedowns")]
        public int NexusTakedowns { get; set; }

        /// <summary>
        /// Number of nexuses lost.
        /// </summary>
        [JsonPropertyName("nexusLost")]
        public required int NexusLost { get; set; }

        /// <summary>
        /// Number of objectives stolen.
        /// </summary>
        [JsonPropertyName("objectivesStolen")]
        public required int ObjectivesStolen { get; set; }

        /// <summary>
        /// Number of objective stolen assists.
        /// </summary>
        [JsonPropertyName("objectivesStolenAssists")]
        public required int ObjectivesStolenAssists { get; set; }

        /// <summary>
        /// Blue arrow pointing at ground ping count.
        /// </summary>
        [JsonPropertyName("onMyWayPings")]
        public required int OnMyWayPings { get; set; }

        /// <summary>
        /// Participant ID.
        /// </summary>
        [JsonPropertyName("participantId")]
        public required int ParticipantId { get; set; }

        /// <summary>
        /// Player score 0.
        /// </summary>
        [JsonPropertyName("playerScore0")]
        public int? PlayerScore0 { get; set; }

        /// <summary>
        /// Player score 1.
        /// </summary>
        [JsonPropertyName("playerScore1")]
        public int? PlayerScore1 { get; set; }

        /// <summary>
        /// Player score 2.
        /// </summary>
        [JsonPropertyName("playerScore2")]
        public int? PlayerScore2 { get; set; }

        /// <summary>
        /// Player score 3.
        /// </summary>
        [JsonPropertyName("playerScore3")]
        public int? PlayerScore3 { get; set; }

        /// <summary>
        /// Player score 4.
        /// </summary>
        [JsonPropertyName("playerScore4")]
        public int? PlayerScore4 { get; set; }

        /// <summary>
        /// Player score 5.
        /// </summary>
        [JsonPropertyName("playerScore5")]
        public int? PlayerScore5 { get; set; }

        /// <summary>
        /// Player score 6.
        /// </summary>
        [JsonPropertyName("playerScore6")]
        public int? PlayerScore6 { get; set; }

        /// <summary>
        /// Player score 7.
        /// </summary>
        [JsonPropertyName("playerScore7")]
        public int? PlayerScore7 { get; set; }

        /// <summary>
        /// Player score 8.
        /// </summary>
        [JsonPropertyName("playerScore8")]
        public int? PlayerScore8 { get; set; }

        /// <summary>
        /// Player score 9.
        /// </summary>
        [JsonPropertyName("playerScore9")]
        public int? PlayerScore9 { get; set; }

        /// <summary>
        /// Player score 10.
        /// </summary>
        [JsonPropertyName("playerScore10")]
        public int? PlayerScore10 { get; set; }

        /// <summary>
        /// Player score 11.
        /// </summary>
        [JsonPropertyName("playerScore11")]
        public int? PlayerScore11 { get; set; }

        /// <summary>
        /// Number of penta kills.
        /// </summary>
        [JsonPropertyName("pentaKills")]
        public required int PentaKills { get; set; }

        /// <summary>
        /// Perks/Runes data.
        /// </summary>
        [JsonPropertyName("perks")]
        public required Perks Perks { get; set; }

        /// <summary>
        /// Physical damage dealt.
        /// </summary>
        [JsonPropertyName("physicalDamageDealt")]
        public required int PhysicalDamageDealt { get; set; }

        /// <summary>
        /// Physical damage dealt to champions.
        /// </summary>
        [JsonPropertyName("physicalDamageDealtToChampions")]
        public required int PhysicalDamageDealtToChampions { get; set; }

        /// <summary>
        /// Physical damage taken.
        /// </summary>
        [JsonPropertyName("physicalDamageTaken")]
        public required int PhysicalDamageTaken { get; set; }

        /// <summary>
        /// Placement in Arena mode.
        /// </summary>
        [JsonPropertyName("placement")]
        public required int Placement { get; set; }

        /// <summary>
        /// Player augment 1 (Arena mode).
        /// </summary>
        [JsonPropertyName("playerAugment1")]
        public required int PlayerAugment1 { get; set; }

        /// <summary>
        /// Player augment 2 (Arena mode).
        /// </summary>
        [JsonPropertyName("playerAugment2")]
        public required int PlayerAugment2 { get; set; }

        /// <summary>
        /// Player augment 3 (Arena mode).
        /// </summary>
        [JsonPropertyName("playerAugment3")]
        public required int PlayerAugment3 { get; set; }

        /// <summary>
        /// Player augment 4 (Arena mode).
        /// </summary>
        [JsonPropertyName("playerAugment4")]
        public required int PlayerAugment4 { get; set; }

        /// <summary>
        /// Player subteam ID (Arena mode).
        /// </summary>
        [JsonPropertyName("playerSubteamId")]
        public required int PlayerSubteamId { get; set; }

        /// <summary>
        /// Green minion ping count.
        /// </summary>
        [JsonPropertyName("pushPings")]
        public required int PushPings { get; set; }

        /// <summary>
        /// Profile icon ID.
        /// </summary>
        [JsonPropertyName("profileIcon")]
        public required int ProfileIcon { get; set; }

        /// <summary>
        /// Player UUID.
        /// </summary>
        [JsonPropertyName("puuid")]
        public required string Puuid { get; set; }

        /// <summary>
        /// Number of quadra kills.
        /// </summary>
        [JsonPropertyName("quadraKills")]
        public required int QuadraKills { get; set; }

        /// <summary>
        /// Riot ID game name.
        /// </summary>
        [JsonPropertyName("riotIdGameName")]
        public required string RiotIdGameName { get; set; }

        /// <summary>
        /// Riot ID tagline.
        /// </summary>
        [JsonPropertyName("riotIdTagline")]
        public required string RiotIdTagline { get; set; }

        /// <summary>
        /// Role.
        /// </summary>
        [JsonPropertyName("role")]
        public required Role Role { get; set; }

        /// <summary>
        /// Number of sight wards purchased.
        /// </summary>
        [JsonPropertyName("sightWardsBoughtInGame")]
        public required int SightWardsBoughtInGame { get; set; }

        /// <summary>
        /// Spell 1 casts (Q).
        /// </summary>
        [JsonPropertyName("spell1Casts")]
        public int Spell1Casts { get; set; }

        /// <summary>
        /// Spell 2 casts (W).
        /// </summary>
        [JsonPropertyName("spell2Casts")]
        public required int Spell2Casts { get; set; }

        /// <summary>
        /// Spell 3 casts (E).
        /// </summary>
        [JsonPropertyName("spell3Casts")]
        public required int Spell3Casts { get; set; }

        /// <summary>
        /// Spell 4 casts (R).
        /// </summary>
        [JsonPropertyName("spell4Casts")]
        public required int Spell4Casts { get; set; }

        /// <summary>
        /// Subteam placement (Arena mode).
        /// </summary>
        [JsonPropertyName("subteamPlacement")]
        public required int SubteamPlacement { get; set; }

        /// <summary>
        /// Summoner spell 1 casts.
        /// </summary>
        [JsonPropertyName("summoner1Casts")]
        public required int Summoner1Casts { get; set; }

        /// <summary>
        /// Summoner spell 1 ID.
        /// </summary>
        [JsonPropertyName("summoner1Id")]
        public required int Summoner1Id { get; set; }

        /// <summary>
        /// Summoner spell 2 casts.
        /// </summary>
        [JsonPropertyName("summoner2Casts")]
        public required int Summoner2Casts { get; set; }

        /// <summary>
        /// Summoner spell 2 ID.
        /// </summary>
        [JsonPropertyName("summoner2Id")]
        public required int Summoner2Id { get; set; }

        /// <summary>
        /// Encrypted summoner ID.
        /// </summary>
        [JsonPropertyName("summonerId")]
        public required string SummonerId { get; set; }

        /// <summary>
        /// Summoner level.
        /// </summary>
        [JsonPropertyName("summonerLevel")]
        public required int SummonerLevel { get; set; }

        /// <summary>
        /// Summoner name.
        /// </summary>
        [JsonPropertyName("summonerName")]
        public required string SummonerName { get; set; }

        /// <summary>
        /// Flag whether team surrendered early.
        /// </summary>
        [JsonPropertyName("teamEarlySurrendered")]
        public required bool TeamEarlySurrendered { get; set; }

        /// <summary>
        /// Team ID (100 = Blue, 200 = Red).
        /// </summary>
        [JsonPropertyName("teamId")]
        public required int TeamId { get; set; }

        /// <summary>
        /// Team position (TOP, JUNGLE, MIDDLE, BOTTOM, UTILITY).
        /// </summary>
        /// <remarks> Should be an enum. But documentation is lacking so cannot be done. Also can be empty string in ARAM!</remarks>
        [JsonPropertyName("teamPosition")]
        public required string TeamPosition { get; set; }

        /// <summary>
        /// Time crowd controlling others (in seconds).
        /// </summary>
        [JsonPropertyName("timeCCingOthers")]
        public required int TimeCCingOthers { get; set; }

        /// <summary>
        /// Time played (in seconds).
        /// </summary>
        [JsonPropertyName("timePlayed")]
        public required int TimePlayed { get; set; }

        /// <summary>
        /// Total ally jungle minions killed.
        /// </summary>
        [JsonPropertyName("totalAllyJungleMinionsKilled")]
        public required int TotalAllyJungleMinionsKilled { get; set; }

        /// <summary>
        /// Total damage dealt.
        /// </summary>
        [JsonPropertyName("totalDamageDealt")]
        public required int TotalDamageDealt { get; set; }

        /// <summary>
        /// Total damage dealt to champions.
        /// </summary>
        [JsonPropertyName("totalDamageDealtToChampions")]
        public required int TotalDamageDealtToChampions { get; set; }

        /// <summary>
        /// Total damage shielded on teammates.
        /// </summary>
        [JsonPropertyName("totalDamageShieldedOnTeammates")]
        public required int TotalDamageShieldedOnTeammates { get; set; }

        /// <summary>
        /// Total damage taken.
        /// </summary>
        [JsonPropertyName("totalDamageTaken")]
        public required int TotalDamageTaken { get; set; }

        /// <summary>
        /// Total enemy jungle minions killed.
        /// </summary>
        [JsonPropertyName("totalEnemyJungleMinionsKilled")]
        public required int TotalEnemyJungleMinionsKilled { get; set; }

        /// <summary>
        /// Total heal amount.
        /// </summary>
        [JsonPropertyName("totalHeal")]
        public required int TotalHeal { get; set; }

        /// <summary>
        /// Total heals on teammates.
        /// </summary>
        [JsonPropertyName("totalHealsOnTeammates")]
        public required int TotalHealsOnTeammates { get; set; }

        /// <summary>
        /// Total minions killed.
        /// </summary>
        [JsonPropertyName("totalMinionsKilled")]
        public required int TotalMinionsKilled { get; set; }

        /// <summary>
        /// Total time crowd control dealt (in seconds).
        /// </summary>
        [JsonPropertyName("totalTimeCCDealt")]
        public required int TotalTimeCCDealt { get; set; }

        /// <summary>
        /// Total time spent dead (in seconds).
        /// </summary>
        [JsonPropertyName("totalTimeSpentDead")]
        [JsonConverter(typeof(TimeSpanConverterFromSeconds))]
        public required TimeSpan TotalTimeSpentDead { get; set; }

        /// <summary>
        /// Total units healed.
        /// </summary>
        [JsonPropertyName("totalUnitsHealed")]
        public required int TotalUnitsHealed { get; set; }

        /// <summary>
        /// Number of triple kills.
        /// </summary>
        [JsonPropertyName("tripleKills")]
        public int TripleKills { get; set; }

        /// <summary>
        /// True damage dealt.
        /// </summary>
        [JsonPropertyName("trueDamageDealt")]
        public required int TrueDamageDealt { get; set; }

        /// <summary>
        /// True damage dealt to champions.
        /// </summary>
        [JsonPropertyName("trueDamageDealtToChampions")]
        public required int TrueDamageDealtToChampions { get; set; }

        /// <summary>
        /// True damage taken.
        /// </summary>
        [JsonPropertyName("trueDamageTaken")]
        public required int TrueDamageTaken { get; set; }

        /// <summary>
        /// Number of turret kills.
        /// </summary>
        [JsonPropertyName("turretKills")]
        public required int TurretKills { get; set; }

        /// <summary>
        /// Number of turret takedowns.
        /// </summary>
        [JsonPropertyName("turretTakedowns")]
        public required int TurretTakedowns { get; set; }

        /// <summary>
        /// Number of turrets lost.
        /// </summary>
        [JsonPropertyName("turretsLost")]
        public required int TurretsLost { get; set; }

        /// <summary>
        /// Number of unreal kills.
        /// </summary>
        [JsonPropertyName("unrealKills")]
        public required int UnrealKills { get; set; }

        /// <summary>
        /// Vision score.
        /// </summary>
        [JsonPropertyName("visionScore")]
        public required int VisionScore { get; set; }

        /// <summary>
        /// Vision cleared ping count.
        /// </summary>
        [JsonPropertyName("visionClearedPings")]
        public required int VisionClearedPings { get; set; }

        /// <summary>
        /// Number of vision wards (control wards) purchased.
        /// </summary>
        [JsonPropertyName("visionWardsBoughtInGame")]
        public required int VisionWardsBoughtInGame { get; set; }

        /// <summary>
        /// Number of wards killed.
        /// </summary>
        [JsonPropertyName("wardsKilled")]
        public required int WardsKilled { get; set; }

        /// <summary>
        /// Number of wards placed.
        /// </summary>
        [JsonPropertyName("wardsPlaced")]
        public required int WardsPlaced { get; set; }

        /// <summary>
        /// Flag indicating whether the participant won.
        /// </summary>
        [JsonPropertyName("win")]
        public required bool Win { get; set; }
    }
}
