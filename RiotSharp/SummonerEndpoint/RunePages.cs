using System.Collections.Generic;
using Newtonsoft.Json;

namespace RiotSharp.SummonerEndpoint
{
    class RunePages
    {
        /// <summary>
        /// List of RunePages;
        /// </summary>
        [JsonProperty("pages")]
        public List<RunePage> Pages { get; set; }

        /// <summary>
        /// Summoner ID to wich the pages belong.
        /// </summary>
        [JsonProperty("summonerId")]
        public long SummonerId { get; set; }
    }
}