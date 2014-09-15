using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace RiotSharp.StaticDataEndpoint
{
    /// <summary>
    /// Class representing a summoner spell (Static API).
    /// </summary>
    [Serializable]
    public class SummonerSpellStatic
    {
        internal SummonerSpellStatic() { }

        /// <summary>
        /// List of cooldowns for this spell.
        /// </summary>
        [JsonProperty("cooldown")]
        public List<float> Cooldowns { get; set; }

        /// <summary>
        /// String of cooldowns for this spell.
        /// </summary>
        [JsonProperty("cooldownBurn")]
        public string CooldownBurn { get; set; }

        /// <summary>
        /// List of costs for this spell.
        /// </summary>
        [JsonProperty("cost")]
        public List<int> Costs { get; set; }

        /// <summary>
        /// String of costs for this spell.
        /// </summary>
        [JsonProperty("costBurn")]
        public string CostBurn { get; set; }

        /// <summary>
        /// Cost type (NoCost).
        /// </summary>
        [JsonProperty("costType")]
        public string CostType { get; set; }

        /// <summary>
        /// Spell's description.
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// List of object representing the effects of this spell.
        /// </summary>
        [JsonProperty("effect")]
        public List<List<double>> Effects { get; set; }

        /// <summary>
        /// String representing the effects of this spell.
        /// </summary>
        [JsonProperty("effectBurn")]
        public List<string> EffectBurns { get; set; }

        /// <summary>
        /// Spell's id.
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// Spell's image.
        /// </summary>
        [JsonProperty("image")]
        public ImageStatic Image { get; set; }

        /// <summary>
        /// Spell's key.
        /// </summary>
        [JsonProperty("key")]
        public string Key { get; set; }

        /// <summary>
        /// Tooltip when leveling up this spell.
        /// </summary>
        [JsonProperty("leveltip")]
        public LevelTipStatic LevelTip { get; set; }

        /// <summary>
        /// Spell's maxrank (1).
        /// </summary>
        [JsonProperty("maxrank")]
        public int MaxRank { get; set; }

        /// <summary>
        /// Modes this spell are available in.
        /// </summary>
        [JsonProperty("modes")]
        public List<string> Modes { get; set; }

        /// <summary>
        /// Spell's name.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Spell's range. This field is either a List of Integer or the String 'self' for spells that target one's own champion.
        /// </summary>
        [JsonProperty("range")]
        public object Range { get; set; }

        /// <summary>
        /// Spell's range as a string.
        /// </summary>
        [JsonProperty("rangeBurn")]
        public string RangeBurn { get; set; }

        /// <summary>
        /// Resource needed for this spell (NoCost).
        /// </summary>
        [JsonProperty("resource")]
        public string Resource { get; set; }

        /// <summary>
        /// Sanitized (HTML stripped) description of the spell.
        /// </summary>
        [JsonProperty("sanitizedDescription")]
        public string SanitizedDescription { get; set; }

        /// <summary>
        /// Sanitized (HTML stripped) tooltip of the spell.
        /// </summary>
        [JsonProperty("sanitizedTooltip")]
        public string SanitizedTooltip { get; set; }

        /// <summary>
        /// Summoner level required to use this spell.
        /// </summary>
        [JsonProperty("summonerLevel")]
        public int SummonerLevel { get; set; }

        /// <summary>
        /// Spell's tooltip.
        /// </summary>
        [JsonProperty("tooltip")]
        public string Tooltip { get; set; }

        /// <summary>
        /// Various information about this spell.
        /// </summary>
        [JsonProperty("vars")]
        public List<SpellVarsStatic> Vars { get; set; }
    }
}
