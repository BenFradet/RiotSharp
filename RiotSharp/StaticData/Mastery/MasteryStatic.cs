using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RiotSharp
{
    public class MasteryStatic
    {
        [JsonProperty("description")]
        public List<string> Description { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("image")]
        public ImageStatic Image { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("prereq")]
        public string Prerequisite { get; set; }

        [JsonProperty("ranks")]
        public int Rank { get; set; }
    }
}
