using System.Text.Json.Serialization;
using RiotSharpNET8.Misc.Converters;

namespace RiotSharpNET8.Endpoints.SummonerEndpoint
{
    /// <summary>
    /// Class representing a Summoner in the API.
    /// </summary>
    public class Summoner : SummonerBase
    {
        /// <summary>
        /// ID of the summoner icon associated with the summoner.
        /// </summary>
        [JsonPropertyName("profileIconId")]
        public int ProfileIconId { get; set; }

        /// <summary>
        /// Date summoner was last modified.
        /// </summary>
        [JsonPropertyName("revisionDate")]
        [JsonConverter(typeof(DateTimeConverterFromLong))]
        public DateTime RevisionDate { get; set; }

        /// <summary>
        /// Summoner level associated with the summoner.
        /// </summary>
        [JsonPropertyName("summonerLevel")]
        public long Level { get; set; }
    }
}
