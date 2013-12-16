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
        public RunePage(JToken json)
        {
            JsonConvert.PopulateObject(json.ToString(), this, RiotApi.JsonSerializerSettings);
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
