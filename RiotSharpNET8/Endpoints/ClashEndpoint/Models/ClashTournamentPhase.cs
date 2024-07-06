using System.Text.Json.Serialization;
using RiotSharpNET8.Misc.Converters;

namespace RiotSharpNET8.Endpoints.ClashEndpoint.Models
{
    /// <summary>
    /// This model class defines properties of tournament phase model in clash
    /// </summary>
    public class ClashTournamentPhase
    {
        /// <summary>
        /// Id of the tournament phase
        /// </summary>
        [JsonPropertyName("id")]
        public int Id { get; set; }
        
        /// <summary>
        /// registration start time in tournament phase in ms
        /// </summary>
        [JsonPropertyName("registrationTime")]
        [JsonConverter(typeof(DateTimeConverterFromLong))]
        public long RegistrationTime { get; set; }
        
        /// <summary>
        /// Tournament start time in ms
        /// </summary>
        [JsonPropertyName("startTime")]
        [JsonConverter(typeof(DateTimeConverterFromLong))]
        public long StartTime { get; set; }
        
        /// <summary>
        /// boolean indicating if tournament has been cancelled or not
        /// </summary>
        [JsonPropertyName("cancelled")]
        public bool Cancelled { get; set; }
    }
}
