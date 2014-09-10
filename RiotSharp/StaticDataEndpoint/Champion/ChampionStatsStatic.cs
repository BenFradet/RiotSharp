using System;
using Newtonsoft.Json;

namespace RiotSharp.StaticDataEndpoint
{
    /// <summary>
    /// A few statistics of a champion (Static API).
    /// </summary>
    [Serializable]
    public class ChampionStatsStatic
    {
        internal ChampionStatsStatic() { }

        /// <summary>
        /// Base armor.
        /// </summary>
        [JsonProperty("armor")]
        public double Armor { get; set; }

        /// <summary>
        /// Armor won per level.
        /// </summary>
        [JsonProperty("armorperlevel")]
        public double ArmorPerLevel { get; set; }

        /// <summary>
        /// Base attack damage.
        /// </summary>
        [JsonProperty("attackdamage")]
        public double AttackDamage { get; set; }

        /// <summary>
        /// Attack damage won per level.
        /// </summary>
        [JsonProperty("attackdamageperlevel")]
        public double AttackDamagePerLevel { get; set; }

        /// <summary>
        /// Base attack range.
        /// </summary>
        [JsonProperty("attackrange")]
        public double AttackRange { get; set; }

        /// <summary>
        /// Base attack speed.
        /// </summary>
        [JsonProperty("attackspeedoffset")]
        public double AttackSpeedOffset { get; set; }

        /// <summary>
        /// Attack speed won per level.
        /// </summary>
        [JsonProperty("attackspeedperlevel")]
        public double AttackSpeedPerLevel { get; set; }

        /// <summary>
        /// Base crit percentage.
        /// </summary>
        [JsonProperty("crit")]
        public double Crit { get; set; }

        /// <summary>
        /// Crit percentage won per level.
        /// </summary>
        [JsonProperty("critperlevel")]
        public double CritPerLevel { get; set; }

        /// <summary>
        /// Base hit points.
        /// </summary>
        [JsonProperty("hp")]
        public double Hp { get; set; }

        /// <summary>
        /// Hit points won per level.
        /// </summary>
        [JsonProperty("hpperlevel")]
        public double HpPerLevel { get; set; }

        /// <summary>
        /// Base hit point regeneration.
        /// </summary>
        [JsonProperty("hpregen")]
        public double HpRegen { get; set; }

        /// <summary>
        /// Hit points regeneration per level.
        /// </summary>
        [JsonProperty("hpregenperlevel")]
        public double HpRegenPerLevel { get; set; }

        /// <summary>
        /// Base move speed.
        /// </summary>
        [JsonProperty("movespeed")]
        public double MoveSpeed { get; set; }

        /// <summary>
        /// Base mana points.
        /// </summary>
        [JsonProperty("mp")]
        public double Mp { get; set; }

        /// <summary>
        /// Mana points won per level.
        /// </summary>
        [JsonProperty("mpperlevel")]
        public double MpPerLevel { get; set; }

        /// <summary>
        /// Base mana point regeneration.
        /// </summary>
        [JsonProperty("mpregen")]
        public double MpRegen { get; set; }

        /// <summary>
        /// Mana point regeneration won per level.
        /// </summary>
        [JsonProperty("mpregenperlevel")]
        public double MpRegenPerLevel { get; set; }

        /// <summary>
        /// Base spell block.
        /// </summary>
        [JsonProperty("spellblock")]
        public double SpellBlock { get; set; }

        /// <summary>
        /// Spell block won per level.
        /// </summary>
        [JsonProperty("spellblockperlevel")]
        public double SpellBlockPerLevel { get; set; }
    }
}
