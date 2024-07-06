using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace RiotSharpNET8.Misc.Converters
{
	class DateTimeConverterFromString : JsonConverter<DateTime>
	{
        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
            if (reader.TokenType == JsonTokenType.String)
			{
				return DateTime.ParseExact(reader.GetString(), "MM/dd/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
			}
			return default;
		}

		public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
		{
            writer.WriteStringValue(value.ToString("yyyy-MM-ddTHH:mm:ss.zzzZ"));
		}
		/*
        public override bool CanConvert(Type objectType)
        {
            return typeof(string).GetTypeInfo().IsAssignableFrom(objectType.GetTypeInfo());
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
            JsonSerializer serializer)
        {
            var token = JToken.Load(reader);
            if (token.Value<string>() == null) return null;
            var str = token.Value<string>();
            return DateTime.ParseExact(str, "MM/dd/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, ((DateTime)value).ToString("yyyy-MM-ddTHH:mm:ss.zzzZ"));
        }
        */
	}
}
