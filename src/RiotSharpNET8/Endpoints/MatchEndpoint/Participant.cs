using System.Text.Json.Serialization;
using RiotSharpNET8.Misc;
using RiotSharpNET8.Misc.Converters;

namespace RiotSharpNET8.Endpoints.MatchEndpoint
{
    /// <summary>
    /// Class representing a participant in a match (Match API).
    /// </summary>
    public class Participant
    {
        /// <summary>
        /// Number of assists.
        /// </summary>
        [JsonPropertyName("assists")]
        public long Assists { get; set; }

        /// <summary>
        /// Number of baron kills.
        /// </summary>
        [JsonPropertyName("baronKills")]
        public long BaronKills { get; set; }

        /// <summary>
        /// Level of bounty on the champion.
        /// </summary>
        [JsonPropertyName("bountyLevel")]
        public long BountyLevel { get; set; }

        /// <summary>
        /// Experience of the champion.
        /// </summary>
        [JsonPropertyName("champExperience")]
        public long ChampExperience { get; set; }

        /// <summary>
        /// Champion level achieved.
        /// </summary>
        [JsonPropertyName("champLevel")]
        public long ChampLevel { get; set; }

        /// <summary>
        /// Champion ID.
        /// </summary>
        [JsonPropertyName("championId")]
        public int ChampionId { get; set; }

        /// <summary>
        /// Champion ID.
        /// </summary>
        [JsonPropertyName("championName")]
        public string ChampionName { get; set; }

        /// <summary>
        /// Champion Transformation.
        /// </summary>
        [JsonPropertyName("championTransform")]
        public int ChampionTransform { get; set; }

        /// <summary>
        /// Consumables purchased.
        /// </summary>
        [JsonPropertyName("consumablesPurchased")]
        public long ConsumablesPurchased { get; set; }

        /// <summary>
        /// Damage dealt to buildings.
        /// </summary>
        [JsonPropertyName("damageDealtToBuildings")]
        public long DamageDealtToBuildings { get; set; }

        /// <summary>
        /// Damage dealt to objectives.
        /// </summary>
        [JsonPropertyName("damageDealtToObjectives")]
        public long DamageDealtToObjectives { get; set; }

        /// <summary>
        /// Damage dealt to turrets.
        /// </summary>
        [JsonPropertyName("damageDealtToTurrets")]
        public long DamageDealtToTurrets { get; set; }

        /// <summary>
        /// Damage self mitigated.
        /// </summary>
        [JsonPropertyName("damageSelfMitigated")]
        public long DamageSelfMitigated { get; set; }

        /// <summary>
        /// Number of deaths.
        /// </summary>
        [JsonPropertyName("deaths")]
        public long Deaths { get; set; }

        /// <summary>
        /// Number of detector wards placed.
        /// </summary>
        [JsonPropertyName("detectorWardsPlaced")]
        public long DetectorWardsPlaced { get; set; }

        /// <summary>
        /// Number of double kills.
        /// </summary>
        [JsonPropertyName("doubleKills")]
        public long DoubleKills { get; set; }

        /// <summary>
        /// Number of dragon kills.
        /// </summary>
        [JsonPropertyName("dragonKills")]
        public long DragonKills { get; set; }

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
        /// Flag indicating if participant got an assist on first blood turret.
        /// </summary>
        [JsonPropertyName("firstBloodTurretAssist")]
        public bool FirstBloodTurretAssist { get; set; }

        /// <summary>
        /// Flag indicating if participant got first blood turret.
        /// </summary>
        [JsonPropertyName("firstBloodTurretKill")]
        public bool FirstBloodTurretKill { get; set; }

        /// <summary>
        /// Flag indicating if game ended in early surrender.
        /// </summary>
        [JsonPropertyName("gameEndedInEarlySurrender")]
        public bool GameEndedInEarlySurrender { get; set; }

        /// <summary>
        /// Flag indicating if game ended in surrender.
        /// </summary>
        [JsonPropertyName("gameEndedInSurrender")]
        public bool GameEndedInSurrender { get; set; }

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
        /// Individual position of the player. Support marked as "UTILITY", ADC as "BOTTOM".
        /// </summary>
        [JsonPropertyName("individualPosition")]
        public string IndividualPosition { get; set; }

        /// <summary>
        /// Numer of inhibitor kills.
        /// </summary>
        [JsonPropertyName("inhibitorKills")]
        public long InhibitorKills { get; set; }

        /// <summary>
        /// Numer of inhibitor kills.
        /// </summary>
        [JsonPropertyName("inhibitorsLost")]
        public long InhibitorsLost { get; set; }

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
        /// Items purchased
        /// </summary>
        [JsonPropertyName("itemsPurchased")]
        public long ItemsPurchased { get; set; }

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
        /// Number of kills.
        /// </summary>
        [JsonPropertyName("lane")]
        [JsonConverter(typeof(LaneConverter))]
        public Lane Lane { get; set; }

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
        /// Largest multi kill.
        /// </summary>
        [JsonPropertyName("longestTimeSpentLiving")]
        [JsonConverter(typeof(TimeSpanConverterFromSeconds))]
        public TimeSpan LongestTimeSpentLiving { get; set; }

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
        /// Neutral minions killed.
        /// </summary>
        [JsonPropertyName("neutralMinionsKilled")]
        public long NeutralMinionsKilled { get; set; }

        /// <summary>
        /// Numer of nexus kills.
        /// </summary>
        [JsonPropertyName("nexusKills")]
        public int NexusKills { get; set; }

        /// <summary>
        /// Numer of nexus kills.
        /// </summary>
        [JsonPropertyName("nexusLost")]
        public int NexusLost { get; set; }

        /// <summary>
        /// Numer of nexus kills.
        /// </summary>
        [JsonPropertyName("objectivesStolen")]
        public long ObjectivesStolen { get; set; }

        /// <summary>
        /// Numer of nexus kills.
        /// </summary>
        [JsonPropertyName("objectivesStolenAssists")]
        public long ObjectivesStolenAssists { get; set; }

        /// <summary>
        /// Participant ID.
        /// </summary>
        [JsonPropertyName("participantId")]
        public int ParticipantId { get; set; }

        /// <summary>
        /// Number of penta kills.
        /// </summary>
        [JsonPropertyName("pentaKills")]
        public long PentaKills { get; set; }

        [JsonPropertyName("perks")]
        public ParticipantPerks Perks { get; set; }

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
        /// Id of the participants profil icon.
        /// </summary>
        [JsonPropertyName("profilIcon")]
        public long ProfilIcon { get; set; }

        /// <summary>
        /// Puuid.
        /// </summary>
        [JsonPropertyName("puuid")]
        public string Puuid { get; set; }

        /// <summary>
        /// Number of quadra kills.
        /// </summary>
        [JsonPropertyName("quadraKills")]
        public long QuadraKills { get; set; }

        /// <summary>
        /// Riot id name.
        /// </summary>
        [JsonPropertyName("riotIdName")]
        public string RiotIdName { get; set; }

        /// <summary>
        /// Riot id tagline.
        /// </summary>
        [JsonPropertyName("riotIdTagline")]
        public string RiotIdTagline { get; set; }

        /// <summary>
        /// Role.
        /// </summary>
        [JsonPropertyName("role")]
        [JsonConverter(typeof(RoleConverter))]
        public Role Role { get; set; }

        /// <summary>
        /// Number of sight wards purchased.
        /// </summary>
        [JsonPropertyName("sightWardsBoughtInGame")]
        public long SightWardsBoughtInGame { get; set; }

        /// <summary>
        /// Spell casts of the first spell.
        /// </summary>
        [JsonPropertyName("spell1Casts")]
        public long Spell1Casts { get; set; }

        /// <summary>
        /// Spell casts of the second spell.
        /// </summary>
        [JsonPropertyName("spell2Casts")]
        public long Spell2Casts { get; set; }

        /// <summary>
        /// Spell casts of the third spell.
        /// </summary>
        [JsonPropertyName("spell3Casts")]
        public long Spell3Casts { get; set; }

        /// <summary>
        /// Spell casts of the forth spell.
        /// </summary>
        [JsonPropertyName("spell4Casts")]
        public long Spell4Casts { get; set; }

        /// <summary>
        /// First summoner spell ID.
        /// </summary>
        [JsonPropertyName("summoner1Id")]
        public int Summoner1Id { get; set; }

        /// <summary>
        /// Number of summoner 1 casts.
        /// </summary>
        [JsonPropertyName("summoner1Casts")]
        public long Summoner1Casts { get; set; }

        /// <summary>
        /// Second summoner spell ID.
        /// </summary>
        [JsonPropertyName("summoner2Id")]
        public int Summoner2Id { get; set; }

        /// <summary>
        /// Number of summoner 2 casts.
        /// </summary>
        [JsonPropertyName("summoner2Casts")]
        public long Summoner2Casts { get; set; }

        /// <summary>
        /// Encrypted summoner ID.
        /// </summary>
        [JsonPropertyName("summonerId")]
        public string SummonerId { get; set; }

        /// <summary>
        /// Level of the summoner.
        /// </summary>
        [JsonPropertyName("summonerLevel")]
        public long SummonerLevel { get; set; }

        /// <summary>
        /// Name of the summoner.
        /// </summary>
        [JsonPropertyName("summonerName")]
        public string SummonerName { get; set; }

        /// <summary>
        /// Flag whether team surrendered early.
        /// </summary>
        [JsonPropertyName("teamEarlySurrendered")]
        public bool TeamEarlySurrendered { get; set; }

        /// <summary>
        /// Team ID.
        /// </summary>
        [JsonPropertyName("teamId")]
        public int TeamId { get; set; }

        /// <summary>
        /// Team position.
        /// </summary>
        [JsonPropertyName("teamPosition")]
        public string TeamPosition { get; set; }

        /// <summary>
        /// Time crowd controling others.
        /// </summary>
        [JsonPropertyName("timeCCingOthers")]
        public long TimeCCingOthers { get; set; }

        /// <summary>
        /// Time crowd controling others.
        /// </summary>
        [JsonPropertyName("timePlayed")]
        [JsonConverter(typeof(TimeSpanConverterFromSeconds))]
        public TimeSpan timePlayed { get; set; }

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
        /// Total damage shielded on teammates.
        /// </summary>
        [JsonPropertyName("totalDamageShieldedOnTeammates")]
        public long TotalDamageShieldedOnTeammates { get; set; }

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
        /// Total heals on teammates.
        /// </summary>
        [JsonPropertyName("totalHealsOnTeammates")]
        public long TotalHealsOnTeammates { get; set; }

        /// <summary>
        /// Minions kiled.
        /// </summary>
        [JsonPropertyName("totalMinionsKilled")]
        public long TotalMinionsKilled { get; set; }

        /// <summary>
        /// Total time crowd control dealt.
        /// </summary>
        [JsonPropertyName("totalTimeCCDealt")]
        public long TotalTimeCCDealt { get; set; }

        /// <summary>
        /// Total time crowd control dealt.
        /// </summary>
        [JsonPropertyName("totalTimeSpentDead")]
        [JsonConverter(typeof(TimeSpanConverterFromSeconds))]
        public TimeSpan TotalTimeSpentDead { get; set; }

        /// <summary>
        /// Total units healed.
        /// </summary>
        [JsonPropertyName("totalUnitsHealed")]
        public long TotalUnitsHealed { get; set; }

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
        /// Number of tower kills.
        /// </summary>
        [JsonPropertyName("turretKills")]
        public long TurretKills { get; set; }

        /// <summary>
        /// Number of turrets lost.
        /// </summary>
        [JsonPropertyName("turretsLost")]
        public long TurretsLost { get; set; }

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
    }
}
