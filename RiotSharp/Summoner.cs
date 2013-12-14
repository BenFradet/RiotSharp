using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace RiotSharp
{
    public class Summoner : SummonerBase
    {
        private const String RootUrl = "/api/lol/{0}/v1.1/summoner";
        private const String MasteriesUrl = "/{0}/masteries";
        private const String RunesUrl = "/{0}/runes";

        [JsonIgnore]
        public Region Region { get; set; }

        public Summoner(RiotApi api, JToken summoner, IRequester requester, Region region)
            : base(api, summoner, requester, region) { }
        
        [JsonProperty("profileIconId")]
        public int ProfileIconId { get; set; }
        [JsonProperty("revisionDate")]
        public long RevisionDate { get; set; }
        [JsonProperty("revisionDateStr")]
        public String RevisionDateString { get; set; }
        [JsonProperty("summonerLevel")]
        public long Level { get; set; }

        public Collection<RunePage> GetRunePages()
        {
            var request = requester.CreateRequest(String.Format(RootUrl, Region)
                + String.Format(RunesUrl, Id));
            var response = (HttpWebResponse)request.GetResponse();
            var result = requester.GetResponseString(response.GetResponseStream());
            var json = JObject.Parse(result);

            return new Collection<RunePage>(api, json, requester, "pages", Region);
        }
    }
}
