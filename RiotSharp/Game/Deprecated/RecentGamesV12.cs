using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RiotSharp
{
    class RecentGamesV12
    {
        [JsonProperty("games")]
        public List<GameV12> Games { get; set; }

        [JsonProperty("summonerId")]
        public long SummonerId { get; set; }
    }
}
