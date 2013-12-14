using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace RiotSharp
{
    public class MasteryPage : Thing
    {
        public MasteryPage(JToken json)
        {
            JsonConvert.PopulateObject(json.ToString(), this, RiotApi.JsonSerializerSettings);
        }

        [JsonProperty("current")]
        public bool Current { get; set; }
        [JsonProperty("name")]
        public String Name { get; set; }
        [JsonProperty("talents")]
        public List<Talent> Talents { get; set; }
    }
}
