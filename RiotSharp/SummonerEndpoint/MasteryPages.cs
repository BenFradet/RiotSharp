using Newtonsoft.Json;
using System.Collections.Generic;

namespace RiotSharp.SummonerEndpoint
{
    class MasteryPages
    {
        /// <summary>
        /// List of MasteryPages.
        /// </summary>
        [JsonProperty("pages")]
        public List<MasteryPage> Pages { get; set; }

        /// <summary>
        /// Summoner ID to wich the pages belong.
        /// </summary>
        [JsonProperty("summonerId")]
        public long SummonerId { get; set; }
    }
}