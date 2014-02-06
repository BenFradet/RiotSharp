using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RiotSharp
{
    /// <summary>
    /// Class representing an item (Static API).
    /// </summary>
    public class ItemStatic
    {
        /// <summary>
        /// Equals ";".
        /// </summary>
        [JsonProperty("colloq")]
        public string Colloq { get; set; }

        /// <summary>
        /// Description of this item.
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// Information about the value of this item.
        /// </summary>
        [JsonProperty("gold")]
        public GoldStatic Gold { get; set; }

        /// <summary>
        /// This item's group.
        /// </summary>
        [JsonProperty("group")]
        public string Group { get; set; }

        /// <summary>
        /// This item's image.
        /// </summary>
        [JsonProperty("image")]
        public ImageStatic Image { get; set; }

        /// <summary>
        /// List of items' ids this item builds into.
        /// </summary>
        [JsonProperty("into")]
        public List<int> Into { get; set; }

        /// <summary>
        /// Item's name.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Text describing this item.
        /// </summary>
        [JsonProperty("plaintext")]
        public string PlainText { get; set; }

        /// <summary>
        /// This item's stats.
        /// </summary>
        [JsonProperty("stats")]
        public Dictionary<string, double> Stats { get; set; }

        /// <summary>
        /// This item's tags.
        /// </summary>
        [JsonProperty("tags")]
        public List<string> Tags { get; set; }
    }
}
