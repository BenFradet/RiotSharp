using System.Text.Json;
using System.Text.Json.Serialization;

namespace RiotSharp.Core.Misc.Converters
{
	public class DateTimeConverterFromStringTimestamp : JsonConverter<DateTime>
	{
		public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
            if (reader.TokenType == JsonTokenType.String)
			{
				return DateTimeOffset.FromUnixTimeMilliseconds(long.Parse(reader.GetString() ?? string.Empty)).DateTime;
			}
			return default;
		}

		public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
		{
            writer.WriteStringValue(new DateTimeOffset(value).ToUnixTimeMilliseconds().ToString());
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
            if (token.Value<string>() != null)
            {
                return long.Parse(token.Value<string>()).ToDateTimeFromMilliSeconds();
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
