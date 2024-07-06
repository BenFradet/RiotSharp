using System.Text.Json.Serialization;
using RiotSharpNET8.Misc.Converters;

namespace RiotSharpNET8.Endpoints.TeamEndpoint
{
    /// <summary>
    /// Message of the day of the team (Team API).
    /// </summary>
    public class MessageOfDay
    {
        internal MessageOfDay() { }

        /// <summary>
        /// Date of the message creation.
        /// </summary>
        [JsonPropertyName("createDate")]
        [JsonConverter(typeof(DateTimeConverterFromLong))]
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// Message.
        /// </summary>
        [JsonPropertyName("message")]
        public string Message { get; set; }

        /// <summary>
        /// Version of the message.
        /// </summary>
        [JsonPropertyName("version")]
        public int Version { get; set; }
    }
}
