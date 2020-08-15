using Newtonsoft.Json;

namespace RiotSharp.Endpoints.ClientEndpoint.PlayerList
{
    public class PlayerItem
    {
        internal PlayerItem() { }

        [JsonProperty("canUse")]
        public bool IsUsable { get; set; }

        [JsonProperty("consumable")]
        public bool IsConsumable { get; set; }

        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("displayName")]
        public string DisplayName { get; set; }

        [JsonProperty("rawDisplayName")]
        public string RawDisplayName { get; set; }

        [JsonProperty("itemID")]
        public int Id { get; set; }

        [JsonProperty("price")]
        public int Price { get; set; }

        [JsonProperty("slot")]
        public int Slot { get; set; }

        [JsonProperty("rawDescription")]
        public string RawDescription { get; set; }
    }
}