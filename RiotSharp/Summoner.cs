using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace RiotSharp
{
    public class Summoner : CommonParent
    {
        private const String RootUrl = "/api/lol/{0}/v1.1/summoner";
        private const String MasteriesUrl = "/{0}/masteries";
        private const String RunesUrl = "/{0}/runes";

        public Summoner(RiotApi api, JToken summoner, IRequester requester)
            : base(api, summoner, requester) { }
        
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
