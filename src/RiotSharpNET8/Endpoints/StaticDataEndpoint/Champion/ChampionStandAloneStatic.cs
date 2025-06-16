using System.Text.Json.Serialization;

namespace RiotSharpNET8.Endpoints.StaticDataEndpoint.Champion
{
    internal class ChampionStandAloneStatic
    {
        [JsonPropertyName("type")]
        internal string Type { get; set; }

        [JsonPropertyName("format")]
        internal string Format { get; set; }

        [JsonPropertyName("Version")]
        internal string Version { get; set; }
        
        [JsonPropertyName("data")]
        internal Dictionary<string, ChampionStatic> Data { get; set; }
    }
}
