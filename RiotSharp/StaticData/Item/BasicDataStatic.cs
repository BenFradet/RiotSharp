using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RiotSharp
{
    /// <summary>
    /// Class representing some information about the items retrieved (Static API).
    /// </summary>
    public class BasicDataStatic
    {
        /// <summary>
        /// Equals ";"
        /// </summary>
        [JsonProperty("colloq")]
        public string Colloq { get; set; }

        /// <summary>
        /// Whether the item is to be consumed on full or not.
        /// </summary>
        [JsonProperty("consumeOnFull")]
        public bool ConsumeOnFull { get; set; }

        /// <summary>
        /// Whether the item is to be consumed or not.
        /// </summary>
        [JsonProperty("consumed")]
        public bool Consumed { get; set; }

        /// <summary>
        /// Depth.
        /// </summary>
        [JsonProperty("depth")]
        public int Depth { get; set; }

        /// <summary>
        /// Description.
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// List of items' ids which build into this one.
        /// </summary>
        [JsonProperty("from")]
        public List<int> From { get; set; }

        /// <summary>
        /// Value information about this item.
        /// </summary>
        [JsonProperty("gold")]
        public GoldStatic Gold { get; set; }

        /// <summary>
        /// This item's group.
        /// </summary>
        [JsonProperty("group")]
        public string Group { get; set; }

        /// <summary>
        /// Hide from all.
        /// </summary>
        [JsonProperty("hideFromAll")]
        public bool HideFromAll { get; set; }

        /// <summary>
        /// Whether this item is in store or not.
        /// </summary>
        [JsonProperty("inStore")]
        public bool InStore { get; set; }

        /// <summary>
        /// List of items' ids this item builds into.
        /// </summary>
        [JsonProperty("into")]
        public List<int> Into { get; set; }

        /// <summary>
        /// Maps describing on which league of legends map this item is valid.
        /// </summary>
        [JsonProperty("maps")]
        public Dictionary<string, bool> Maps { get; set; }

        /// <summary>
        /// Name of the item.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Text describing this item.
        /// </summary>
        [JsonProperty("plaintext")]
        public string PlainText { get; set; }

        /// <summary>
        /// Required champion.
        /// </summary>
        [JsonProperty("requiredChampion")]
        public string RequiredChampion { get; set; }

        /// <summary>
        /// noidea.
        /// </summary>
        [JsonProperty("rune")]
        public ItemRuneStatic Rune { get; set; }

        /// <summary>
        /// Id of the special recipe if there is one.
        /// </summary>
        [JsonProperty("specialRecipe")]
        public int SpecialRecipe { get; set; }

        /// <summary>
        /// Stacks.
        /// </summary>
        [JsonProperty("stacks")]
        public int Stacks { get; set; }

        /// <summary>
        /// Possible stats of an item.
        /// </summary>
        [JsonProperty("stats")]
        public StatsStatic Stats { get; set; }

        /// <summary>
        /// List of possible tags.
        /// </summary>
        [JsonProperty("tags")]
        public List<string> Tags { get; set; }
    }
}
