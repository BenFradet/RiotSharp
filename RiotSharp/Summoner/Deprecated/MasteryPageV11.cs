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
    /// Class representing a MasteryPage in the API.
    /// </summary>
    [Obsolete("The summoner api v1.1 is deprecated, please use MasteryPage instead.")]
    public class MasteryPageV11 : Thing
    {
        public MasteryPageV11(JToken json)
        {
            JsonConvert.PopulateObject(json.ToString(), this, RiotApi.JsonSerializerSettings);
        }

        /// <summary>
        /// Indicates if the mastery page is the current mastery page.
        /// </summary>
        [JsonProperty("current")]
        public bool Current { get; set; }

        /// <summary>
        /// Mastery page name.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// List of mastery page talents associated with the mastery page.
        /// </summary>
        [JsonProperty("talents")]
        public List<Talent> Talents { get; set; }
    }
}
