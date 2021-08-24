using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using RiotSharp.Endpoints.LeagueEndpoint.Enums;
using RiotSharp.Misc;
using RiotSharp.Misc.Converters;

namespace RiotSharp.Endpoints.MatchEndpoint
{
    /// <summary>
    /// Class representing a participant in a match (Match API).
    /// </summary>
    public class Participant
    {
        internal Participant() { }

        /// <summary>
        /// Number of assists.
        /// </summary>
        [JsonProperty("assists")]
        public long Assists { get; set; }

        /// <summary>
        /// Number of baron kills.
        /// </summary>
        [JsonProperty("baronKills")]
        public long BaronKills { get; set; }

        /// <summary>
        /// Level of bounty on the champion.
        /// </summary>
        [JsonProperty("bountyLevel")]
        public long BountyLevel { get; set; }

        /// <summary>
        /// Experience of the champion.
        /// </summary>
        [JsonProperty("champExperience")]
        public long ChampExperience { get; set; }

        /// <summary>
        /// Champion level achieved.
        /// </summary>
        [JsonProperty("champLevel")]
        public long ChampLevel { get; set; }

        /// <summary>
        /// Champion ID.
        /// </summary>
        [JsonProperty("championId")]
        public int ChampionId { get; set; }

        /// <summary>
        /// Champion ID.
        /// </summary>
        [JsonProperty("championName")]
        public string ChampionName { get; set; }

        /// <summary>
        /// Champion Transformation.
        /// </summary>
        [JsonProperty("championTransform")]
        public int ChampionTransform { get; set; }

        /// <summary>
        /// Consumables purchased.
        /// </summary>
        [JsonProperty("consumablesPurchased")]
        public long ConsumablesPurchased { get; set; }

        /// <summary>
        /// Damage dealt to buildings.
        /// </summary>
        [JsonProperty("damageDealtToBuildings")]
        public long DamageDealtToBuildings { get; set; }

        /// <summary>
        /// Damage dealt to objectives.
        /// </summary>
        [JsonProperty("damageDealtToObjectives")]
        public long DamageDealtToObjectives { get; set; }

        /// <summary>
        /// Damage dealt to turrets.
        /// </summary>
        [JsonProperty("damageDealtToTurrets")]
        public long DamageDealtToTurrets { get; set; }

        /// <summary>
        /// Damage self mitigated.
        /// </summary>
        [JsonProperty("damageSelfMitigated")]
        public long DamageSelfMitigated { get; set; }

        /// <summary>
        /// Number of deaths.
        /// </summary>
        [JsonProperty("deaths")]
        public long Deaths { get; set; }

        /// <summary>
        /// Number of detector wards placed.
        /// </summary>
        [JsonProperty("detectorWardsPlaced")]
        public long DetectorWardsPlaced { get; set; }

        /// <summary>
        /// Number of double kills.
        /// </summary>
        [JsonProperty("doubleKills")]
        public long DoubleKills { get; set; }

        /// <summary>
        /// Number of dragon kills.
        /// </summary>
        [JsonProperty("dragonKills")]
        public long DragonKills { get; set; }

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
        /// Flag indicating if participant got an assist on first blood turret.
        /// </summary>
        [JsonProperty("firstBloodTurretAssist")]
        public bool FirstBloodTurretAssist { get; set; }

        /// <summary>
        /// Flag indicating if participant got first blood turret.
        /// </summary>
        [JsonProperty("firstBloodTurretKill")]
        public bool FirstBloodTurretKill { get; set; }

        /// <summary>
        /// Flag indicating if game ended in early surrender.
        /// </summary>
        [JsonProperty("gameEndedInEarlySurrender")]
        public bool GameEndedInEarlySurrender { get; set; }

        /// <summary>
        /// Flag indicating if game ended in surrender.
        /// </summary>
        [JsonProperty("gameEndedInSurrender")]
        public bool GameEndedInSurrender { get; set; }

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
        /// Gold spent.
        /// </summary>
        [JsonProperty("individualPosition")]
        public string IndividualPosition { get; set; }

        /// <summary>
        /// Numer of inhibitor kills.
        /// </summary>
        [JsonProperty("inhibitorKills")]
        public long InhibitorKills { get; set; }

        /// <summary>
        /// Numer of inhibitor kills.
        /// </summary>
        [JsonProperty("inhibitorsLost")]
        public long InhibitorsLost { get; set; }

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
        /// Items purchased
        /// </summary>
        [JsonProperty("itemsPurchased")]
        public long ItemsPurchased { get; set; }

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
        /// Number of kills.
        /// </summary>
        [JsonProperty("lane")]
        [JsonConverter(typeof(LaneConverter))]
        public Lane Lane { get; set; }

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
        /// Largest multi kill.
        /// </summary>
        [JsonProperty("longestTimeSpentLiving")]
        [JsonConverter(typeof(TimeSpanConverterFromSeconds))]
        public TimeSpan LongestTimeSpentLiving { get; set; }

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
        /// Neutral minions killed.
        /// </summary>
        [JsonProperty("neutralMinionsKilled")]
        public long NeutralMinionsKilled { get; set; }

        /// <summary>
        /// Numer of nexus kills.
        /// </summary>
        [JsonProperty("nexusKills")]
        public int NexusKills { get; set; }

        /// <summary>
        /// Numer of nexus kills.
        /// </summary>
        [JsonProperty("nexusLost")]
        public int NexusLost { get; set; }

        /// <summary>
        /// Numer of nexus kills.
        /// </summary>
        [JsonProperty("objectivesStolen")]
        public long ObjectivesStolen { get; set; }

        /// <summary>
        /// Numer of nexus kills.
        /// </summary>
        [JsonProperty("objectivesStolenAssists")]
        public long ObjectivesStolenAssists { get; set; }

        /// <summary>
        /// Participant ID.
        /// </summary>
        [JsonProperty("participantId")]
        public int ParticipantId { get; set; }

        /// <summary>
        /// Number of penta kills.
        /// </summary>
        [JsonProperty("pentaKills")]
        public long PentaKills { get; set; }

        [JsonProperty("perks")]
        public ParticipantPerks Perks { get; set; }

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
        /// Id of the participants profil icon.
        /// </summary>
        [JsonProperty("profilIcon")]
        public long ProfilIcon { get; set; }

        /// <summary>
        /// Puuid.
        /// </summary>
        [JsonProperty("puuid")]
        public string Puuid { get; set; }

        /// <summary>
        /// Number of quadra kills.
        /// </summary>
        [JsonProperty("quadraKills")]
        public long QuadraKills { get; set; }

        /// <summary>
        /// Riot id name.
        /// </summary>
        [JsonProperty("riotIdName")]
        public string RiotIdName { get; set; }

        /// <summary>
        /// Riot id tagline.
        /// </summary>
        [JsonProperty("riotIdTagline")]
        public string RiotIdTagline { get; set; }

        /// <summary>
        /// Role.
        /// </summary>
        [JsonProperty("role")]
        [JsonConverter(typeof(RoleConverter))]
        public Role Role { get; set; }

        /// <summary>
        /// Number of sight wards purchased.
        /// </summary>
        [JsonProperty("sightWardsBoughtInGame")]
        public long SightWardsBoughtInGame { get; set; }

        /// <summary>
        /// Spell casts of the first spell.
        /// </summary>
        [JsonProperty("spell1Casts")]
        public long Spell1Casts { get; set; }

        /// <summary>
        /// Spell casts of the second spell.
        /// </summary>
        [JsonProperty("spell2Casts")]
        public long Spell2Casts { get; set; }

        /// <summary>
        /// Spell casts of the third spell.
        /// </summary>
        [JsonProperty("spell3Casts")]
        public long Spell3Casts { get; set; }

        /// <summary>
        /// Spell casts of the forth spell.
        /// </summary>
        [JsonProperty("spell4Casts")]
        public long Spell4Casts { get; set; }

        /// <summary>
        /// First summoner spell ID.
        /// </summary>
        [JsonProperty("summoner1Id")]
        public int Summoner1Id { get; set; }

        /// <summary>
        /// Number of summoner 1 casts.
        /// </summary>
        [JsonProperty("summoner1Casts")]
        public long Summoner1Casts { get; set; }

        /// <summary>
        /// Second summoner spell ID.
        /// </summary>
        [JsonProperty("summoner2Id")]
        public int Summoner2Id { get; set; }

        /// <summary>
        /// Number of summoner 2 casts.
        /// </summary>
        [JsonProperty("summoner2Casts")]
        public long Summoner2Casts { get; set; }

        /// <summary>
        /// Encrypted summoner ID.
        /// </summary>
        [JsonProperty("summonerId")]
        public string SummonerId { get; set; }

        /// <summary>
        /// Level of the summoner.
        /// </summary>
        [JsonProperty("summonerLevel")]
        public long SummonerLevel { get; set; }

        /// <summary>
        /// Name of the summoner.
        /// </summary>
        [JsonProperty("summonerName")]
        public string SummonerName { get; set; }

        /// <summary>
        /// Flag whether team surrendered early.
        /// </summary>
        [JsonProperty("teamEarlySurrendered")]
        public bool TeamEarlySurrendered { get; set; }

        /// <summary>
        /// Team ID.
        /// </summary>
        [JsonProperty("teamId")]
        public int TeamId { get; set; }

        /// <summary>
        /// Team position.
        /// </summary>
        [JsonProperty("teamPosition")]
        public string TeamPosition { get; set; }

        /// <summary>
        /// Time crowd controling others.
        /// </summary>
        [JsonProperty("timeCCingOthers")]
        public long TimeCCingOthers { get; set; }

        /// <summary>
        /// Time crowd controling others.
        /// </summary>
        [JsonProperty("timePlayed")]
        [JsonConverter(typeof(TimeSpanConverterFromSeconds))]
        public TimeSpan timePlayed { get; set; }

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
        /// Total damage shielded on teammates.
        /// </summary>
        [JsonProperty("totalDamageShieldedOnTeammates")]
        public long TotalDamageShieldedOnTeammates { get; set; }

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
        /// Total heals on teammates.
        /// </summary>
        [JsonProperty("totalHealsOnTeammates")]
        public long TotalHealsOnTeammates { get; set; }

        /// <summary>
        /// Minions kiled.
        /// </summary>
        [JsonProperty("totalMinionsKilled")]
        public long TotalMinionsKilled { get; set; }

        /// <summary>
        /// Total time crowd control dealt.
        /// </summary>
        [JsonProperty("totalTimeCCDealt")]
        public long TotalTimeCCDealt { get; set; }

        /// <summary>
        /// Total time crowd control dealt.
        /// </summary>
        [JsonProperty("totalTimeSpentDead")]
        [JsonConverter(typeof(TimeSpanConverterFromSeconds))]
        public TimeSpan TotalTimeSpentDead { get; set; }

        /// <summary>
        /// Total units healed.
        /// </summary>
        [JsonProperty("totalUnitsHealed")]
        public long TotalUnitsHealed { get; set; }

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
        /// Number of tower kills.
        /// </summary>
        [JsonProperty("turretKills")]
        public long TurretKills { get; set; }

        /// <summary>
        /// Number of turrets lost.
        /// </summary>
        [JsonProperty("turretsLost")]
        public long TurretsLost { get; set; }

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
    }
}
