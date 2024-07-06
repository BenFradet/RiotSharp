using System.Text.Json;
using System.Text.Json.Serialization;

namespace RiotSharpNET8.Endpoints.MatchEndpoint.Enums.Converters
{
	class BuildingTypeConverter : JsonConverter<BuildingType>
	{
		public override BuildingType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
            var value = reader.GetString();
			switch (value)
			{
				case "INHIBITOR_BUILDING":
					return BuildingType.InhibitorBuilding;
				case "TOWER_BUILDING":
					return BuildingType.TowerBuilding;
			}

			// No null value returnable
			return BuildingType.TowerBuilding;
		}

		public override void Write(Utf8JsonWriter writer, BuildingType value, JsonSerializerOptions options)
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
                case "INHIBITOR_BUILDING":
                    return BuildingType.InhibitorBuilding;
                case "TOWER_BUILDING":
                    return BuildingType.TowerBuilding;
                default:
                    return null;
            }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, ((BuildingType)value).ToCustomString());
        }
        */
	}
}
