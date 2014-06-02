using System.Collections.Generic;
using Newtonsoft.Json;

namespace RiotSharp
{
    class SummonerBaseList
    {
        [JsonProperty("summoners")]
        public List<SummonerBase> Summoners { get; set; }
    }
}
