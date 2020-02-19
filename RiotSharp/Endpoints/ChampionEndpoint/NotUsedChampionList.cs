using System.Collections.Generic;
using Newtonsoft.Json;

namespace RiotSharp.Endpoints.ChampionEndpoint
{
    class NotUsedChampionList
    {
        /// <summary>
        /// List of Champions.
        /// </summary>
        [JsonProperty("champions")]
        public List<Champion> Champions { get; set; }
    }
}
