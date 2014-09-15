using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace RiotSharp.StaticDataEndpoint
{
    /// <summary>
    /// Class representing a mastery (Static API).
    /// </summary>
    [Serializable]
    public class MasteryStatic
    {
        internal MasteryStatic() { }

        /// <summary>
        /// List of string descripting the mastery.
        /// </summary>
        [JsonProperty("description")]
        public List<string> Description { get; set; }

        /// <summary>
        /// Mastery's id.
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// Mastery's image.
        /// </summary>
        [JsonProperty("image")]
        public ImageStatic Image { get; set; }

        /// <summary>
        /// Mastery's name.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Id of the prerequisite mastery.
        /// </summary>
        [JsonProperty("prereq")]
        public string Prerequisite { get; set; }

        /// <summary>
        /// Mastery's rank.
        /// </summary>
        [JsonProperty("ranks")]
        public int Rank { get; set; }

        /// <summary>
        /// Sanitized (HTML stripped) description of the mastery.
        /// </summary>
        [JsonProperty("sanitizedDescription")]
        public List<string> SanitizedDescription { get; set; }
    }
}
