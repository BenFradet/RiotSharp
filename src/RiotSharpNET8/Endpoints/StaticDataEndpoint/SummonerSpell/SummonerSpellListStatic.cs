using System.Text.Json.Serialization;

namespace RiotSharpNET8.Endpoints.StaticDataEndpoint.SummonerSpell
{
    /// <summary>
    /// Class representing a list of summoner spells (Static API).
    /// </summary>
    public class SummonerSpellListStatic
    {
        /// <summary>
        /// Map of summoner spells indexed by their name.
        /// </summary>
        [JsonPropertyName("data")]
        public Dictionary<string, SummonerSpellStatic> SummonerSpells { get; set; }

        /// <summary>
        /// API type (summoner).
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; }

        /// <summary>
        /// Version of the API.
        /// </summary>
        [JsonPropertyName("version")]
        public string Version { get; set; }
    }
}
