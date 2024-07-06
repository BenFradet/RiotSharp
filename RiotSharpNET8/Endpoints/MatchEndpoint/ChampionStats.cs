using System.Text.Json.Serialization;

namespace RiotSharpNET8.Endpoints.MatchEndpoint
{
    public class ChampionStats
    {
        internal ChampionStats() { }

        [JsonPropertyName("abilityHaste")]
        public int AbilityHaste { get; set; }


        [JsonPropertyName("abilityPower")]
        public int AbilityPower { get; set; }


        [JsonPropertyName("armor")]
        public int Armor { get; set; }


        [JsonPropertyName("armorPen")]
        public int ArmorPen { get; set; }


        [JsonPropertyName("armorPenPercent")]
        public int ArmorPenPercent { get; set; }


        [JsonPropertyName("attackDamage")]
        public int AttackDamage { get; set; }


        [JsonPropertyName("attackSpeed")]
        public int AttackSpeed { get; set; }


        [JsonPropertyName("bonusArmorPenPercent")]
        public int BonusArmorPenPercent { get; set; }


        [JsonPropertyName("bonusMagicPenPercent")]
        public int BonusMagicPenPercent { get; set; }


        [JsonPropertyName("ccReduction")]
        public int CcReduction { get; set; }


        [JsonPropertyName("cooldownReduction")]
        public int CooldownReduction { get; set; }


        [JsonPropertyName("health")]
        public int Health { get; set; }


        [JsonPropertyName("healthMax")]
        public int HealthMax { get; set; }


        [JsonPropertyName("healthRegen")]
        public int HealthRegen { get; set; }


        [JsonPropertyName("lifesteal")]
        public int Lifesteal { get; set; }


        [JsonPropertyName("magicPen")]
        public int MagicPen { get; set; }


        [JsonPropertyName("magicPenPercent")]
        public int MagicPenPercent { get; set; }


        [JsonPropertyName("magicResist")]
        public int MagicResist { get; set; }


        [JsonPropertyName("movementSpeed")]
        public int MovementSpeed { get; set; }


        [JsonPropertyName("omnivamp")]
        public int Omnivamp { get; set; }


        [JsonPropertyName("physicalVamp")]
        public int PhysicalVamp { get; set; }


        [JsonPropertyName("power")]
        public int Power { get; set; }


        [JsonPropertyName("powerMax")]
        public int PowerMax { get; set; }


        [JsonPropertyName("powerRegen")]
        public int PowerRegen { get; set; }


        [JsonPropertyName("spellVamp")]
        public int SpellVamp { get; set; }
    }
}
