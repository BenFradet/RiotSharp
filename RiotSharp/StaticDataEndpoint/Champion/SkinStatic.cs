// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SkinStatic.cs" company="">
//   
// </copyright>
// <summary>
//   Class representing a skin of a champion (Static API).
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;

using Newtonsoft.Json;

namespace RiotSharp.StaticDataEndpoint
{
    /// <summary>
    /// Class representing a skin of a champion (Static API).
    /// </summary>
    [Serializable]
    public class SkinStatic
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SkinStatic"/> class.
        /// </summary>
        internal SkinStatic() { }

        /// <summary>
        /// Id of the skin.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Name of the skin.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Ordered number of the skin.
        /// </summary>
        [JsonProperty("num")]
        public int Num { get; set; }
    }
}
