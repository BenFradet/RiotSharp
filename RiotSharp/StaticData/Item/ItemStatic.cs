using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RiotSharp
{
    public class ItemStatic
    {
        [JsonProperty("colloq")]
        public string Colloq { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("gold")]
        public GoldStatic Gold { get; set; }

        [JsonProperty("group")]
        public string Group { get; set; }

        [JsonProperty("image")]
        public ImageStatic Image { get; set; }

        [JsonProperty("into")]
        public List<string> Into { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("plaintext")]
        public string PlainText { get; set; }

        [JsonProperty("stats")]
        public Dictionary<string, ItemStatsStatic> Stats { get; set; }

        [JsonProperty("tags")]
        public List<string> Tags { get; set; }
    }
}
