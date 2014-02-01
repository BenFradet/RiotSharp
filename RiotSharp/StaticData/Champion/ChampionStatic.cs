using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RiotSharp
{
    public class ChampionStatic
    {
        [JsonProperty("allytips")]
        public List<string> AllyTips { get; set; }

        [JsonProperty("blurb")]
        public string Blurb { get; set; }

        [JsonProperty("enemytips")]
        public List<string> EnemyTips { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("image")]
        public ImageStatic Image { get; set; }

        [JsonProperty("info")]
        public InfoStatic Info { get; set; }

        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("lore")]
        public string Lore { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("partype")]
        public string Partype { get; set; }

        [JsonProperty("passive")]
        public PassiveStatic Passive { get; set; }

        [JsonProperty("recommended")]
        public List<RecommendedStatic> RecommendedItems { get; set; }

        [JsonProperty("skins")]
        public List<SkinStatic> Skins { get; set; }

        [JsonProperty("spells")]
        public List<SpellStatic> Spells { get; set; }

        [JsonProperty("stats")]
        public StatsStatic Stats { get; set; }

        [JsonProperty("tags")]
        public List<string> Tags { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }
    }
}
