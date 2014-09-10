using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace RiotSharp.StaticDataEndpoint
{
    /// <summary>
    /// Class representing the tooltip when leveling up a spell on a champion (Static API).
    /// </summary>
    [Serializable]
    public class LevelTipStatic
    {
        internal LevelTipStatic() { }

        /// <summary>
        /// List of string representing the effects of leveling up this spell (going from a percentage
        /// to another for example.
        /// </summary>
        [JsonProperty("effect")]
        public List<string> Effects { get; set; }

        /// <summary>
        /// List of string representing which stats will be affected by leveling up this spell.
        /// </summary>
        [JsonProperty("label")]
        public List<string> Labels { get; set; }
    }
}
