using System.Text.Json.Serialization;

namespace RiotSharpNET8.Endpoints.SummonerEndpoint
{
    class SummonerBaseList
    {
        [JsonPropertyName("summoners")]
        public List<SummonerBase> Summoners { get; set; }
    }
}
