using System.Text.Json;
using System.Text.Json.Serialization;

namespace RiotSharpNET8.Misc.Converters
{
	class TimeSpanConverterFromMilliseconds : JsonConverter<TimeSpan>
	{
		public override TimeSpan Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
            return TimeSpan.FromMilliseconds(reader.GetInt64());
		}

		public override void Write(Utf8JsonWriter writer, TimeSpan value, JsonSerializerOptions options)
		{
            writer.WriteNumberValue(value.TotalMilliseconds);
		}
		/*
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(long);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var token = JToken.Load(reader);
            if (token.Value<long?>() != null)
            {
                return TimeSpan.FromMilliseconds(token.Value<long>());
            }
            return null;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, (long)(((TimeSpan)value).TotalMilliseconds));
        }
        */
	}
}
