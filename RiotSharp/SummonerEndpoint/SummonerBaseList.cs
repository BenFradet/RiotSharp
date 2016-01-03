using Newtonsoft.Json;
using System.Collections.Generic;

namespace RiotSharp.SummonerEndpoint
{
    class SummonerBaseList
    {
        [JsonProperty("summoners")]
        public List<SummonerBase> Summoners { get; set; }
    }
}
