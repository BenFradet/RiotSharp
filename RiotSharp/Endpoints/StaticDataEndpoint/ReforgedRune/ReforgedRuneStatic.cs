using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace RiotSharp.Endpoints.StaticDataEndpoint.ReforgedRune
{
    /// <summary>
    /// Class representing a reforged rune (Static API).
    /// </summary>
    public class ReforgedRuneStatic
    {
        public string RunePathName { get; set; }

        public int RunePathId { get; set; }

        public string Name { get; set; }

        public int Id { get; set; }

        public string Key { get; set; }

        [JsonProperty("shortDesc")]
        public string ShortDescription { get; set; }

        [JsonProperty("longDesc")]
        public string LongDescription { get; set; }

        public string Icon { get; set; }
    }
}
