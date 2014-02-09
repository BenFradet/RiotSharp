using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RiotSharp
{
    /// <summary>
    /// Class representing a spell of a champion (Static API).
    /// </summary>
    public class SpellStatic
    {
        internal SpellStatic() { }

        /// <summary>
        /// List of the cooldowns for each level of the spell.
        /// </summary>
        [JsonProperty("cooldown")]
        public List<int> Cooldowns { get; set; }

        /// <summary>
        /// String representing the cooldowns for each level of the spell.
        /// </summary>
        [JsonProperty("cooldownBurn")]
        public string CooldownBurn { get; set; }

        /// <summary>
        /// List of the costs for each level of the spell.
        /// </summary>
        [JsonProperty("cost")]
        public List<int> Costs { get; set; }

        /// <summary>
        /// String representing the costs for each level of the spell.
        /// </summary>
        [JsonProperty("costBurn")]
        public string CostBurn { get; set; }

        /// <summary>
        /// Type of cost (mana, energy, percentage of current health, etc).
        /// </summary>
        [JsonProperty("costType")]
        public string CostType { get; set; }

        /// <summary>
        /// Description of the spell.
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// Effects of the spell (damage, etc).
        /// </summary>
        [JsonProperty("effect")]
        public List<object> Effects { get; set; }

        /// <summary>
        /// String representing the effects of the spell.
        /// </summary>
        [JsonProperty("effectBurn")]
        public List<string> EffectBurns { get; set; }

        /// <summary>
        /// String identifying a spell (champion's name + key to activate the spell, example: "AatroxQ".
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Image of the spell.
        /// </summary>
        [JsonProperty("image")]
        public ImageStatic Image { get; set; }

        /// <summary>
        /// Tooltip when leveling up this spell.
        /// </summary>
        [JsonProperty("levelTip")]
        public LevelTipStatic LevelTip { get; set; }

        /// <summary>
        /// Maximum rank of this spell.
        /// </summary>
        [JsonProperty("maxRank")]
        public int MaxRank { get; set; }

        /// <summary>
        /// Name of this spell.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Apparently a list of the range for each level of the spell.
        /// </summary>
        [JsonProperty("range")]
        public object Range { get; set; }

        /// <summary>
        /// String representing the range for each level of the spell.
        /// </summary>
        [JsonProperty("rangeBurn")]
        public string RangeBurn { get; set; }

        /// <summary>
        /// String representing the cost for the champion when using this spell (example: "{{ e3 }}% of Current Health".
        /// </summary>
        [JsonProperty("resource")]
        public string Resource { get; set; }

        /// <summary>
        /// Tooltip for this spell.
        /// </summary>
        [JsonProperty("tooltip")]
        public string Tooltip { get; set; }

        /// <summary>
        /// Various effects of this spell.
        /// </summary>
        [JsonProperty("vars")]
        public List<object> Vars { get; set; }
    }
}
