using Newtonsoft.Json;

namespace RiotSharp.Endpoints.ClientEndpoint.ActivePlayer
{
    public class ActivePlayerAbility
    {
        internal ActivePlayerAbility() { }

        [JsonProperty("abilityLevel")]
        public int Level { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }
        
        [JsonProperty("displayName")]
        public string DisplayName { get; set; }

        [JsonProperty("rawDisplayName")]
        public string RawDisplayName { get; set; }

        [JsonProperty("rawDescription")]
        public string RawDescription { get; set; }
    }
}