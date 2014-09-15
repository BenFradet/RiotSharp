using System;
using Newtonsoft.Json;

namespace RiotSharp.StaticDataEndpoint
{
    /// <summary>
    /// Class representing stats (Static API).
    /// </summary>
    [Serializable]
    public class StatsStatic
    {
        internal StatsStatic() { }

        public double FlatArmorMod { get; set; }

        public double FlatAttackSpeedMod { get; set; }

        public double FlatBlockMod { get; set; }

        public double FlatCritChanceMod { get; set; }

        public double FlatCritDamageMod { get; set; }

        public double FlatEnergyRegenMod { get; set; }

        public double FlatEnergyPoolMod { get; set; }

        public double FlatEXPBonus { get; set; }

        public double FlatHPPoolMod { get; set; }

        public double FlatHPRegenMod { get; set; }

        public double FlatMPPoolMod { get; set; }

        public double FlatMPRegenMod { get; set; }

        public double FlatMagicDamageMod { get; set; }

        public double FlatMovementSpeedMod { get; set; }

        public double FlatPhysicalDamageMod { get; set; }

        public double FlatSpellBlockMod { get; set; }

        public double PercentArmorMod { get; set; }

        public double PercentAttackSpeedMod { get; set; }

        public double PercentBlockMod { get; set; }

        public double PercentCritChanceMod { get; set; }

        public double PercentCritDamageMod { get; set; }

        public double PercentDodgeMod { get; set; }

        public double PercentEXPBonus { get; set; }

        public double PercentHPPoolMod { get; set; }

        public double PercentHPRegenMod { get; set; }

        public double PercentLifeStealMod { get; set; }

        public double PercentMPPoolMod { get; set; }

        public double PercentMPRegenMod { get; set; }

        public double PercentMagicDamageMod { get; set; }

        public double PercentMovementSpeedMod { get; set; }

        public double PercentPhysicalDamageMod { get; set; }

        public double PercentSpellBlockMod { get; set; }

        public double PercentSpellVampMod { get; set; }

        [JsonProperty("rFlatArmorModPerLevel")]
        public double RFlatArmorModPerLevel { get; set; }

        [JsonProperty("rFlatArmorPenetrationMod")]
        public double RFlatArmorPenetrationMod { get; set; }

        [JsonProperty("rFlatArmorPenetrationModPerLevel")]
        public double RFlatArmorPenetrationModPerLevel { get; set; }

        [JsonProperty("rFlatCritChanceModPerLevel")]
        public double RFlatCritChanceModPerLevel { get; set; }

        [JsonProperty("rFlatCritDamageModPerLevel")]
        public double RFlatCritDamageModPerLevel { get; set; }

        [JsonProperty("rFlatDodgeMod")]
        public double RFlatDodgeMod { get; set; }

        [JsonProperty("rFlatDodgeModPerLevel")]
        public double RFlatDodgeModPerLevel { get; set; }

        [JsonProperty("rFlatEnergyRegenModPerLevel")]
        public double RFlatEnergyRegenModPerLevel { get; set; }

        [JsonProperty("rFlatEnergyModPerLevel")]
        public double RFlatEnergyModPerLevel { get; set; }

        [JsonProperty("rFlatGoldPer10Mod")]
        public double RFlatGoldPer10Mod { get; set; }

        [JsonProperty("rFlatHPModPerLevel")]
        public double RFlatHPModPerLevel { get; set; }

        [JsonProperty("rFlatHPRegenModPerLevel")]
        public double RFlatHPRegenModPerLevel { get; set; }

        [JsonProperty("rFlatMPModPerLevel")]
        public double RFlatMPModPerLevel { get; set; }

        [JsonProperty("rFlatMPRegenModPerLevel")]
        public double RFlatMPRegenModPerLevel { get; set; }

        [JsonProperty("rFlatMagicDamageModPerLevel")]
        public double RFlatMagicDamageModPerLevel { get; set; }

        [JsonProperty("rFlatMagicPenetrationMod")]
        public double RFlatMagicPenetrationMod { get; set; }

        [JsonProperty("rFlatMagicPenetrationModPerLevel")]
        public double RFlatMagicPenetrationModPerLevel { get; set; }

        [JsonProperty("rFlatMovementSpeedModPerLevel")]
        public double RFlatMovementSpeedModPerLevel { get; set; }

        [JsonProperty("rFlatPhysicalDamageModPerLevel")]
        public double RFlatPhysicalDamageModPerLevel { get; set; }

        [JsonProperty("rFlatSpellBlockModPerLevel")]
        public double RFlatSpellBlockModPerLevel { get; set; }

        [JsonProperty("rFlatTimeDeadMod")]
        public double RFlatTimeDeadMod { get; set; }

        [JsonProperty("rFlatTimeDeadModPerLevel")]
        public double RFlatTimeDeadModPerLevel { get; set; }

        [JsonProperty("rPercentArmorPenetrationMod")]
        public double RPercentArmorPenetrationMod { get; set; }

        [JsonProperty("rPercentArmorPenetrationModPerLevel")]
        public double RPercentArmorPenetrationModPerLevel { get; set; }

        [JsonProperty("rPercentAttackSpeedModPerLevel")]
        public double RPercentAttackSpeedModPerLevel { get; set; }

        [JsonProperty("rPercentCooldownMod")]
        public double RPercentCooldownMod { get; set; }

        [JsonProperty("rPercentCooldownModPerLevel")]
        public double RPercentCooldownModPerLevel { get; set; }

        [JsonProperty("rPercentMagicPenetrationMod")]
        public double RPercentMagicPenetrationMod { get; set; }

        [JsonProperty("rPercentMagicPenetrationModPerLevel")]
        public double RPercentMagicPenetrationModPerLevel { get; set; }

        [JsonProperty("rPercentMovementSpeedModPerLevel")]
        public double RPercentMovementSpeedModPerLevel { get; set; }

        [JsonProperty("rPercentTimeDeadMod")]
        public double RPercentTimeDeadMod { get; set; }

        [JsonProperty("rPercentTimeDeadModPerLevel")]
        public double RPercentTimeDeadModPerLevel { get; set; }
    }
}
