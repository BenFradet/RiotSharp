using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RiotSharp.LeagueOfLegends.Endpoints.LeagueEndpoint.Enums.Converters
{
	public class DivisionConverter : JsonConverter<Division>
	{
		public override Division Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			return reader.GetString() switch
			{
				"I" => Division.I,
				"II" => Division.II,
				"III" => Division.III,
				"IV" => Division.IV,
				_ => throw new JsonException("Invalid division value")
			};
		}

		public override void Write(Utf8JsonWriter writer, Division value, JsonSerializerOptions options)
		{
			var str = value switch
			{
				Division.I => "I",
				Division.II => "II",
				Division.III => "III",
				Division.IV => "IV",
				_ => throw new JsonException("Invalid division value")
			};
			writer.WriteStringValue(str);
		}
	}
}
