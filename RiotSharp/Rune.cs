using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace RiotSharp
{
    public class Rune : Thing
    {
        private RiotApi api;

        public Rune(RiotApi api, JToken json)
        {
            this.api = api;
            JsonConvert.PopulateObject(json.ToString(), this, api.JsonSerializerSettings);
        }

        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("description")]
        public String Description { get; set; }
        [JsonProperty("name")]
        public String Name { get; set; }
        [JsonProperty("tier")]
        public int Tier { get; set; }
    }
}
