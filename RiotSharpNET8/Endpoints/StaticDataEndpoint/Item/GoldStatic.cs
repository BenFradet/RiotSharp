using System.Text.Json.Serialization;

namespace RiotSharpNET8.Endpoints.StaticDataEndpoint.Item
{
    /// <summary>
    /// Class representing an item's value (Static API).
    /// </summary>
    public class GoldStatic
    {
        internal GoldStatic() { }

        /// <summary>
        /// Base price of an item.
        /// </summary>
        [JsonPropertyName("base")]
        public int BasePrice { get; set; }

        /// <summary>
        /// Whether an item is purchasable or not.
        /// </summary>
        [JsonPropertyName("purchasable")]
        public bool Purchasable { get; set; }

        /// <summary>
        /// Reselling price of an item.
        /// </summary>
        [JsonPropertyName("sell")]
        public int SellingPrice { get; set; }

        /// <summary>
        /// Total price of an item.
        /// </summary>
        [JsonPropertyName("total")]
        public int TotalPrice { get; set; }
    }
}
