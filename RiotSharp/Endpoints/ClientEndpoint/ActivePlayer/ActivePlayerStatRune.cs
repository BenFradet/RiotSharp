using Newtonsoft.Json;

namespace RiotSharp.Endpoints.ClientEndpoint.ActivePlayer
{
    public class ActivePlayerStatRune
    {
        internal ActivePlayerStatRune() { }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("rawDescription")]
        public string RawDescription { get; set; }
    }
}