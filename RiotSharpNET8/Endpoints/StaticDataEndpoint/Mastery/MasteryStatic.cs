using System.Text.Json.Serialization;

namespace RiotSharpNET8.Endpoints.StaticDataEndpoint.Mastery
{
    /// <summary>
    /// Class representing a mastery (Static API).
    /// </summary>
    public class MasteryStatic
    {
        internal MasteryStatic() { }

        /// <summary>
        /// List of string descripting the mastery.
        /// </summary>
        [JsonPropertyName("description")]
        public List<string> Description { get; set; }

        /// <summary>
        /// Mastery's id.
        /// </summary>
        [JsonPropertyName("id")]
        public int Id { get; set; }

        /// <summary>
        /// Mastery's image.
        /// </summary>
        [JsonPropertyName("image")]
        public ImageStatic Image { get; set; }

        /// <summary>
        /// Mastery's name.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Id of the prerequisite mastery.
        /// </summary>
        [JsonPropertyName("prereq")]
        public string Prerequisite { get; set; }

        /// <summary>
        /// Mastery's rank.
        /// </summary>
        [JsonPropertyName("ranks")]
        public int Rank { get; set; }

        /// <summary>
        /// Sanitized (HTML stripped) description of the mastery.
        /// </summary>
        [JsonPropertyName("sanitizedDescription")]
        public List<string> SanitizedDescription { get; set; }
    }
}
