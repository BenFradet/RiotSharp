using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RiotSharp
{
    public class ChampionStatsStatic
    {
        [JsonProperty("armor")]
        public double Armor { get; set; }

        [JsonProperty("armorperlevel")]
        public double ArmorPerLevel { get; set; }

        [JsonProperty("attackdamage")]
        public double AttackDamage { get; set; }

        [JsonProperty("attackdamageperlevel")]
        public double AttackDamagePerLevel { get; set; }

        [JsonProperty("attackrange")]
        public double AttackRange { get; set; }

        [JsonProperty("attackspeedoffset")]
        public double AttackSpeedOffset { get; set; }

        [JsonProperty("attackspeedperlevel")]
        public double AttackSpeedPerLevel { get; set; }

        [JsonProperty("crit")]
        public double Crit { get; set; }

        [JsonProperty("critperlevel")]
        public double CritPerLevel { get; set; }

        [JsonProperty("hp")]
        public double Hp { get; set; }

        [JsonProperty("hpperlevel")]
        public double HpPerLevel { get; set; }

        [JsonProperty("hpregen")]
        public double HpRegen { get; set; }

        [JsonProperty("hpregenperlevel")]
        public double HpRegenPerLevel { get; set; }

        [JsonProperty("movespeed")]
        public double MoveSpeed { get; set; }

        [JsonProperty("mp")]
        public double Mp { get; set; }

        [JsonProperty("mpperlevel")]
        public double MpPerLevel { get; set; }

        [JsonProperty("mpregen")]
        public double MpRegen { get; set; }

        [JsonProperty("mpregenperlevel")]
        public double MpRegenPerLevel { get; set; }

        [JsonProperty("spellblock")]
        public double SpellBlock { get; set; }

        [JsonProperty("spellblockperlevel")]
        public double SpellBlockPerLevel { get; set; }
    }
}
