using System.Text.Json;
using System.Text.Json.Serialization;

namespace RiotSharpNET8.Endpoints.MatchEndpoint.Enums.Converters
{
	class MonsterTypeConverter : JsonConverter<MonsterType>
	{
		public override MonsterType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			var value = reader.GetString();
			switch (value)
			{
				case "BARON_NASHOR":
					return MonsterType.BaronNashor;
				case "BLUE_GOLEM":
					return MonsterType.BlueGolem;
				case "DRAGON":
					return MonsterType.Dragon;
				case "RED_LIZARD":
					return MonsterType.RedLizard;
				case "VILEMAW":
					return MonsterType.Vilemaw;
				case "RIFTHERALD":
					return MonsterType.RiftHerald;
			}

			// No null value returnable
			return MonsterType.BaronNashor;
		}

		public override void Write(Utf8JsonWriter writer, MonsterType value, JsonSerializerOptions options)
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
                case "BARON_NASHOR":
                    return MonsterType.BaronNashor;
                case "BLUE_GOLEM":
                    return MonsterType.BlueGolem;
                case "DRAGON":
                    return MonsterType.Dragon;
                case "RED_LIZARD":
                    return MonsterType.RedLizard;
                case "VILEMAW":
                    return MonsterType.Vilemaw;
                case "RIFTHERALD":
                    return MonsterType.RiftHerald;
                default:
                    return null;
            }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, ((MonsterType)value).ToCustomString());
        }
        */
	}
}
