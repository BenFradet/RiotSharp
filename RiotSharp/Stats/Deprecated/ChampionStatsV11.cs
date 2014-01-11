using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace RiotSharp
{
    /// <summary>
    /// Class representing the ChampionStats in the API.
    /// </summary>
    [Obsolete("The stats api v1.1 is deprecated, please use ChampionStats instead.")]
    public class ChampionStatsV11 : Thing
    {
        public ChampionStatsV11(JToken json)
        {
            JsonConvert.PopulateObject(json.ToString(), this, RiotApi.JsonSerializerSettings);
        }

        /// <summary>
        /// Champion id.
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// Champion name.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// List of stats associated with the champion.
        /// </summary>
        [JsonProperty("stats")]
        public List<ChampionStatV11> Stats { get; set; }
    }
}
