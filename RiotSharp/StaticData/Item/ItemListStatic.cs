using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RiotSharp
{
    public class ItemListStatic
    {
        [JsonProperty("basic")]
        public BasicDataStatic BasicData { get; set; }

        [JsonProperty("data")]
        public Dictionary<int, ItemStatic> Items { get; set; }

        [JsonProperty("groups")]
        public List<GroupStatic> Groups { get; set; }

        [JsonProperty("tree")]
        public List<ItemTreeStatic> Trees { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }
    }
}
