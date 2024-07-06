using System.Text.Json.Serialization;

namespace RiotSharpNET8.Endpoints.StaticDataEndpoint.Mastery
{
    /// <summary>
    /// Class representing a mastery tree item or talent (Static API).
    /// </summary>
    public class MasteryTreeItemStatic
    {
        internal MasteryTreeItemStatic() { }

        /// <summary>
        /// Id of the mastery.
        /// </summary>
        [JsonPropertyName("masteryId")]
        public int MasteryId { get; set; }

        /// <summary>
        /// Prerequisite.
        /// </summary>
        [JsonPropertyName("prereq")]
        public string Prerequisite { get; set; }
    }
}
