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
    /// Class representing a Rune in the API.
    /// </summary>
    public class Rune : Thing
    {
        public Rune(JToken json)
        {
            JsonConvert.PopulateObject(json.ToString(), this, RiotApi.JsonSerializerSettings);
        }

        /// <summary>
        /// Rune description.
        /// </summary>
        [JsonProperty("description")]
        public String Description { get; set; }
        /// <summary>
        /// Rune ID.
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }
        /// <summary>
        /// Rune name.
        /// </summary>
        [JsonProperty("name")]
        public String Name { get; set; }
        /// <summary>
        /// Rune tier.
        /// </summary>
        [JsonProperty("tier")]
        public int Tier { get; set; }
    }
}
