using System.Text.Json;
using System.Text.Json.Serialization;

namespace RiotSharp.LeagueOfLegends.Endpoints.ClashEndpoint.Enums.Converters
{
    public class ClashPositionConverter : JsonConverter<ClashPosition>
    {
        public override ClashPosition Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        { 
	        var value = reader.GetString();
            switch (value)
	        {
		        case "UNSELECTED":
			        return ClashPosition.Unselected;
		        case "FILL":
			        return ClashPosition.Fill;
		        case "TOP":
			        return ClashPosition.Top;
		        case "JUNGLE":
			        return ClashPosition.Jungle;
		        case "MIDDLE":
			        return ClashPosition.Middle;
		        case "BOTTOM":
			        return ClashPosition.Bottom;
		        case "UTILITY":
			        return ClashPosition.Utility;
	        }

            // Cant return null, so return Unselected
            // probably should return a totally new enum value
	        return ClashPosition.Unselected;
        }

        public override void Write(Utf8JsonWriter writer, ClashPosition value, JsonSerializerOptions options)
        {
	        writer.WriteStringValue(value.ToCustomString());
        }
    }
}