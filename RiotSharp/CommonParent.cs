using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace RiotSharp
{
    public class CommonParent
    {
        protected RiotApi riotApi;
        protected IRequester requester;

        public CommonParent(RiotApi api, JToken summoner, IRequester requester)
        {
            riotApi = api;
            this.requester = requester;
            JsonConvert.PopulateObject(summoner.ToString(), this, riotApi.JsonSerializerSettings);
        }

        public static CommonParent Parse(RiotApi api, JToken json, IRequester requester)
        {
            return new CommonParent(api, json, requester);
        }

        [JsonProperty("id")]
        public long Id { get; set; }
        [JsonProperty("name")]
        public String Name { get; set; }
    }
}
