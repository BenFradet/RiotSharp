using System.Text.Json;
using System.Text.Json.Serialization;

namespace RiotSharp.Core.Misc.Converters
{
	class TimeSpanConverterFromSeconds : JsonConverter<TimeSpan>
	{
		public override TimeSpan Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
            return TimeSpan.FromSeconds(reader.GetInt64());
		}

		public override void Write(Utf8JsonWriter writer, TimeSpan value, JsonSerializerOptions options)
		{
            writer.WriteNumberValue(value.TotalSeconds);
		}
		/*
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(int);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var token = JToken.Load(reader);
            if (token.Value<int?>() != null)
            {
                return TimeSpan.FromSeconds(token.Value<int>());
            }
            return null;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, (long)(((TimeSpan)value).TotalSeconds));
        }
        */
	}
}
