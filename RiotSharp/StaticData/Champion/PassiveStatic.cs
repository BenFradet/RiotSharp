using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RiotSharp
{
    public class PassiveStatic
    {
        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("image")]
        public ImageStatic Image { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
