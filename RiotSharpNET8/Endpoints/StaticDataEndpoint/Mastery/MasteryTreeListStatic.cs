using System.Text.Json.Serialization;

namespace RiotSharpNET8.Endpoints.StaticDataEndpoint.Mastery
{
    /// <summary>
    /// Class representing a list of mastery trees (Static API).
    /// </summary>
    public class MasteryTreeListStatic
    {
        internal MasteryTreeListStatic() { }

        /// <summary>
        /// List of mastery tree items.
        /// </summary>
        [JsonPropertyName("masteryTreeItems")]
        public List<MasteryTreeItemStatic> MasteryTreeItems { get; set; }
    }
}
