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
    public class ChampionStats : Thing
    {
        public ChampionStats(JToken json)
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
        public String Name { get; set; }
        /// <summary>
        /// List of stats associated with the champion.
        /// </summary>
        [JsonProperty("stats")]
        public List<ChampionStat> Stats { get; set; }
    }
}
