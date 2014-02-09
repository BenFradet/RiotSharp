using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RiotSharp
{
    class RecentGames
    {
        [JsonProperty("games")]
        public List<Game> Games { get; set; }

        [JsonProperty("summonerId")]
        public long SummonerId { get; set; }
    }
}
