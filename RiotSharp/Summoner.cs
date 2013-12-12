using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace RiotSharp
{
    public class Summoner
    {
        private const String RootUrl = "/api/lol/{0}/v1.1/summoner";
        private const String MasteriesUrl = "/{0}/masteries";
        private const String RunesUrl = "/{0}/runes";

        private RiotApi riotApi;
        private IRequester requester;

        public Summoner(RiotApi api, JToken summoner, IRequester requester)
        {
            riotApi = api;
            this.requester = requester;
            JsonConvert.PopulateObject(summoner.ToString(), this, riotApi.JsonSerializerSettings);
        }

        [JsonProperty("id")]
        public long Id { get; set; }
        [JsonProperty("name")]
        public String Name { get; set; }
        [JsonProperty("profileIconId")]
        public int ProfileIconId { get; set; }
        [JsonProperty("revisionDate")]
        public long RevisionDate { get; set; }
        [JsonProperty("revisionDateStr")]
        public String RevisionDateString { get; set; }
        [JsonProperty("summonerLevel")]
        public long Level { get; set; }
    }
}
