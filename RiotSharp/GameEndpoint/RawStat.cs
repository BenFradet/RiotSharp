using System;
using Newtonsoft.Json;

namespace RiotSharp.GameEndpoint
{
    /// <summary>
    /// Raw stat of a game (Game API).
    /// </summary>
    [Serializable]
    public class RawStat
    {
        internal RawStat() { }

        /// <summary>
        /// Number of assists during the game.
        /// </summary>
        [JsonProperty("assists")]
        public int Assists { get; set; }

        /// <summary>
        /// Number of barracks destroyed during the game.
        /// </summary>
        [JsonProperty("barracksKilled")]
        public int BarracksKilled { get; set; }

        /// <summary>
        /// Number of champions killed during the game.
        /// </summary>
        [JsonProperty("championsKilled")]
        public int ChampionsKilled { get; set; }

        /// <summary>
        /// Combat player score, dominion only.
        /// </summary>
        [JsonProperty("combatPlayerScore")]
        public int CombatPlayerScore { get; set; }

        /// <summary>
        /// Number of consumbables purchased during the game.
        /// </summary>
        [JsonProperty("consumablesPurchased")]
        public int ConsumablesPurchased { get; set; }

        /// <summary>
        /// Damages dealt to player during the game.
        /// </summary>
        [JsonProperty("damageDealtPlayer")]
        public int DamageDealtPlayer { get; set; }

        /// <summary>
        /// Number of double kills during the game.
        /// </summary>
        [JsonProperty("doubleKills")]
        public int DoubleKills { get; set; }

        /// <summary>
        /// First blood.
        /// </summary>
        [JsonProperty("firstBlood")]
        public int FirstBlood { get; set; }

        /// <summary>
        /// Gold.
        /// </summary>
        [JsonProperty("gold")]
        public int Gold { get; set; }

        /// <summary>
        /// Gold earned during the game.
        /// </summary>
        [JsonProperty("goldEarned")]
        public int GoldEarned { get; set; }

        /// <summary>
        /// Gold spent during the game.
        /// </summary>
        [JsonProperty("goldSpent")]
        public int GoldSpent { get; set; }

        /// <summary>
        /// Id of the first item.
        /// </summary>
        [JsonProperty("item0")]
        public int Item0 { get; set; }

        /// <summary>
        /// Id of the second item.
        /// </summary>
        [JsonProperty("item1")]
        public int Item1 { get; set; }

        /// <summary>
        /// Id of the third item.
        /// </summary>
        [JsonProperty("item2")]
        public int Item2 { get; set; }

        /// <summary>
        /// Id of the fourth item.
        /// </summary>
        [JsonProperty("item3")]
        public int Item3 { get; set; }

        /// <summary>
        /// Id of the fifth item.
        /// </summary>
        [JsonProperty("item4")]
        public int Item4 { get; set; }

        /// <summary>
        /// Id of the sixth item.
        /// </summary>
        [JsonProperty("item5")]
        public int Item5 { get; set; }

        /// <summary>
        /// Id of the seventh item.
        /// </summary>
        [JsonProperty("item6")]
        public int Item6 { get; set; }

        /// <summary>
        /// Number of items purchased during the game.
        /// </summary>
        [JsonProperty("itemsPurchased")]
        public int ItemsPurchased { get; set; }

        /// <summary>
        /// Number of killing sprees during the game.
        /// </summary>
        [JsonProperty("killingSprees")]
        public int KillingSprees { get; set; }

        /// <summary>
        /// Largest criticial strike during the game.
        /// </summary>
        [JsonProperty("largestCriticalStrike")]
        public int LargestCriticalStrike { get; set; }

        /// <summary>
        /// Largest multi kill during the game.
        /// </summary>
        [JsonProperty("largestMultiKill")]
        public int LargestMultiKill { get; set; }

        /// <summary>
        /// Number of legendary items created during the game.
        /// </summary>
        [JsonProperty("legendaryItemsCreated")]
        public int LegendaryItemsCreated { get; set; }

        /// <summary>
        /// Level reached by the player at the end of the game.
        /// </summary>
        [JsonProperty("level")]
        public int Level { get; set; }

        /// <summary>
        /// Magic damage dealt by the player during the game.
        /// </summary>
        [JsonProperty("magicDamageDealtPlayer")]
        public int MagicDamageDealtPlayer { get; set; }

        /// <summary>
        /// Magic damage dealt by the player to champions during the game.
        /// </summary>
        [JsonProperty("magicDamageDealtToChampions")]
        public int MagicDamageDealtToChampions { get; set; }

        /// <summary>
        /// Magic damage taken by the player during the game.
        /// </summary>
        [JsonProperty("magicDamageTaken")]
        public int MagicDamageTaken { get; set; }

        /// <summary>
        /// Number of minions denied during the game.
        /// </summary>
        [JsonProperty("minionsDenied")]
        public int MinionsDenied { get; set; }

        /// <summary>
        /// Number of minions killed during the game.
        /// </summary>
        [JsonProperty("minionsKilled")]
        public int MinionsKilled { get; set; }

        /// <summary>
        /// Number of neutral minions killed during the game.
        /// </summary>
        [JsonProperty("neutralMinionsKilled")]
        public int NeutralMinionsKilled { get; set; }

        /// <summary>
        /// Number of neutral minions killed in the enemy's jungle during the game.
        /// </summary>
        [JsonProperty("neutralMinionsKilledEnemyJungle")]
        public int NeutralMinionsKilledEnemyJungle { get; set; }

        /// <summary>
        /// Number of neutral minions killed in the player's jungle during the game.
        /// </summary>
        [JsonProperty("neutralMinionsKilledYourJungle")]
        public int NeutralMinionsKilledYourJungle { get; set; }

        /// <summary>
        /// Has the player killed the nexus?
        /// </summary>
        [JsonProperty("nexusKilled")]
        public bool NexusKilled { get; set; }

        /// <summary>
        /// Number of nodes captured during the game, dominion only.
        /// </summary>
        [JsonProperty("nodeCapture")]
        public int NodeCapture { get; set; }

        /// <summary>
        /// Number of assists on nodes captured during the game, dominion only.
        /// </summary>
        [JsonProperty("nodeCaptureAssist")]
        public int NodeCaptureAssist { get; set; }

        /// <summary>
        /// Number of nodes neutralized during the game.
        /// </summary>
        [JsonProperty("nodeNeutralize")]
        public int NodeNeutralize { get; set; }

        /// <summary>
        /// Number of assists on nodes neutralized during the game.
        /// </summary>
        [JsonProperty("nodeNeutralizeAssist")]
        public int NodeNeutralizeAssist { get; set; }

        /// <summary>
        /// Number of deaths during the game.
        /// </summary>
        [JsonProperty("numDeaths")]
        public int NumDeaths { get; set; }

        /// <summary>
        /// Number of items bought during the game.
        /// </summary>
        [JsonProperty("numItemsBought")]
        public int NumItemsBought { get; set; }

        /// <summary>
        /// Objective score, dominion only.
        /// </summary>
        [JsonProperty("objectivePlayerScore")]
        public int ObjectivePlayerScore { get; set; }

        /// <summary>
        /// Number of penta kills during the game.
        /// </summary>
        [JsonProperty("pentaKills")]
        public int PentaKills { get; set; }

        /// <summary>
        /// Physical damage dealt by the player during the game.
        /// </summary>
        [JsonProperty("physicalDamageDealtPlayer")]
        public int PhysicalDamageDealtPlayer { get; set; }

        /// <summary>
        /// Physical damage dealt by the player to champions during the game.
        /// </summary>
        [JsonProperty("physicalDamageDealtToChampions")]
        public int PhysicalDamageDealtToChampions { get; set; }

        /// <summary>
        /// Physical damage taken by the player during the game.
        /// </summary>
        [JsonProperty("physicalDamageTaken")]
        public int PhysicalDamageTaken { get; set; }

        /// <summary>
        /// Number of quadra kills during the game.
        /// </summary>
        [JsonProperty("quadraKills")]
        public int QuadraKills { get; set; }

        /// <summary>
        /// Number of sight wards bought during the game.
        /// </summary>
        [JsonProperty("sightWardsBought")]
        public int SightWardsBought { get; set; }

        /// <summary>
        /// Number of casts of spell1 (Q) during the game.
        /// </summary>
        [JsonProperty("spell1Cast")]
        public int Spell1Cast { get; set; }

        /// <summary>
        /// Number of casts of spell2 (W) during the game.
        /// </summary>
        [JsonProperty("spell2Cast")]
        public int Spell2Cast { get; set; }

        /// <summary>
        /// Number of casts of spell3 (E) during the game.
        /// </summary>
        [JsonProperty("spell3Cast")]
        public int Spell3Cast { get; set; }

        /// <summary>
        /// Number of casts of spell4 (R) during the game.
        /// </summary>
        [JsonProperty("spell4Cast")]
        public int Spell4Cast { get; set; }

        /// <summary>
        /// Number of casts of summoner spell1 during the game.
        /// </summary>
        [JsonProperty("summonSpell1Cast")]
        public int SummonSpell1Cast { get; set; }

        /// <summary>
        /// Number of casts of summoner spell2 during the game.
        /// </summary>
        [JsonProperty("summonSpell2Cast")]
        public int SummonSpell2Cast { get; set; }

        /// <summary>
        /// Number of super monsters killed during the game.
        /// </summary>
        [JsonProperty("superMonsterKilled")]
        public int SuperMonsterKilled { get; set; }

        /// <summary>
        /// Team.
        /// </summary>
        [JsonProperty("team")]
        public int Team { get; set; }

        /// <summary>
        /// Team objective, dominion only.
        /// </summary>
        [JsonProperty("teamObjective")]
        public int TeamObjective { get; set; }

        /// <summary>
        /// Time played.
        /// </summary>
        [JsonProperty("timePlayed")]
        [JsonConverter(typeof(TimeSpanConverterFromS))]
        public TimeSpan TimePlayed { get; set; }

        /// <summary>
        /// Total damage dealt by the player during the game.
        /// </summary>
        [JsonProperty("totalDamageDealt")]
        public int TotalDamageDealt { get; set; }

        /// <summary>
        /// Total damage dealt by the player to champions during the game.
        /// </summary>
        [JsonProperty("totalDamageDealtToChampions")]
        public int TotalDamageDealtToChampions { get; set; }

        /// <summary>
        /// Total damage taken by the player during the game.
        /// </summary>
        [JsonProperty("totalDamageTaken")]
        public int TotalDamageTaken { get; set; }

        /// <summary>
        /// Total health points restored by the player during the game.
        /// </summary>
        [JsonProperty("totalHeal")]
        public int TotalHeal { get; set; }

        /// <summary>
        /// Total score of the player, dominion only.
        /// </summary>
        [JsonProperty("totalPlayerScore")]
        public int TotalPlayerScore { get; set; }

        /// <summary>
        /// Total score rank, dominion only.
        /// </summary>
        [JsonProperty("totalScoreRank")]
        public int TotalScoreRank { get; set; }

        /// <summary>
        /// Amount of time of crowd control given to enemies during the game.
        /// </summary>
        [JsonProperty("totalTimeCrowdControlDealt")]
        [JsonConverter(typeof(TimeSpanConverterFromS))]
        public TimeSpan TotalTimeCrowdControlDealt { get; set; }

        /// <summary>
        /// Number of units healed during the game.
        /// </summary>
        [JsonProperty("totalUnitsHealed")]
        public int TotalUnitsHealed { get; set; }

        /// <summary>
        /// Number of triple kills.
        /// </summary>
        [JsonProperty("tripleKills")]
        public int TripleKills { get; set; }

        /// <summary>
        /// True damage dealt by the player during the game.
        /// </summary>
        [JsonProperty("trueDamageDealtPlayer")]
        public int TrueDamageDealtPlayer { get; set; }

        /// <summary>
        /// True damage dealt by the player to champions during the game.
        /// </summary>
        [JsonProperty("trueDamageDealtToChampions")]
        public int TrueDamageDealtToChampions { get; set; }

        /// <summary>
        /// True damage taken by the player during the game.
        /// </summary>
        [JsonProperty("trueDamageTaken")]
        public int TrueDamageTaken { get; set; }

        /// <summary>
        /// Number of turrets killed by the player during the game.
        /// </summary>
        [JsonProperty("turretsKilled")]
        public int TurretsKilled { get; set; }

        /// <summary>
        /// Number of unreal kills.
        /// </summary>
        [JsonProperty("unrealKills")]
        public int UnrealKills { get; set; }

        /// <summary>
        /// Number of victory points in total, dominion only.
        /// </summary>
        [JsonProperty("victoryPointTotal")]
        public int VictoryPointTotal { get; set; }

        /// <summary>
        /// Number of vision wards bought during the game.
        /// </summary>
        [JsonProperty("visionWardsBought")]
        public int VisionWardsBought { get; set; }

        /// <summary>
        /// Number of wards killed during the game.
        /// </summary>
        [JsonProperty("wardKilled")]
        public int WardKilled { get; set; }

        /// <summary>
        /// Number of wards placed during the game.
        /// </summary>
        [JsonProperty("wardPlaced")]
        public int WardPlaced { get; set; }

        /// <summary>
        /// Has the player won the game?
        /// </summary>
        [JsonProperty("win")]
        public bool Win { get; set; }
    }
}
