using System.Text.Json;
using System.Text.Json.Serialization;

namespace RiotSharpNET8.Endpoints.MatchEndpoint.Enums.Converters
{
	class CapturedPointConverter : JsonConverter<CapturedPoint>
	{
		public override CapturedPoint Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
            var value = reader.GetString();
            switch (value)
            {
				case "POINT_A":
					return CapturedPoint.PointA;
				case "POINT_B":
					return CapturedPoint.PointB;
				case "POINT_C":
					return CapturedPoint.PointC;
				case "POINT_D":
					return CapturedPoint.PointD;
				case "POINT_E":
					return CapturedPoint.PointE;
			}
            // No null value returnable
			return CapturedPoint.PointA;
		}

		public override void Write(Utf8JsonWriter writer, CapturedPoint value, JsonSerializerOptions options)
		{
            writer.WriteStringValue(value.ToCustomString());
		}
		/*
        public override bool CanConvert(Type objectType)
        {
            return typeof(string).GetTypeInfo().IsAssignableFrom(objectType.GetTypeInfo());
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
            JsonSerializer serializer)
        {
            var token = JToken.Load(reader);
            if (token.Value<string>() == null) return null;
            var str = token.Value<string>();
            switch (str)
            {
                case "POINT_A":
                    return CapturedPoint.PointA;
                case "POINT_B":
                    return CapturedPoint.PointB;
                case "POINT_C":
                    return CapturedPoint.PointC;
                case "POINT_D":
                    return CapturedPoint.PointD;
                case "POINT_E":
                    return CapturedPoint.PointE;
                default:
                    return null;
            }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, ((CapturedPoint)value).ToCustomString());
        }
        */
	}
}
