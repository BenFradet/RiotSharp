using Newtonsoft.Json;

namespace RiotSharp.Endpoints.StaticDataEndpoint.Champion
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
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Name of the skin.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Ordered number of the skin.
        /// </summary>
        [JsonProperty("num")]
        public int Num { get; set; }
    }
}
