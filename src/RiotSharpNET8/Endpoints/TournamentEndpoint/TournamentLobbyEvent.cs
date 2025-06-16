using System.Text.Json.Serialization;
using RiotSharpNET8.Endpoints.TournamentEndpoint.Enums;
using RiotSharpNET8.Misc.Converters;

namespace RiotSharpNET8.Endpoints.TournamentEndpoint
{
    /// <summary>
    /// Represents a tournament lobby event in the Riot tournament API.
    /// </summary>
    public class TournamentLobbyEvent
    {
        internal TournamentLobbyEvent()
        {
        }

        /// <summary>
        ///     The type of event that was triggered
        /// </summary>
        [JsonPropertyName("eventType")]
        public TournamentEventType EventType { get; set; }

        /// <summary>
        ///     The summoner that triggered the event
        /// </summary>
        [JsonPropertyName("summonerId")]
        public long SummonerId { get; set; }

        /// <summary>
        ///     Timestamp from the event
        /// </summary>
        [JsonPropertyName("timestamp")]
        [JsonConverter(typeof(DateTimeConverterFromStringTimestamp))]
        public DateTime Timestamp { get; set; }
    }
}
