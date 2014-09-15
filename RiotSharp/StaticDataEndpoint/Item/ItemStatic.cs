using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace RiotSharp.StaticDataEndpoint
{
    /// <summary>
    /// Class representing an item (Static API).
    /// </summary>
    [Serializable]
    public class ItemStatic
    {
        internal ItemStatic() { }

        /// <summary>
        /// Equals ";".
        /// </summary>
        [JsonProperty("colloq")]
        public string Colloq { get; set; }

        /// <summary>
        /// Whether the object is to be consumed on full or not.
        /// </summary>
        [JsonProperty("consumeOnFull")]
        public bool ConsumOnFull { get; set; }

        /// <summary>
        /// Whether the object is to be consumed or not.
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
        /// List of object' ids which build into this one.
        /// </summary>
        [JsonProperty("from")]
        public List<string> From { get; set; }

        /// <summary>
        /// Value information about this item.
        /// </summary>
        [JsonProperty("gold")]
        public GoldStatic Gold { get; set; }

        /// <summary>
        /// This object's group.
        /// </summary>
        [JsonProperty("group")]
        public string Group { get; set; }

        /// <summary>
        /// Hide from all.
        /// </summary>
        [JsonProperty("hideFromAll")]
        public bool HideFromAll { get; set; }

        /// <summary>
        /// Item's id.
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// This object's image.
        /// </summary>
        [JsonProperty("image")]
        public ImageStatic Image { get; set; }

        /// <summary>
        /// Whether this object is in the store or not.
        /// </summary>
        [JsonProperty("inStore")]
        public bool InStore { get; set; }

        /// <summary>
        /// List of object' ids this item builds into.
        /// </summary>
        [JsonProperty("into")]
        public List<int> Into { get; set; }

        /// <summary>
        /// Maps describing on which league of legends map this object is valid.
        /// </summary>
        [JsonProperty("maps")]
        public Dictionary<string, bool> Maps { get; set; }

        /// <summary>
        /// Name of the object.
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
        /// Additional information if the object is a rune.
        /// </summary>
        [JsonProperty("rune")]
        public MetadataStatic Metadata { get; set; }

        /// <summary>
        /// Sanitized (HTML stripped) description of the item.
        /// </summary>
        [JsonProperty("sanitizedDescription")]
        public string SanitizedDescription { get; set; }

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
        /// Possible stats of this object.
        /// </summary>
        [JsonProperty("stats")]
        public StatsStatic Stats { get; set; }

        /// <summary>
        /// List of possible tags (defense, perlevel, etc).
        /// </summary>
        [JsonProperty("tags")]
        public List<string> Tags { get; set; }
    }
}
