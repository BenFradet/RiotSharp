using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RiotSharp
{
    public class GoldStatic
    {
        [JsonProperty("base")]
        public int BasePrice { get; set; }

        [JsonProperty("purchasable")]
        public bool Purchasable { get; set; }

        [JsonProperty("sell")]
        public int SellingPrice { get; set; }

        [JsonProperty("total")]
        public int TotalPrice { get; set; }
    }
}
