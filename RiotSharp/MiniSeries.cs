using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace RiotSharp
{
    public class MiniSeries : Thing
    {
        public MiniSeries(JToken json)
        {
            JsonConvert.PopulateObject(json.ToString(), this, RiotApi.JsonSerializerSettings);
        }

        [JsonProperty("losses")]
        public int Losses { get; set; }
        [JsonProperty("progress")]
        [JsonConverter(typeof(CharArrayConverter))]
        public char[] Progress { get; set; }
        [JsonProperty("target")]
        public int Target { get; set; }
        [JsonProperty("timeLeftToPlayMillis")]
        public long TimeLeftToPlayMillis { get; set; }
        [JsonProperty("wins")]
        public int Wins { get; set; }
    }
}
