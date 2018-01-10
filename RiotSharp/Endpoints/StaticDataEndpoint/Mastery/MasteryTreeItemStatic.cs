using Newtonsoft.Json;

namespace RiotSharp.Endpoints.StaticDataEndpoint.Mastery
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
        [JsonProperty("masteryId")]
        public int MasteryId { get; set; }

        /// <summary>
        /// Prerequisite.
        /// </summary>
        [JsonProperty("prereq")]
        public string Prerequisite { get; set; }
    }
}
