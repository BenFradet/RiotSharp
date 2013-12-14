using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace RiotSharp
{
    public class SummonerBase : Thing
    {
        protected RiotApi api;
        protected IRequester requester;
        protected Region region;

        public SummonerBase(RiotApi api, JToken json, IRequester requester, Region region)
        {
            this.api = api;
            this.requester = requester;
            this.region = region;
            JsonConvert.PopulateObject(json.ToString(), this, RiotApi.JsonSerializerSettings);
        }

        [JsonProperty("id")]
        public long Id { get; set; }
        [JsonProperty("name")]
        public String Name { get; set; }
    }
}
