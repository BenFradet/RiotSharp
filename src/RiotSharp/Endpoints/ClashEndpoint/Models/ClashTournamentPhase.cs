using Newtonsoft.Json;
using RiotSharp.Misc.Converters;

namespace RiotSharp.Endpoints.ClashEndpoint.Models
{
    /// <summary>
    /// This model class defines properties of tournament phase model in clash
    /// </summary>
    public class ClashTournamentPhase
    {
        /// <summary>
        /// Id of the tournament phase
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }
        
        /// <summary>
        /// registration start time in tournament phase in ms
        /// </summary>
        [JsonProperty("registrationTime")]
        [JsonConverter(typeof(DateTimeConverterFromLong))]
        public long RegistrationTime { get; set; }
        
        /// <summary>
        /// Tournament start time in ms
        /// </summary>
        [JsonProperty("startTime")]
        [JsonConverter(typeof(DateTimeConverterFromLong))]
        public long StartTime { get; set; }
        
        /// <summary>
        /// boolean indicating if tournament has been cancelled or not
        /// </summary>
        [JsonProperty("cancelled")]
        public bool Cancelled { get; set; }
    }
}
