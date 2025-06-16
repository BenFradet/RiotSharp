using System.Text.Json;
using System.Text.Json.Serialization;

namespace RiotSharpNET8.Endpoints.MatchEndpoint.Enums.Converters
{
	class LevelUpTypeConverter : JsonConverter<LevelUpType>
	{
		public override LevelUpType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
            var value = reader.GetString();
			switch (value)
			{
				case "EVOLVE":
					return LevelUpType.Evolve;
				case "NORMAL":
					return LevelUpType.Normal;
			}

			// No null value returnable
			return LevelUpType.Normal;
		}

		public override void Write(Utf8JsonWriter writer, LevelUpType value, JsonSerializerOptions options)
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
                case "EVOLVE":
                    return LevelUpType.Evolve;
                case "NORMAL":
                    return LevelUpType.Normal;
                default:
                    return null;
            }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, ((LevelUpType)value).ToCustomString());
        }
        */
	}
}
