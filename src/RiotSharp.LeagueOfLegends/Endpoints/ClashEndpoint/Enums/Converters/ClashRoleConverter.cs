using System.Text.Json;
using System.Text.Json.Serialization;

namespace RiotSharp.LeagueOfLegends.Endpoints.ClashEndpoint.Enums.Converters
{
    public class ClashRoleConverter : JsonConverter<ClashRole>
    {
        public override ClashRole Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
	        var value = reader.GetString();
            switch (value)
	        {
		        case "CAPTAIN":
			        return ClashRole.Captain;
		        case "MEMBER":
			        return ClashRole.Member;
	        }

            // Again, cant return null here
            return ClashRole.Member;
        }

        public override void Write(Utf8JsonWriter writer, ClashRole value, JsonSerializerOptions options)
        {
	        writer.WriteStringValue(value.ToCustomString());
        }
    }
}