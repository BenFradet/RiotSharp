using System.Text.Json;
using System.Text.Json.Serialization;

namespace RiotSharpNET8.Endpoints.MatchEndpoint.Enums.Converters
{
	class MonsterSubTypeConverter : JsonConverter<MonsterSubType>
	{
		public override MonsterSubType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
            var value = reader.GetString();
			switch (value)
			{
				case "AIR_DRAGON":
					return MonsterSubType.AirDragon;
				case "WATER_DRAGON":
					return MonsterSubType.WaterDragon;
				case "EARTH_DRAGON":
					return MonsterSubType.EarthDragon;
				case "FIRE_DRAGON":
					return MonsterSubType.FireDragon;
				case "ELDER_DRAGON":
					return MonsterSubType.ElderDragon;
			}

			// No null value returnable
			return MonsterSubType.AirDragon;
		}

		public override void Write(Utf8JsonWriter writer, MonsterSubType value, JsonSerializerOptions options)
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
                case "AIR_DRAGON":
                    return MonsterSubType.AirDragon;
                case "WATER_DRAGON":
                    return MonsterSubType.WaterDragon;
                case "EARTH_DRAGON":
                    return MonsterSubType.EarthDragon;
                case "FIRE_DRAGON":
                    return MonsterSubType.FireDragon;
                case "ELDER_DRAGON":
                    return MonsterSubType.ElderDragon;
                default:
                    return null;
            }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, ((MonsterSubType)value).ToCustomString());
        }
        */
	}
}
