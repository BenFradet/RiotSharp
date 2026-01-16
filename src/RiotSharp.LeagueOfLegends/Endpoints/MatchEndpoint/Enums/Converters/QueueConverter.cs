using System.Text.Json;
using System.Text.Json.Serialization;

namespace RiotSharp.LeagueOfLegends.Endpoints.MatchEndpoint.Enums.Converters
{
    /// <summary>
    /// Converter for Queue enum.
    /// </summary>
    public class QueueConverter : JsonConverter<Queue>
    {
        /// <inheritdoc />
        public override Queue Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.Number)
            {
                var queueId = reader.GetInt32();
                if (Enum.IsDefined(typeof(Queue), queueId))
                {
                    return (Queue)queueId;
                }
                return (Queue)queueId;
            }

            return Queue.CustomGames;
        }

        /// <inheritdoc />
        public override void Write(Utf8JsonWriter writer, Queue value, JsonSerializerOptions options)
        {
            writer.WriteNumberValue((int)value);
        }
    }
}
