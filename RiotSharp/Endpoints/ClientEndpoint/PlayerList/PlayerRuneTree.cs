using Newtonsoft.Json;

namespace RiotSharp.Endpoints.ClientEndpoint.PlayerList
{
    public class PlayerRuneTree
    {
        internal PlayerRuneTree() { }

        [JsonProperty("displayName")]
        public string DisplayName { get; set; }

        [JsonProperty("rawDisplayName")]
        public string RawDisplayName { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("rawDescription")]
        public string RawDescription { get; set; }
    }
}