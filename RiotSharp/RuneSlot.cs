using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace RiotSharp
{
    public class RuneSlot : Thing
    {
        private RiotApi api;

        public RuneSlot() { }

        public RuneSlot(RiotApi api, JToken json)
        {
            this.api = api;
            JsonConvert.PopulateObject(json.ToString(), this, api.JsonSerializerSettings);
        }

        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("rune")]
        [JsonConverter(typeof(RuneConverter))]
        public Rune Rune { get; set; }
    }
}
