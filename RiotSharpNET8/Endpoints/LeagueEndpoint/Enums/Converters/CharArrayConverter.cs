using System.Text.Json;
using System.Text.Json.Serialization;

namespace RiotSharpNET8.Endpoints.LeagueEndpoint.Enums.Converters
{
    class CharArrayConverter : JsonConverter<char[]>
    {
        public override char[] Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
	        var value = reader.GetString();
            return value.ToCharArray();
        }
        /*
		public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
            JsonSerializer serializer)
        {
            var token = JToken.Load(reader);
            return token.ToString().ToCharArray();
        }
        */

        public override void Write(Utf8JsonWriter writer, char[] value, JsonSerializerOptions options)
		{
			writer.WriteStringValue(new string(value));
		}

        /*
		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
        */
        /*
        public override bool CanConvert(Type typeToConvert)
        {
	        return typeof(char[]).GetTypeInfo().IsAssignableFrom(typeToConvert.GetTypeInfo());
        }
        */
    }
}
