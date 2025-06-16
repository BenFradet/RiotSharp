using System.Text.Json.Serialization;

namespace RiotSharpNET8.Endpoints.StaticDataEndpoint.ReforgedRune
{
    /// <summary>
    /// Class representing a reforged rune (Static API).
    /// </summary>
    public class ReforgedRuneStatic
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Key { get; set; }

        [JsonPropertyName("shortDesc")]
        public string ShortDescription { get; set; }

        [JsonPropertyName("longDesc")]
        public string LongDescription { get; set; }

        public string Icon { get; set; }
    }
}
