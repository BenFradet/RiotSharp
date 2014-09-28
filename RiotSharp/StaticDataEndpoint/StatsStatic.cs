// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StatsStatic.cs" company="">
//   
// </copyright>
// <summary>
//   Class representing stats (Static API).
// </summary>
// --------------------------------------------------------------------------------------------------------------------

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
        /// <summary>
        /// Initializes a new instance of the <see cref="StatsStatic"/> class.
        /// </summary>
        internal StatsStatic() { }

        /// <summary>
        /// Gets or sets the flat armor mod.
        /// </summary>
        public double FlatArmorMod { get; set; }

        /// <summary>
        /// Gets or sets the flat attack speed mod.
        /// </summary>
        public double FlatAttackSpeedMod { get; set; }

        /// <summary>
        /// Gets or sets the flat block mod.
        /// </summary>
        public double FlatBlockMod { get; set; }

        /// <summary>
        /// Gets or sets the flat crit chance mod.
        /// </summary>
        public double FlatCritChanceMod { get; set; }

        /// <summary>
        /// Gets or sets the flat crit damage mod.
        /// </summary>
        public double FlatCritDamageMod { get; set; }

        /// <summary>
        /// Gets or sets the flat energy regen mod.
        /// </summary>
        public double FlatEnergyRegenMod { get; set; }

        /// <summary>
        /// Gets or sets the flat energy pool mod.
        /// </summary>
        public double FlatEnergyPoolMod { get; set; }

        /// <summary>
        /// Gets or sets the flat exp bonus.
        /// </summary>
        public double FlatEXPBonus { get; set; }

        /// <summary>
        /// Gets or sets the flat hp pool mod.
        /// </summary>
        public double FlatHPPoolMod { get; set; }

        /// <summary>
        /// Gets or sets the flat hp regen mod.
        /// </summary>
        public double FlatHPRegenMod { get; set; }

        /// <summary>
        /// Gets or sets the flat mp pool mod.
        /// </summary>
        public double FlatMPPoolMod { get; set; }

        /// <summary>
        /// Gets or sets the flat mp regen mod.
        /// </summary>
        public double FlatMPRegenMod { get; set; }

        /// <summary>
        /// Gets or sets the flat magic damage mod.
        /// </summary>
        public double FlatMagicDamageMod { get; set; }

        /// <summary>
        /// Gets or sets the flat movement speed mod.
        /// </summary>
        public double FlatMovementSpeedMod { get; set; }

        /// <summary>
        /// Gets or sets the flat physical damage mod.
        /// </summary>
        public double FlatPhysicalDamageMod { get; set; }

        /// <summary>
        /// Gets or sets the flat spell block mod.
        /// </summary>
        public double FlatSpellBlockMod { get; set; }

        /// <summary>
        /// Gets or sets the percent armor mod.
        /// </summary>
        public double PercentArmorMod { get; set; }

        /// <summary>
        /// Gets or sets the percent attack speed mod.
        /// </summary>
        public double PercentAttackSpeedMod { get; set; }

        /// <summary>
        /// Gets or sets the percent block mod.
        /// </summary>
        public double PercentBlockMod { get; set; }

        /// <summary>
        /// Gets or sets the percent crit chance mod.
        /// </summary>
        public double PercentCritChanceMod { get; set; }

        /// <summary>
        /// Gets or sets the percent crit damage mod.
        /// </summary>
        public double PercentCritDamageMod { get; set; }

        /// <summary>
        /// Gets or sets the percent dodge mod.
        /// </summary>
        public double PercentDodgeMod { get; set; }

        /// <summary>
        /// Gets or sets the percent exp bonus.
        /// </summary>
        public double PercentEXPBonus { get; set; }

        /// <summary>
        /// Gets or sets the percent hp pool mod.
        /// </summary>
        public double PercentHPPoolMod { get; set; }

        /// <summary>
        /// Gets or sets the percent hp regen mod.
        /// </summary>
        public double PercentHPRegenMod { get; set; }

        /// <summary>
        /// Gets or sets the percent life steal mod.
        /// </summary>
        public double PercentLifeStealMod { get; set; }

        /// <summary>
        /// Gets or sets the percent mp pool mod.
        /// </summary>
        public double PercentMPPoolMod { get; set; }

        /// <summary>
        /// Gets or sets the percent mp regen mod.
        /// </summary>
        public double PercentMPRegenMod { get; set; }

        /// <summary>
        /// Gets or sets the percent magic damage mod.
        /// </summary>
        public double PercentMagicDamageMod { get; set; }

        /// <summary>
        /// Gets or sets the percent movement speed mod.
        /// </summary>
        public double PercentMovementSpeedMod { get; set; }

        /// <summary>
        /// Gets or sets the percent physical damage mod.
        /// </summary>
        public double PercentPhysicalDamageMod { get; set; }

        /// <summary>
        /// Gets or sets the percent spell block mod.
        /// </summary>
        public double PercentSpellBlockMod { get; set; }

        /// <summary>
        /// Gets or sets the percent spell vamp mod.
        /// </summary>
        public double PercentSpellVampMod { get; set; }

        /// <summary>
        /// Gets or sets the r flat armor mod per level.
        /// </summary>
        [JsonProperty("rFlatArmorModPerLevel")]
        public double RFlatArmorModPerLevel { get; set; }

        /// <summary>
        /// Gets or sets the r flat armor penetration mod.
        /// </summary>
        [JsonProperty("rFlatArmorPenetrationMod")]
        public double RFlatArmorPenetrationMod { get; set; }

        /// <summary>
        /// Gets or sets the r flat armor penetration mod per level.
        /// </summary>
        [JsonProperty("rFlatArmorPenetrationModPerLevel")]
        public double RFlatArmorPenetrationModPerLevel { get; set; }

        /// <summary>
        /// Gets or sets the r flat crit chance mod per level.
        /// </summary>
        [JsonProperty("rFlatCritChanceModPerLevel")]
        public double RFlatCritChanceModPerLevel { get; set; }

        /// <summary>
        /// Gets or sets the r flat crit damage mod per level.
        /// </summary>
        [JsonProperty("rFlatCritDamageModPerLevel")]
        public double RFlatCritDamageModPerLevel { get; set; }

        /// <summary>
        /// Gets or sets the r flat dodge mod.
        /// </summary>
        [JsonProperty("rFlatDodgeMod")]
        public double RFlatDodgeMod { get; set; }

        /// <summary>
        /// Gets or sets the r flat dodge mod per level.
        /// </summary>
        [JsonProperty("rFlatDodgeModPerLevel")]
        public double RFlatDodgeModPerLevel { get; set; }

        /// <summary>
        /// Gets or sets the r flat energy regen mod per level.
        /// </summary>
        [JsonProperty("rFlatEnergyRegenModPerLevel")]
        public double RFlatEnergyRegenModPerLevel { get; set; }

        /// <summary>
        /// Gets or sets the r flat energy mod per level.
        /// </summary>
        [JsonProperty("rFlatEnergyModPerLevel")]
        public double RFlatEnergyModPerLevel { get; set; }

        /// <summary>
        /// Gets or sets the r flat gold per 10 mod.
        /// </summary>
        [JsonProperty("rFlatGoldPer10Mod")]
        public double RFlatGoldPer10Mod { get; set; }

        /// <summary>
        /// Gets or sets the r flat hp mod per level.
        /// </summary>
        [JsonProperty("rFlatHPModPerLevel")]
        public double RFlatHPModPerLevel { get; set; }

        /// <summary>
        /// Gets or sets the r flat hp regen mod per level.
        /// </summary>
        [JsonProperty("rFlatHPRegenModPerLevel")]
        public double RFlatHPRegenModPerLevel { get; set; }

        /// <summary>
        /// Gets or sets the r flat mp mod per level.
        /// </summary>
        [JsonProperty("rFlatMPModPerLevel")]
        public double RFlatMPModPerLevel { get; set; }

        /// <summary>
        /// Gets or sets the r flat mp regen mod per level.
        /// </summary>
        [JsonProperty("rFlatMPRegenModPerLevel")]
        public double RFlatMPRegenModPerLevel { get; set; }

        /// <summary>
        /// Gets or sets the r flat magic damage mod per level.
        /// </summary>
        [JsonProperty("rFlatMagicDamageModPerLevel")]
        public double RFlatMagicDamageModPerLevel { get; set; }

        /// <summary>
        /// Gets or sets the r flat magic penetration mod.
        /// </summary>
        [JsonProperty("rFlatMagicPenetrationMod")]
        public double RFlatMagicPenetrationMod { get; set; }

        /// <summary>
        /// Gets or sets the r flat magic penetration mod per level.
        /// </summary>
        [JsonProperty("rFlatMagicPenetrationModPerLevel")]
        public double RFlatMagicPenetrationModPerLevel { get; set; }

        /// <summary>
        /// Gets or sets the r flat movement speed mod per level.
        /// </summary>
        [JsonProperty("rFlatMovementSpeedModPerLevel")]
        public double RFlatMovementSpeedModPerLevel { get; set; }

        /// <summary>
        /// Gets or sets the r flat physical damage mod per level.
        /// </summary>
        [JsonProperty("rFlatPhysicalDamageModPerLevel")]
        public double RFlatPhysicalDamageModPerLevel { get; set; }

        /// <summary>
        /// Gets or sets the r flat spell block mod per level.
        /// </summary>
        [JsonProperty("rFlatSpellBlockModPerLevel")]
        public double RFlatSpellBlockModPerLevel { get; set; }

        /// <summary>
        /// Gets or sets the r flat time dead mod.
        /// </summary>
        [JsonProperty("rFlatTimeDeadMod")]
        public double RFlatTimeDeadMod { get; set; }

        /// <summary>
        /// Gets or sets the r flat time dead mod per level.
        /// </summary>
        [JsonProperty("rFlatTimeDeadModPerLevel")]
        public double RFlatTimeDeadModPerLevel { get; set; }

        /// <summary>
        /// Gets or sets the r percent armor penetration mod.
        /// </summary>
        [JsonProperty("rPercentArmorPenetrationMod")]
        public double RPercentArmorPenetrationMod { get; set; }

        /// <summary>
        /// Gets or sets the r percent armor penetration mod per level.
        /// </summary>
        [JsonProperty("rPercentArmorPenetrationModPerLevel")]
        public double RPercentArmorPenetrationModPerLevel { get; set; }

        /// <summary>
        /// Gets or sets the r percent attack speed mod per level.
        /// </summary>
        [JsonProperty("rPercentAttackSpeedModPerLevel")]
        public double RPercentAttackSpeedModPerLevel { get; set; }

        /// <summary>
        /// Gets or sets the r percent cooldown mod.
        /// </summary>
        [JsonProperty("rPercentCooldownMod")]
        public double RPercentCooldownMod { get; set; }

        /// <summary>
        /// Gets or sets the r percent cooldown mod per level.
        /// </summary>
        [JsonProperty("rPercentCooldownModPerLevel")]
        public double RPercentCooldownModPerLevel { get; set; }

        /// <summary>
        /// Gets or sets the r percent magic penetration mod.
        /// </summary>
        [JsonProperty("rPercentMagicPenetrationMod")]
        public double RPercentMagicPenetrationMod { get; set; }

        /// <summary>
        /// Gets or sets the r percent magic penetration mod per level.
        /// </summary>
        [JsonProperty("rPercentMagicPenetrationModPerLevel")]
        public double RPercentMagicPenetrationModPerLevel { get; set; }

        /// <summary>
        /// Gets or sets the r percent movement speed mod per level.
        /// </summary>
        [JsonProperty("rPercentMovementSpeedModPerLevel")]
        public double RPercentMovementSpeedModPerLevel { get; set; }

        /// <summary>
        /// Gets or sets the r percent time dead mod.
        /// </summary>
        [JsonProperty("rPercentTimeDeadMod")]
        public double RPercentTimeDeadMod { get; set; }

        /// <summary>
        /// Gets or sets the r percent time dead mod per level.
        /// </summary>
        [JsonProperty("rPercentTimeDeadModPerLevel")]
        public double RPercentTimeDeadModPerLevel { get; set; }
    }
}
