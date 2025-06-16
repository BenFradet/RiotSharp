using System.Text.Json;
using System.Text.Json.Serialization;

namespace RiotSharpNET8.Endpoints.MatchEndpoint.Enums.Converters
{
	class TowerTypeConverter : JsonConverter<TowerType>
	{
		public override TowerType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
            var value = reader.GetString();
			switch (value)
			{
				case "BASE_TURRET":
					return TowerType.BaseTurret;
				case "INNER_TURRET":
					return TowerType.InnerTurret;
				case "NEXUS_TURRET":
					return TowerType.NexusTurret;
				case "OUTER_TURRET":
					return TowerType.OuterTurret;
				case "UNDEFINED_TURRET":
					return TowerType.UndefinedTurret;
			}

			// No null value returnable
			return TowerType.UndefinedTurret;
		}

		public override void Write(Utf8JsonWriter writer, TowerType value, JsonSerializerOptions options)
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
                case "BASE_TURRET":
                    return TowerType.BaseTurret;
                case "INNER_TURRET":
                    return TowerType.InnerTurret;
                case "NEXUS_TURRET":
                    return TowerType.NexusTurret;
                case "OUTER_TURRET":
                    return TowerType.OuterTurret;
                case "UNDEFINED_TURRET":
                    return TowerType.UndefinedTurret;
                default:
                    return null;
            }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, ((TowerType)value).ToCustomString());
        }
        */
	}
}
