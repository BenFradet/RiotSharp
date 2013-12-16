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
        public Summoner(RiotApi api, JToken summoner, IRequester requester, Region region)
            : base(api, summoner, requester, region) { }
        
        [JsonProperty("profileIconId")]
        public int ProfileIconId { get; set; }
        [JsonProperty("revisionDate")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime RevisionDate { get; set; }
        [JsonProperty("revisionDateStr")]
        public String RevisionDateString { get; set; }
        [JsonProperty("summonerLevel")]
        public long Level { get; set; }
    }
}
