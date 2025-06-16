using System.Text.Json;
using System.Text.Json.Serialization;

namespace RiotSharpNET8.Endpoints.ClashEndpoint.Enums.Converters
{
    public class RoleTypeConverter : JsonConverter<RoleType>
    {
        /*
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, ((RoleType)value).ToCustomString());
        }
		*/
        /*
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var token = JToken.Load(reader);
            var value = token.Value<string>();
            
            switch (value)
            {
                case "CAPTAIN":
                    return RoleType.Captain;
                case "MEMBER":
                    return RoleType.Member;
            }

            return null;
        }
        */
        /*
        public override bool CanConvert(Type objectType)
        {
            return typeof(string).GetTypeInfo().IsAssignableFrom(objectType.GetTypeInfo());
        }
        */
        public override RoleType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
	        var value = reader.GetString();
            switch (value)
	        {
		        case "CAPTAIN":
			        return RoleType.Captain;
		        case "MEMBER":
			        return RoleType.Member;
	        }

            // Again, cant return null here
            return RoleType.Member;
        }

        public override void Write(Utf8JsonWriter writer, RoleType value, JsonSerializerOptions options)
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