using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace RiotSharp.Endpoints.MatchEndpoint
{
    public class ChampionStats
    {
        internal ChampionStats() { }

        [JsonProperty("abilityHaste")]
        public int AbilityHaste { get; set; }


        [JsonProperty("abilityPower")]
        public int AbilityPower { get; set; }


        [JsonProperty("armor")]
        public int Armor { get; set; }


        [JsonProperty("armorPen")]
        public int ArmorPen { get; set; }


        [JsonProperty("armorPenPercent")]
        public int ArmorPenPercent { get; set; }


        [JsonProperty("attackDamage")]
        public int AttackDamage { get; set; }


        [JsonProperty("attackSpeed")]
        public int AttackSpeed { get; set; }


        [JsonProperty("bonusArmorPenPercent")]
        public int BonusArmorPenPercent { get; set; }


        [JsonProperty("bonusMagicPenPercent")]
        public int BonusMagicPenPercent { get; set; }


        [JsonProperty("ccReduction")]
        public int CcReduction { get; set; }


        [JsonProperty("cooldownReduction")]
        public int CooldownReduction { get; set; }


        [JsonProperty("health")]
        public int Health { get; set; }


        [JsonProperty("healthMax")]
        public int HealthMax { get; set; }


        [JsonProperty("healthRegen")]
        public int HealthRegen { get; set; }


        [JsonProperty("lifesteal")]
        public int Lifesteal { get; set; }


        [JsonProperty("magicPen")]
        public int MagicPen { get; set; }


        [JsonProperty("magicPenPercent")]
        public int MagicPenPercent { get; set; }


        [JsonProperty("magicResist")]
        public int MagicResist { get; set; }


        [JsonProperty("movementSpeed")]
        public int MovementSpeed { get; set; }


        [JsonProperty("omnivamp")]
        public int Omnivamp { get; set; }


        [JsonProperty("physicalVamp")]
        public int PhysicalVamp { get; set; }


        [JsonProperty("power")]
        public int Power { get; set; }


        [JsonProperty("powerMax")]
        public int PowerMax { get; set; }


        [JsonProperty("powerRegen")]
        public int PowerRegen { get; set; }


        [JsonProperty("spellVamp")]
        public int SpellVamp { get; set; }
    }
}
