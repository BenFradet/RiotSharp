using System.Text.Json.Serialization;

namespace RiotSharpNET8.Endpoints.StaticDataEndpoint.Item
{
    /// <summary>
    /// Class representing an item (Static API).
    /// </summary>
    public class ItemStatic
    {
        internal ItemStatic() { }

        /// <summary>
        /// Equals ";".
        /// </summary>
        [JsonPropertyName("colloq")]
        public string Colloq { get; set; }

        /// <summary>
        /// Whether the object is to be consumed on full or not.
        /// </summary>
        [JsonPropertyName("consumeOnFull")]
        public bool ConsumOnFull { get; set; }

        /// <summary>
        /// Whether the object is to be consumed or not.
        /// </summary>
        [JsonPropertyName("consumed")]
        public bool Consumed { get; set; }

        /// <summary>
        /// Depth.
        /// </summary>
        [JsonPropertyName("depth")]
        public int Depth { get; set; }

        /// <summary>
        /// Description.
        /// </summary>
        [JsonPropertyName("description")]
        public string Description { get; set; }

        /// <summary>
        /// List of object' ids which build into this one.
        /// </summary>
        [JsonPropertyName("from")]
        public List<string> From { get; set; }

        /// <summary>
        /// Value information about this item.
        /// </summary>
        [JsonPropertyName("gold")]
        public GoldStatic Gold { get; set; }

        /// <summary>
        /// This object's group.
        /// </summary>
        [JsonPropertyName("group")]
        public string Group { get; set; }

        /// <summary>
        /// Hide from all.
        /// </summary>
        [JsonPropertyName("hideFromAll")]
        public bool HideFromAll { get; set; }

        /// <summary>
        /// Item's id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// This object's image.
        /// </summary>
        [JsonPropertyName("image")]
        public ImageStatic Image { get; set; }

        /// <summary>
        /// Whether this object is in the store or not.
        /// </summary>
        [JsonPropertyName("inStore")]
        public bool InStore { get; set; }

        /// <summary>
        /// List of object' ids this item builds into.
        /// </summary>
        [JsonPropertyName("into")]
        public List<int> Into { get; set; }

        /// <summary>
        /// Maps describing on which league of legends map this object is valid.
        /// </summary>
        [JsonPropertyName("maps")]
        public Dictionary<string, bool> Maps { get; set; }

        /// <summary>
        /// Name of the object.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Text describing this item.
        /// </summary>
        [JsonPropertyName("plaintext")]
        public string PlainText { get; set; }

        /// <summary>
        /// Required champion.
        /// </summary>
        [JsonPropertyName("requiredChampion")]
        public string RequiredChampion { get; set; }

        /// <summary>
        /// Additional information if the object is a rune.
        /// </summary>
        [JsonPropertyName("rune")]
        public MetadataStatic Metadata { get; set; }

        /// <summary>
        /// Sanitized (HTML stripped) description of the item.
        /// </summary>
        [JsonPropertyName("sanitizedDescription")]
        public string SanitizedDescription { get; set; }

        /// <summary>
        /// Id of the special recipe if there is one.
        /// </summary>
        [JsonPropertyName("specialRecipe")]
        public int SpecialRecipe { get; set; }

        /// <summary>
        /// Stacks.
        /// </summary>
        [JsonPropertyName("stacks")]
        public int Stacks { get; set; }

        /// <summary>
        /// Possible stats of this object.
        /// </summary>
        [JsonPropertyName("stats")]
        public StatsStatic Stats { get; set; }

        /// <summary>
        /// List of possible tags (defense, perlevel, etc).
        /// </summary>
        [JsonPropertyName("tags")]
        public List<string> Tags { get; set; }
    }
}
