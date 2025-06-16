using System.Text.Json.Serialization;
using RiotSharpNET8.Endpoints.StaticDataEndpoint.Champion;

namespace RiotSharpNET8.Endpoints.StaticDataEndpoint.SummonerSpell
{
    /// <summary>
    /// Class representing a summoner spell (Static API).
    /// </summary>
    public class SummonerSpellStatic
    {
        internal SummonerSpellStatic() { }

        /// <summary>
        /// List of cooldowns for this spell.
        /// </summary>
        [JsonPropertyName("cooldown")]
        public List<float> Cooldowns { get; set; }

        /// <summary>
        /// String of cooldowns for this spell.
        /// </summary>
        [JsonPropertyName("cooldownBurn")]
        public string CooldownBurn { get; set; }

        /// <summary>
        /// List of costs for this spell.
        /// </summary>
        [JsonPropertyName("cost")]
        public List<int> Costs { get; set; }

        /// <summary>
        /// String of costs for this spell.
        /// </summary>
        [JsonPropertyName("costBurn")]
        public string CostBurn { get; set; }

        /// <summary>
        /// Cost type (NoCost).
        /// </summary>
        [JsonPropertyName("costType")]
        public string CostType { get; set; }

        /// <summary>
        /// Spell's description.
        /// </summary>
        [JsonPropertyName("description")]
        public string Description { get; set; }

        /// <summary>
        /// List of object representing the effects of this spell.
        /// </summary>
        [JsonPropertyName("effect")]
        public List<List<double>> Effects { get; set; }

        /// <summary>
        /// String representing the effects of this spell.
        /// </summary>
        [JsonPropertyName("effectBurn")]
        public List<string> EffectBurns { get; set; }

        /// <summary>
        /// Spell's id.
        /// Taken from key field to remain consistent with the old static data api.
        /// </summary>
        [JsonPropertyName("key")]
        public int Id { get; set; }

        /// <summary>
        /// Spell's image.
        /// </summary>
        [JsonPropertyName("image")]
        public ImageStatic Image { get; set; }

        /// <summary>
        /// Spell's key.
        /// Taken from id field to remain consistent with the old static data api.
        /// </summary>
        [JsonPropertyName("id")]
        public string Key { get; set; }

        /// <summary>
        /// Tooltip when leveling up this spell.
        /// </summary>
        [JsonPropertyName("leveltip")]
        public LevelTipStatic LevelTip { get; set; }

        /// <summary>
        /// Spell's maxrank (1).
        /// </summary>
        [JsonPropertyName("maxrank")]
        public int MaxRank { get; set; }

        /// <summary>
        /// Modes this spell are available in.
        /// </summary>
        [JsonPropertyName("modes")]
        public List<string> Modes { get; set; }

        /// <summary>
        /// Spell's name.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Spell's range. This field is either a List of Integer or the String 'self' for spells that target one's own champion.
        /// </summary>
        [JsonPropertyName("range")]
        public object Range { get; set; }

        /// <summary>
        /// Spell's range as a string.
        /// </summary>
        [JsonPropertyName("rangeBurn")]
        public string RangeBurn { get; set; }

        /// <summary>
        /// Resource needed for this spell (NoCost).
        /// </summary>
        [JsonPropertyName("resource")]
        public string Resource { get; set; }

        /// <summary>
        /// Sanitized (HTML stripped) description of the spell.
        /// </summary>
        [JsonPropertyName("sanitizedDescription")]
        public string SanitizedDescription { get; set; }

        /// <summary>
        /// Sanitized (HTML stripped) tooltip of the spell.
        /// </summary>
        [JsonPropertyName("sanitizedTooltip")]
        public string SanitizedTooltip { get; set; }

        /// <summary>
        /// Summoner level required to use this spell.
        /// </summary>
        [JsonPropertyName("summonerLevel")]
        public int SummonerLevel { get; set; }

        /// <summary>
        /// Spell's tooltip.
        /// </summary>
        [JsonPropertyName("tooltip")]
        public string Tooltip { get; set; }

        /// <summary>
        /// Various information about this spell.
        /// </summary>
        [JsonPropertyName("vars")]
        public List<SpellVarsStatic> Vars { get; set; }
    }
}
