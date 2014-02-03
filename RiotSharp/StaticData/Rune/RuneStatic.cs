using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RiotSharp
{
    public class RuneStatic
    {
        [JsonProperty("colloq")]
        public string Colloq { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("image")]
        public ImageStatic Image { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("plaintext")]
        public string PlainText { get; set; }

        [JsonProperty("rune")]
        public RuneTypeStatic RuneType { get; set; }

        [JsonProperty("stats")]
        public StatsStatic Stats { get; set; }

        [JsonProperty("tags")]
        public List<string> Tags { get; set; }
    }
}
