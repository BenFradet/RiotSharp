using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RiotSharp
{
    class SummonerBaseList
    {
        [JsonProperty("summoners")]
        public List<SummonerBase> Summoners { get; set; }
    }
}
