using System.Text.Json;
using System.Text.Json.Serialization;

namespace RiotSharp.LeagueOfLegends.Misc.Converters
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
	}
}
