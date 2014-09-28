// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GoldStatic.cs" company="">
//   
// </copyright>
// <summary>
//   Class representing an item's value (Static API).
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;

using Newtonsoft.Json;

namespace RiotSharp.StaticDataEndpoint
{
    /// <summary>
    /// Class representing an item's value (Static API).
    /// </summary>
    [Serializable]
    public class GoldStatic
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GoldStatic"/> class.
        /// </summary>
        internal GoldStatic() { }

        /// <summary>
        /// Base price of an item.
        /// </summary>
        [JsonProperty("base")]
        public int BasePrice { get; set; }

        /// <summary>
        /// Whether an item is purchasable or not.
        /// </summary>
        [JsonProperty("purchasable")]
        public bool Purchasable { get; set; }

        /// <summary>
        /// Reselling price of an item.
        /// </summary>
        [JsonProperty("sell")]
        public int SellingPrice { get; set; }

        /// <summary>
        /// Total price of an item.
        /// </summary>
        [JsonProperty("total")]
        public int TotalPrice { get; set; }
    }
}
