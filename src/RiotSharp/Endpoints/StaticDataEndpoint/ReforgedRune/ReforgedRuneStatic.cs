using Newtonsoft.Json;

namespace RiotSharp.Endpoints.StaticDataEndpoint.ReforgedRune
{
    /// <summary>
    /// Class representing a reforged rune (Static API).
    /// </summary>
    public class ReforgedRuneStatic
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Key { get; set; }

        [JsonProperty("shortDesc")]
        public string ShortDescription { get; set; }

        [JsonProperty("longDesc")]
        public string LongDescription { get; set; }

        public string Icon { get; set; }
    }
}
