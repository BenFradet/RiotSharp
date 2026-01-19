using System.Text.Json.Serialization;

namespace RiotSharp.LeagueOfLegends.Endpoints.MatchEndpoint.Models
{
    /// <summary>
    /// Champion statistics at a specific frame.
    /// </summary>
    public class ChampionStats
    {
        [JsonPropertyName("abilityHaste")]
        public required int AbilityHaste { get; set; }

        [JsonPropertyName("abilityPower")]
        public required int AbilityPower { get; set; }

        [JsonPropertyName("armor")]
        public required int Armor { get; set; }

        [JsonPropertyName("armorPen")]
        public required int ArmorPen { get; set; }

        [JsonPropertyName("armorPenPercent")]
        public required int ArmorPenPercent { get; set; }

        [JsonPropertyName("attackDamage")]
        public required int AttackDamage { get; set; }

        [JsonPropertyName("attackSpeed")]
        public required int AttackSpeed { get; set; }

        [JsonPropertyName("bonusArmorPenPercent")]
        public required int BonusArmorPenPercent { get; set; }

        [JsonPropertyName("bonusMagicPenPercent")]
        public required int BonusMagicPenPercent { get; set; }

        [JsonPropertyName("ccReduction")]
        public required int CcReduction { get; set; }

        [JsonPropertyName("cooldownReduction")]
        public required int CooldownReduction { get; set; }

        [JsonPropertyName("health")]
        public required int Health { get; set; }

        [JsonPropertyName("healthMax")]
        public required int HealthMax { get; set; }

        [JsonPropertyName("healthRegen")]
        public required int HealthRegen { get; set; }

        [JsonPropertyName("lifesteal")]
        public required int Lifesteal { get; set; }

        [JsonPropertyName("magicPen")]
        public required int MagicPen { get; set; }

        [JsonPropertyName("magicPenPercent")]
        public required int MagicPenPercent { get; set; }

        [JsonPropertyName("magicResist")]
        public required int MagicResist { get; set; }

        [JsonPropertyName("movementSpeed")]
        public required int MovementSpeed { get; set; }

        [JsonPropertyName("omnivamp")]
        public required int Omnivamp { get; set; }

        [JsonPropertyName("physicalVamp")]
        public required int PhysicalVamp { get; set; }

        [JsonPropertyName("power")]
        public required int Power { get; set; }

        [JsonPropertyName("powerMax")]
        public required int PowerMax { get; set; }

        [JsonPropertyName("powerRegen")]
        public required int PowerRegen { get; set; }

        [JsonPropertyName("spellVamp")]
        public required int SpellVamp { get; set; }
    }
}
