using System.Text.Json;
using System.Text.Json.Serialization;

namespace RiotSharpNET8.Misc.Converters
{
	class DateTimeConverterFromLong : JsonConverter<DateTime>
	{
        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
            if (reader.TokenType == JsonTokenType.Number)
			{
				return DateTimeOffset.FromUnixTimeMilliseconds(reader.GetInt64()).DateTime;
			}
			return default;
		}

		public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
		{
            writer.WriteNumberValue(new DateTimeOffset(value).ToUnixTimeMilliseconds());
		}
		/*
        public override bool CanConvert(Type objectType)
        {
            return typeof(long).GetTypeInfo().IsAssignableFrom(objectType.GetTypeInfo());
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
            JsonSerializer serializer)
        {
            JToken token = JToken.Load(reader);
            if(token.Value<long?>() != null)
            {
                return token.Value<long>().ToDateTimeFromMilliSeconds();
            }
            return null;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, ((DateTime)value).ToLong());
        }
        */
	}
}
