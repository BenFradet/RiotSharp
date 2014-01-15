using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace RiotSharp
{
    /// <summary>
    /// Raw stat of a game (Game API).
    /// </summary>
    public class RawStat : Thing
    {
        [JsonProperty("assists")]
        public int Assists { get; set; }

        [JsonProperty("barracksKilled")]
        public int BarracksKilled { get; set; }

        [JsonProperty("championsKilled")]
        public int ChampionsKilled { get; set; }

        [JsonProperty("combatPlayerScore")]
        public int CombatPlayerScore { get; set; }

        [JsonProperty("consumablesPurchased")]
        public int ConsumablesPurchased { get; set; }

        [JsonProperty("damageDealtPlayer")]
        public int DamageDealtPlayer { get; set; }

        [JsonProperty("doubleKills")]
        public int DoubleKills { get; set; }

        [JsonProperty("firstBlood")]
        public int FirstBlood { get; set; }

        [JsonProperty("gold")]
        public int Gold { get; set; }

        [JsonProperty("goldEarned")]
        public int GoldEarned { get; set; }

        [JsonProperty("goldSpent")]
        public int GoldSpent { get; set; }

        [JsonProperty("item0")]
        public int Item0 { get; set; }

        [JsonProperty("item1")]
        public int Item1 { get; set; }

        [JsonProperty("item2")]
        public int Item2 { get; set; }

        [JsonProperty("item3")]
        public int Item3 { get; set; }

        [JsonProperty("item4")]
        public int Item4 { get; set; }

        [JsonProperty("item5")]
        public int Item5 { get; set; }

        [JsonProperty("item6")]
        public int Item6 { get; set; }

        [JsonProperty("itemsPurchased")]
        public int ItemsPurchased { get; set; }

        [JsonProperty("killingSprees")]
        public int KillingSprees { get; set; }

        [JsonProperty("largestCriticalStrike")]
        public int LargestCriticalStrike { get; set; }

        [JsonProperty("largestMultiKill")]
        public int LargestMultiKill { get; set; }

        [JsonProperty("legendaryItemsCreated")]
        public int LegendaryItemsCreated { get; set; }

        [JsonProperty("level")]
        public int Level { get; set; }

        [JsonProperty("magicDamageDealtPlayer")]
        public int MagicDamageDealtPlayer { get; set; }

        [JsonProperty("magicDamageDealtToChampions")]
        public int MagicDamageDealtToChampions { get; set; }

        [JsonProperty("magicDamageTaken")]
        public int MagicDamageTaken { get; set; }

        [JsonProperty("minionsDenied")]
        public int MinionsDenied { get; set; }

        [JsonProperty("minionsKilled")]
        public int MinionsKilled { get; set; }

        [JsonProperty("neutralMinionsKilled")]
        public int NeutralMinionsKilled { get; set; }

        [JsonProperty("neutralMinionsKilledEnemyJungle")]
        public int NeutralMinionsKilledEnemyJungle { get; set; }

        [JsonProperty("neutralMinionsKilledYourJungle")]
        public int NeutralMinionsKilledYourJungle { get; set; }

        [JsonProperty("nexusKilled")]
        public bool NexusKilled { get; set; }

        [JsonProperty("nodeCapture")]
        public int NodeCapture { get; set; }

        [JsonProperty("nodeCaptureAssist")]
        public int NodeCaptureAssist { get; set; }

        [JsonProperty("nodeNeutralize")]
        public int NodeNeutralize { get; set; }

        [JsonProperty("nodeNeutralizeAssist")]
        public int NodeNeutralizeAssist { get; set; }

        [JsonProperty("numDeaths")]
        public int NumDeaths { get; set; }

        [JsonProperty("numItemsBought")]
        public int NumItemsBought { get; set; }

        [JsonProperty("objectivePlayerScore")]
        public int ObjectivePlayerScore { get; set; }

        [JsonProperty("pentaKills")]
        public int PentaKills { get; set; }

        [JsonProperty("physicalDamageDealtPlayer")]
        public int PhysicalDamageDealtPlayer { get; set; }

        [JsonProperty("physicalDamageDealtToChampions")]
        public int PhysicalDamageDealtToChampions { get; set; }

        [JsonProperty("physicalDamageTaken")]
        public int PhysicalDamageTaken { get; set; }

        [JsonProperty("quadraKills")]
        public int QuadraKills { get; set; }

        [JsonProperty("sightWardsBought")]
        public int SightWardsBought { get; set; }

        [JsonProperty("spell1Cast")]
        public int Spell1Cast { get; set; }

        [JsonProperty("spell2Cast")]
        public int Spell2Cast { get; set; }

        [JsonProperty("spell3Cast")]
        public int Spell3Cast { get; set; }

        [JsonProperty("spell4Cast")]
        public int Spell4Cast { get; set; }

        [JsonProperty("summonSpell1Cast")]
        public int SummonSpell1Cast { get; set; }

        [JsonProperty("summonSpell2Cast")]
        public int SummonSpell2Cast { get; set; }

        [JsonProperty("superMonsterKilled")]
        public int SuperMonsterKilled { get; set; }

        [JsonProperty("team")]
        public int Team { get; set; }

        [JsonProperty("teamObjective")]
        public int TeamObjective { get; set; }

        [JsonProperty("timePlayed")]
        public int TimePlayed { get; set; }

        [JsonProperty("totalDamageDealt")]
        public int TotalDamageDealt { get; set; }

        [JsonProperty("totalDamageDealtToChampions")]
        public int TotalDamageDealtToChampions { get; set; }

        [JsonProperty("totalDamageTaken")]
        public int TotalDamageTaken { get; set; }

        [JsonProperty("totalHeal")]
        public int TotalHeal { get; set; }

        [JsonProperty("totalPlayerScore")]
        public int TotalPlayerScore { get; set; }

        [JsonProperty("totalScoreRank")]
        public int TotalScoreRank { get; set; }

        [JsonProperty("totalTimeCrowdControlDealt")]
        public int TotalTimeCrowdControlDealt { get; set; }

        [JsonProperty("totalUnitsHealed")]
        public int TotalUnitsHealed { get; set; }

        [JsonProperty("tripleKills")]
        public int TripleKills { get; set; }

        [JsonProperty("trueDamageDealtPlayer")]
        public int TrueDamageDealtPlayer { get; set; }

        [JsonProperty("trueDamageDealtToChampions")]
        public int TrueDamageDealtToChampions { get; set; }

        [JsonProperty("trueDamageTaken")]
        public int TrueDamageTaken { get; set; }

        [JsonProperty("turretsKilled")]
        public int TurretsKilled { get; set; }

        [JsonProperty("unrealKills")]
        public int UnrealKills { get; set; }

        [JsonProperty("victoryPointTotal")]
        public int VictoryPointTotal { get; set; }

        [JsonProperty("visionWardsBought")]
        public int VisionWardsBought { get; set; }

        [JsonProperty("wardKilled")]
        public int WardKilled { get; set; }

        [JsonProperty("wardPlaced")]
        public int WardPlaced { get; set; }

        [JsonProperty("win")]
        public bool Win { get; set; }
    }
}
