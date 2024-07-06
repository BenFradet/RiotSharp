using System.Text.Json.Serialization;

namespace RiotSharpNET8.Endpoints.StaticDataEndpoint.Champion
{
    /// <summary>
    /// A few statistics of a champion (Static API).
    /// </summary>
    public class ChampionStatsStatic
    {
        /// <summary>
        /// Base armor.
        /// </summary>
        [JsonPropertyName("armor")]
        public double Armor { get; set; }

        /// <summary>
        /// Armor won per level.
        /// </summary>
        [JsonPropertyName("armorperlevel")]
        public double ArmorPerLevel { get; set; }

        /// <summary>
        /// Base attack damage.
        /// </summary>
        [JsonPropertyName("attackdamage")]
        public double AttackDamage { get; set; }

        /// <summary>
        /// Attack damage won per level.
        /// </summary>
        [JsonPropertyName("attackdamageperlevel")]
        public double AttackDamagePerLevel { get; set; }

        /// <summary>
        /// Base attack range.
        /// </summary>
        [JsonPropertyName("attackrange")]
        public double AttackRange { get; set; }

        /// <summary>
        /// Base attack speed.
        /// </summary>
        [JsonPropertyName("attackspeedoffset")]
        public double AttackSpeedOffset { get; set; }

        /// <summary>
        /// Attack speed won per level.
        /// </summary>
        [JsonPropertyName("attackspeedperlevel")]
        public double AttackSpeedPerLevel { get; set; }

        /// <summary>
        /// Base crit percentage.
        /// </summary>
        [JsonPropertyName("crit")]
        public double Crit { get; set; }

        /// <summary>
        /// Crit percentage won per level.
        /// </summary>
        [JsonPropertyName("critperlevel")]
        public double CritPerLevel { get; set; }

        /// <summary>
        /// Base hit points.
        /// </summary>
        [JsonPropertyName("hp")]
        public double Hp { get; set; }

        /// <summary>
        /// Hit points won per level.
        /// </summary>
        [JsonPropertyName("hpperlevel")]
        public double HpPerLevel { get; set; }

        /// <summary>
        /// Base hit point regeneration.
        /// </summary>
        [JsonPropertyName("hpregen")]
        public double HpRegen { get; set; }

        /// <summary>
        /// Hit points regeneration per level.
        /// </summary>
        [JsonPropertyName("hpregenperlevel")]
        public double HpRegenPerLevel { get; set; }

        /// <summary>
        /// Base move speed.
        /// </summary>
        [JsonPropertyName("movespeed")]
        public double MoveSpeed { get; set; }

        /// <summary>
        /// Base mana points.
        /// </summary>
        [JsonPropertyName("mp")]
        public double Mp { get; set; }

        /// <summary>
        /// Mana points won per level.
        /// </summary>
        [JsonPropertyName("mpperlevel")]
        public double MpPerLevel { get; set; }

        /// <summary>
        /// Base mana point regeneration.
        /// </summary>
        [JsonPropertyName("mpregen")]
        public double MpRegen { get; set; }

        /// <summary>
        /// Mana point regeneration won per level.
        /// </summary>
        [JsonPropertyName("mpregenperlevel")]
        public double MpRegenPerLevel { get; set; }

        /// <summary>
        /// Base spell block.
        /// </summary>
        [JsonPropertyName("spellblock")]
        public double SpellBlock { get; set; }

        /// <summary>
        /// Spell block won per level.
        /// </summary>
        [JsonPropertyName("spellblockperlevel")]
        public double SpellBlockPerLevel { get; set; }
    }
}
