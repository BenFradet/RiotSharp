using System.Text.Json;
using System.Text.Json.Serialization;

namespace RiotSharpNET8.Misc.Converters
{
	/// <summary>
	/// Converts a <see cref="MapType"/> from and to JSON
	/// </summary>
	/// <seealso cref="JsonConverter" />
	public class MapTypeConverter : JsonConverter<MapType>
	{
		public override MapType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
            return (MapType)Enum.Parse(typeof(MapType), reader.GetString() ?? string.Empty);
		}

		public override void Write(Utf8JsonWriter writer, MapType value, JsonSerializerOptions options)
		{
            writer.WriteStringValue(value.ToString());
		}
		/*
        /// <inheritdoc />
        public override bool CanConvert(Type objectType)
        {
            return typeof(string).GetTypeInfo().IsAssignableFrom(objectType.GetTypeInfo());
        }

        /// <inheritdoc />
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
            JsonSerializer serializer)
        {
            var token = JToken.Load(reader);
            if (token.Value<string>() == null) return null;
            var str = token.Value<string>();
            return (MapType)(Enum.Parse(typeof(MapType), str));
        }

        /// <inheritdoc />
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            string result = ((int)value).ToString();
            serializer.Serialize(writer, result);
        }
        */
	}
}
