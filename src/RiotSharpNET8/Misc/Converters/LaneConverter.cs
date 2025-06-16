using System.Text.Json;
using System.Text.Json.Serialization;

namespace RiotSharpNET8.Misc.Converters
{
	class LaneConverter : JsonConverter<Lane>
	{
		public override Lane Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			if (reader.TokenType != JsonTokenType.String) return Lane.None;

			var str = reader.GetString();
			switch (str)
			{
				case "MID":
					return Lane.Mid;
				case "MIDDLE":
					return Lane.Middle;
				case "TOP":
					return Lane.Top;
				case "JUNGLE":
					return Lane.Jungle;
				case "BOT":
					return Lane.Bot;
				case "BOTTOM":
					return Lane.Bottom;
				case "NONE":
					return Lane.None;
				default:
					return Lane.None;
			}
		}

		public override void Write(Utf8JsonWriter writer, Lane value, JsonSerializerOptions options)
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
                case "MID":
                    return Lane.Mid;
                case "MIDDLE":
                    return Lane.Middle;
                case "TOP":
                    return Lane.Top;
                case "JUNGLE":
                    return Lane.Jungle;
                case "BOT":
                    return Lane.Bot;
                case "BOTTOM":
                    return Lane.Bottom;
                case "NONE":
                    return Lane.None;
                default:
                    return null;
            }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, ((Lane)value).ToCustomString());
        }
        */
	}
}
