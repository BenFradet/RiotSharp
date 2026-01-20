using System.Text.Json;
using System.Text.Json.Serialization;

namespace RiotSharp.LeagueOfLegends.Endpoints.LeagueEndpoint.Enums.Converters
{
    class ProgressConverter : JsonConverter<char[]>
    {
        // Nullable is not correct. But not used anyway.
        public override char[]? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
	        var value = reader.GetString();
            return value?.ToCharArray();
        }

        public override void Write(Utf8JsonWriter writer, char[] value, JsonSerializerOptions options)
		{
			writer.WriteStringValue(new string(value));
		}
	}
}
