using Newtonsoft.Json;

namespace RiotSharp.Endpoints.ClientEndpoint.PlayerList
{
    /// <summary>
    /// Represents an item owned by a <see cref="Player"/>.
    /// </summary>
    public class PlayerItem
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PlayerItem"/> class.
        /// </summary>
        internal PlayerItem() { }

        /// <summary>
        /// Indicates, whether the item can be used, i.e., has an active effect.
        /// </summary>
        [JsonProperty("canUse")]
        public bool IsUsable { get; set; }

        /// <summary>
        /// Indicates, whether the item can be consumed.
        /// </summary>
        [JsonProperty("consumable")]
        public bool IsConsumable { get; set; }

        /// <summary>
        /// Gets or sets the count.
        /// </summary>
        [JsonProperty("count")]
        public int Count { get; set; }

        /// <summary>
        /// Gets or sets the display name.
        /// </summary>
        [JsonProperty("displayName")]
        public string DisplayName { get; set; }

        /// <summary>
        /// Gets or sets the raw display name.
        /// </summary>
        [JsonProperty("rawDisplayName")]
        public string RawDisplayName { get; set; }

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        [JsonProperty("itemID")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        [JsonProperty("price")]
        public int Price { get; set; }

        /// <summary>
        /// Gets or sets the inventory slot.
        /// </summary>
        [JsonProperty("slot")]
        public int InventorySlot { get; set; }

        /// <summary>
        /// Gets or sets the raw description.
        /// </summary>
        [JsonProperty("rawDescription")]
        public string RawDescription { get; set; }
    }
}