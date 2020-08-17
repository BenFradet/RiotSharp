using Newtonsoft.Json;
using RiotSharp.Endpoints.ClientEndpoint.Enums;

namespace RiotSharp.Endpoints.ClientEndpoint.ActivePlayer
{
    /// <summary>
    /// Represents the champion stats of the <see cref="ActivePlayer"/>.
    /// </summary>
    public class ActivePlayerChampionStats
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ActivePlayerChampionStats"/> class.
        /// </summary>
        internal ActivePlayerChampionStats() { }

        /// <summary>
        /// Gets or sets the ability power.
        /// </summary>
        [JsonProperty("abilityPower")]
        public double AbilityPower { get; set; }

        /// <summary>
        /// Gets or sets the armor.
        /// </summary>
        [JsonProperty("armor")]
        public double Armor { get; set; }

        /// <summary>
        /// Gets or sets the flat armor penetration.
        /// </summary>
        [JsonProperty("armorPenetrationFlat")]
        public double ArmorPenetrationFlat { get; set; }

        /// <summary>
        /// Gets or sets the percent armor penetration.
        /// </summary>
        [JsonProperty("armorPenetrationPercent")]
        public double ArmorPenetrationPercent { get; set; }

        /// <summary>
        /// Gets or sets the attack damage.
        /// </summary>
        [JsonProperty("attackDamage")]
        public double AttackDamage { get; set; }

        /// <summary>
        /// Gets or sets the attack range.
        /// </summary>
        [JsonProperty("attackRange")]
        public double AttackRange { get; set; }

        /// <summary>
        /// Gets or sets the attack speed.
        /// </summary>
        [JsonProperty("attackSpeed")]
        public double AttackSpeed { get; set; }

        /// <summary>
        /// Gets or sets the bonus percent armor penetration.
        /// </summary>
        [JsonProperty("bonusArmorPenetrationPercent")]
        public double BonusArmorPenetrationPercent { get; set; }

        /// <summary>
        /// Gets or sets the bonus percent magic penetration.
        /// </summary>
        [JsonProperty("bonusMagicPenetrationPercent")]
        public double BonusMagicPenetrationPercent { get; set; }

        /// <summary>
        /// Gets or sets the cooldown reduction.
        /// </summary>
        [JsonProperty("cooldownReduction")]
        public double CooldownReduction { get; set; }

        /// <summary>
        /// Gets or sets the chance to critically strike.
        /// </summary>
        [JsonProperty("critChance")]
        public double CriticalChance { get; set; }

        /// <summary>
        /// Gets or sets the damage of a critical strike.
        /// </summary>
        [JsonProperty("critDamage")]
        public double CriticalDamage { get; set; }

        /// <summary>
        /// Gets or sets the current health.
        /// </summary>
        [JsonProperty("currentHealth")]
        public double CurrentHealth { get; set; }

        /// <summary>
        /// Gets or sets the health regeneration rate.
        /// </summary>
        [JsonProperty("healthRegenRate")]
        public double HealthRegenerationRate { get; set; }

        /// <summary>
        /// Gets or sets the life steal.
        /// </summary>
        [JsonProperty("lifeSteal")]
        public double LifeSteal { get; set; }

        /// <summary>
        /// Gets or sets the magic lethality.
        /// </summary>
        [JsonProperty("magicLethality")]
        public double MagicLethality { get; set; }

        /// <summary>
        /// Gets or sets the flat magic penetration.
        /// </summary>
        [JsonProperty("magicPenetrationFlat")]
        public double MagicPenetrationFlat { get; set; }

        /// <summary>
        /// Gets or sets the percent magic penetration.
        /// </summary>
        [JsonProperty("magicPenetrationPercent")]
        public double MagicPenetrationPercent { get; set; }

        /// <summary>
        /// Gets or sets the magic resistance.
        /// </summary>
        [JsonProperty("magicResist")]
        public double MagicResistance { get; set; }

        /// <summary>
        /// Gets or sets the maximum health.
        /// </summary>
        [JsonProperty("maxHealth")]
        public double MaximumHealth { get; set; }

        /// <summary>
        /// Gets or sets the movement speed.
        /// </summary>
        [JsonProperty("moveSpeed")]
        public double MovementSpeed { get; set; }

        /// <summary>
        /// Gets or sets the physical lethality.
        /// </summary>
        [JsonProperty("physicalLethality")]
        public double PhysicalLethality { get; set; }

        /// <summary>
        /// Gets or sets the resource maximum.
        /// </summary>
        [JsonProperty("resourceMax")]
        public double ResourceMaximum { get; set; }

        /// <summary>
        /// Gets or sets the resource regeneration rate.
        /// </summary>
        [JsonProperty("resourceRegenRate")]
        public double ResourceRegenerationRate { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="ResourceType"/>.
        /// </summary>
        [JsonProperty("resourceType")]
        public ResourceType ResourceType { get; set; }

        /// <summary>
        /// Gets or sets the current resource value.
        /// </summary>
        [JsonProperty("resourceValue")]
        public double CurrentResource { get; set; }

        /// <summary>
        /// Gets or sets the spell vamp.
        /// </summary>
        [JsonProperty("spellVamp")]
        public double SpellVamp { get; set; }

        /// <summary>
        /// Gets or sets the tenacity.
        /// </summary>
        [JsonProperty("tenacity")]
        public double Tenacity { get; set; }
    }
}