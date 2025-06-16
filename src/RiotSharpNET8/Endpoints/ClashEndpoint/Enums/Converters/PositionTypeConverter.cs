using System.Text.Json;
using System.Text.Json.Serialization;

namespace RiotSharpNET8.Endpoints.ClashEndpoint.Enums.Converters
{
    public class PositionTypeConverter : JsonConverter<PositionType>
    {


        /*
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var token = JToken.Load(reader);
            var value = token.Value<string>();

            switch (value)
            {
                case "UNSELECTED":
                    return PositionType.Unselected;
                case "FILL":
                    return PositionType.Unselected;
                case "TOP":
                    return PositionType.Top;
                case "JUNGLE":
                    return PositionType.Jungle;
                case "MIDDLE":
                    return PositionType.Middle;
                case "BOTTOM":
                    return PositionType.Bottom;
                case "UTILITY":
                    return PositionType.Utility;
            }

            return null;
        }
        */

        public override PositionType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        { 
	        var value = reader.GetString();
            switch (value)
	        {
		        case "UNSELECTED":
			        return PositionType.Unselected;
		        case "FILL":
			        return PositionType.Fill;
		        case "TOP":
			        return PositionType.Top;
		        case "JUNGLE":
			        return PositionType.Jungle;
		        case "MIDDLE":
			        return PositionType.Middle;
		        case "BOTTOM":
			        return PositionType.Bottom;
		        case "UTILITY":
			        return PositionType.Utility;
	        }

            // Cant return null, so return Unselected
            // probably should return a totally new enum value
	        return PositionType.Unselected;
        }

        public override void Write(Utf8JsonWriter writer, PositionType value, JsonSerializerOptions options)
        {
	        writer.WriteStringValue(value.ToCustomString());
        }
        /*
        public override bool CanConvert(Type typeToConvert)
		{
			return typeof(string).GetTypeInfo().IsAssignableFrom(typeToConvert.GetTypeInfo());
		}
        */
    }
}