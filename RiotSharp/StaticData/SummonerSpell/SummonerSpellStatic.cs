using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RiotSharp
{
    public class SummonerSpellStatic
    {
        [JsonProperty("cooldown")]
        public List<int> Cooldowns { get; set; }

        [JsonProperty("cooldownBurn")]
        public string CooldownBurn { get; set; }

        [JsonProperty("cost")]
        public List<int> Costs { get; set; }

        [JsonProperty("costBurn")]
        public string CostBurn { get; set; }

        [JsonProperty("costType")]
        public string CostType { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("effect")]
        public List<object> Effects { get; set; }

        [JsonProperty("effectBurn")]
        public List<string> EffectBurns { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("image")]
        public ImageStatic Image { get; set; }

        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("maxrank")]
        public int MaxRank { get; set; }

        [JsonProperty("modes")]
        public List<string> Modes { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("range")]
        public object Range { get; set; }

        [JsonProperty("rangeBurn")]
        public string RangeBurn { get; set; }

        [JsonProperty("resource")]
        public string Resource { get; set; }

        [JsonProperty("summonerLevel")]
        public int SummonerLevel { get; set; }

        [JsonProperty("tooltip")]
        public string Tooltip { get; set; }

        [JsonProperty("vars")]
        public List<SummonerSpellVarStatic> Vars { get; set; }
    }
}
