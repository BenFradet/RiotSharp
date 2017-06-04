using Newtonsoft.Json;

namespace RiotSharp.StaticDataEndpoint
{
    /// <summary>
    /// Class representing stats (Static API).
    /// </summary>
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

        [JsonProperty("FlatArmorModPerLevel")]
        public double FlatArmorModPerLevel { get; set; }

        [JsonProperty("FlatArmorPenetrationMod")]
        public double FlatArmorPenetrationMod { get; set; }

        [JsonProperty("FlatArmorPenetrationModPerLevel")]
        public double FlatArmorPenetrationModPerLevel { get; set; }

        [JsonProperty("FlatCritChanceModPerLevel")]
        public double FlatCritChanceModPerLevel { get; set; }

        [JsonProperty("FlatCritDamageModPerLevel")]
        public double FlatCritDamageModPerLevel { get; set; }

        [JsonProperty("FlatDodgeMod")]
        public double FlatDodgeMod { get; set; }

        [JsonProperty("FlatDodgeModPerLevel")]
        public double FlatDodgeModPerLevel { get; set; }

        [JsonProperty("FlatEnergyRegenModPerLevel")]
        public double FlatEnergyRegenModPerLevel { get; set; }

        [JsonProperty("FlatEnergyModPerLevel")]
        public double FlatEnergyModPerLevel { get; set; }

        [JsonProperty("FlatGoldPer10Mod")]
        public double FlatGoldPer10Mod { get; set; }

        [JsonProperty("FlatHPModPerLevel")]
        public double FlatHPModPerLevel { get; set; }

        [JsonProperty("FlatHPRegenModPerLevel")]
        public double FlatHPRegenModPerLevel { get; set; }

        [JsonProperty("FlatMPModPerLevel")]
        public double FlatMPModPerLevel { get; set; }

        [JsonProperty("FlatMPRegenModPerLevel")]
        public double FlatMPRegenModPerLevel { get; set; }

        [JsonProperty("FlatMagicDamageModPerLevel")]
        public double FlatMagicDamageModPerLevel { get; set; }

        [JsonProperty("FlatMagicPenetrationMod")]
        public double FlatMagicPenetrationMod { get; set; }

        [JsonProperty("FlatMagicPenetrationModPerLevel")]
        public double FlatMagicPenetrationModPerLevel { get; set; }

        [JsonProperty("FlatMovementSpeedModPerLevel")]
        public double FlatMovementSpeedModPerLevel { get; set; }

        [JsonProperty("FlatPhysicalDamageModPerLevel")]
        public double FlatPhysicalDamageModPerLevel { get; set; }

        [JsonProperty("FlatSpellBlockModPerLevel")]
        public double FlatSpellBlockModPerLevel { get; set; }

        [JsonProperty("FlatTimeDeadMod")]
        public double FlatTimeDeadMod { get; set; }

        [JsonProperty("FlatTimeDeadModPerLevel")]
        public double FlatTimeDeadModPerLevel { get; set; }

        [JsonProperty("PercentArmorPenetrationMod")]
        public double PercentArmorPenetrationMod { get; set; }

        [JsonProperty("PercentArmorPenetrationModPerLevel")]
        public double PercentArmorPenetrationModPerLevel { get; set; }

        [JsonProperty("PercentAttackSpeedModPerLevel")]
        public double PercentAttackSpeedModPerLevel { get; set; }

        [JsonProperty("PercentCooldownMod")]
        public double PercentCooldownMod { get; set; }

        [JsonProperty("PercentCooldownModPerLevel")]
        public double PercentCooldownModPerLevel { get; set; }

        [JsonProperty("PercentMagicPenetrationMod")]
        public double PercentMagicPenetrationMod { get; set; }

        [JsonProperty("PercentMagicPenetrationModPerLevel")]
        public double PercentMagicPenetrationModPerLevel { get; set; }

        [JsonProperty("PercentMovementSpeedModPerLevel")]
        public double PercentMovementSpeedModPerLevel { get; set; }

        [JsonProperty("PercentTimeDeadMod")]
        public double PercentTimeDeadMod { get; set; }

        [JsonProperty("PercentTimeDeadModPerLevel")]
        public double PercentTimeDeadModPerLevel { get; set; }
    }
}
