using System.Text.Json.Serialization;

namespace RiotSharpNET8.Endpoints.StaticDataEndpoint.Map
{
    class MapsStatic
    {
        /// <summary>
        /// Map of id to map.
        /// </summary>
        [JsonPropertyName("data")]
        public Dictionary<int, MapStatic> Data { get; set; }
    }
}
