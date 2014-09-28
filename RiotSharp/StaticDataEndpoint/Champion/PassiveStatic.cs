// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PassiveStatic.cs" company="">
//
// </copyright>
// <summary>
//   Class representing a champion's passive (Static API).
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;

using Newtonsoft.Json;

namespace RiotSharp.StaticDataEndpoint
{
    /// <summary>
    /// Class representing a champion's passive (Static API).
    /// </summary>
    [Serializable]
    public class PassiveStatic
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PassiveStatic"/> class.
        /// </summary>
        internal PassiveStatic() { }

        /// <summary>
        /// String descripting the passive.
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// Image of the passive.
        /// </summary>
        [JsonProperty("image")]
        public ImageStatic Image { get; set; }

        /// <summary>
        /// Name of the passive.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Sanitized (HTML stripped) description of the passive.
        /// </summary>
        [JsonProperty("sanitizedDescription")]
        public string SanitizedDescription { get; set; }
    }
}
