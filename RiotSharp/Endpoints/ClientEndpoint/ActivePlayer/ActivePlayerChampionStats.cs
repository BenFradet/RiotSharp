using Newtonsoft.Json;
using RiotSharp.Endpoints.ClientEndpoint.Enums;

namespace RiotSharp.Endpoints.ClientEndpoint.ActivePlayer
{
    public class ActivePlayerChampionStats
    {
        internal ActivePlayerChampionStats() { }

        [JsonProperty("abilityPower")]
        public double AbilityPower { get; set; }

        [JsonProperty("armor")]
        public double Armor { get; set; }

        [JsonProperty("armorPenetrationFlat")]
        public double ArmorPenetrationFlat { get; set; }

        [JsonProperty("armorPenetrationPercent")]
        public double ArmorPenetrationPercent { get; set; }

        [JsonProperty("attackDamage")]
        public double AttackDamage { get; set; }

        [JsonProperty("attackRange")]
        public double AttackRange { get; set; }

        [JsonProperty("attackSpeed")]
        public double AttackSpeed { get; set; }

        [JsonProperty("bonusArmorPenetrationPercent")]
        public double BonusArmorPenetrationPercent { get; set; }

        [JsonProperty("bonusMagicPenetrationPercent")]
        public double BonusMagicPenetrationPercent { get; set; }

        [JsonProperty("cooldownReduction")]
        public double CooldownReduction { get; set; }

        [JsonProperty("critChance")]
        public double CriticalChance { get; set; }

        [JsonProperty("critDamage")]
        public double CriticalDamage { get; set; }

        [JsonProperty("currentHealth")]
        public double CurrentHealth { get; set; }

        [JsonProperty("healthRegenRate")]
        public double HealthRegenerationRate { get; set; }

        [JsonProperty("lifeSteal")]
        public double LifeSteal { get; set; }

        [JsonProperty("magicLethality")]
        public double MagicLethality { get; set; }

        [JsonProperty("magicPenetrationFlat")]
        public double MagicPenetrationFlat { get; set; }

        [JsonProperty("magicPenetrationPercent")]
        public double MagicPenetrationPercent { get; set; }

        [JsonProperty("magicResist")]
        public double MagicResistance { get; set; }

        [JsonProperty("maxHealth")]
        public double MaximumHealth { get; set; }

        [JsonProperty("moveSpeed")]
        public double MovementSpeed { get; set; }

        [JsonProperty("physicalLethality")]
        public double PhysicalLethality { get; set; }

        [JsonProperty("resourceMax")]
        public double ResourceMaximum { get; set; }

        [JsonProperty("resourceRegenRate")]
        public double ResourceRegenerationRate { get; set; }

        [JsonProperty("resourceType")]
        public ResourceType ResourceType { get; set; }

        [JsonProperty("resourceValue")]
        public double CurrentResource { get; set; }

        [JsonProperty("spellVamp")]
        public double SpellVamp { get; set; }

        [JsonProperty("tenacity")]
        public double Tenacity { get; set; }
    }
}