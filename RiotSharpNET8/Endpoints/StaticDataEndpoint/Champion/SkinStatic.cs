using System.Text.Json.Serialization;

namespace RiotSharpNET8.Endpoints.StaticDataEndpoint.Champion
{
    /// <summary>
    /// Class representing a skin of a champion (Static API).
    /// </summary>
    public class SkinStatic
    {
        internal SkinStatic() { }

        /// <summary>
        /// Id of the skin.
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary>
        /// Name of the skin.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Ordered number of the skin.
        /// </summary>
        [JsonPropertyName("num")]
        public int Num { get; set; }
    }
}
