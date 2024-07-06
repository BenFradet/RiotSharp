using System.Text.Json;
using System.Text.Json.Serialization;

namespace RiotSharpNET8.Endpoints.MatchEndpoint.Enums.Converters
{
	class AscendedTypeConverter : JsonConverter<AscendedType>
	{

		public override AscendedType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
            var value = reader.GetString();
			switch (value)
			{
				case "CHAMPION_ASCENDED":
					return AscendedType.ChampionAscended;
				case "CLEAR_ASCENDED":
					return AscendedType.ClearAscended;
				case "MINION_ASCENDED":
					return AscendedType.MinionAscended;
			}

            // No null value returnable
            return AscendedType.ClearAscended;
		}

		public override void Write(Utf8JsonWriter writer, AscendedType value, JsonSerializerOptions options)
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
                case "CHAMPION_ASCENDED":
                    return AscendedType.ChampionAscended;
                case "CLEAR_ASCENDED":
                    return AscendedType.ClearAscended;
                case "MINION_ASCENDED":
                    return AscendedType.MinionAscended;
                default:
                    return null;
            }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, ((AscendedType)value).ToCustomString());
        }
        */
	}
}
