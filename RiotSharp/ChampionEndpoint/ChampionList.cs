using System.Collections.Generic;
using Newtonsoft.Json;

namespace RiotSharp.ChampionEndpoint
{
    class ChampionList
    {
        /// <summary>
        /// List of Champions.
        /// </summary>
        [JsonProperty("champions")]
        public List<Champion> Champions { get; set; }
    }
}
