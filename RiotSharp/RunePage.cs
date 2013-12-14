using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Converters;

namespace RiotSharp
{
    public class RunePage : Thing
    {
        private RiotApi api;

        public RunePage(RiotApi api, JToken json)
        {
            this.api = api;
            JsonConvert.PopulateObject(json.ToString(), this, api.JsonSerializerSettings);
        }

        [JsonProperty("current")]
        public bool Current { get; set; }
        [JsonProperty("id")]
        public long Id { get; set; }
        [JsonProperty("name")]
        public String Name { get; set; }
        [JsonProperty("slots")]
        public List<RuneSlot> Slots { get; set; }
    }
}
