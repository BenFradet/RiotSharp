using System.Text.Json;
using System.Text.Json.Serialization;

namespace RiotSharpNET8.Endpoints.TournamentEndpoint.Enums.Converters
{
	internal class TournamentSpectatorTypeConverter : JsonConverter<TournamentSpectatorType>
	{
		public override TournamentSpectatorType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
            var value = reader.GetString();
			switch (value)
			{
				case "NONE":
					return TournamentSpectatorType.None;
				case "LOBBYONLY":
					return TournamentSpectatorType.LobbyOnly;
				case "ALL":
					return TournamentSpectatorType.All;
				default:
					return TournamentSpectatorType.None;
			}
		}

		public override void Write(Utf8JsonWriter writer, TournamentSpectatorType value, JsonSerializerOptions options)
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
                case "NONE":
                    return TournamentSpectatorType.None;
                case "LOBBYONLY":
                    return TournamentSpectatorType.LobbyOnly;
                case "ALL":
                    return TournamentSpectatorType.All;
                default:
                    return null;
            }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var spectatorType = (TournamentSpectatorType) value;
            string result;
            switch (spectatorType)
            {
                case TournamentSpectatorType.None:
                    result = "NONE";
                    break;
                case TournamentSpectatorType.LobbyOnly:
                    result = "LOBBYONLY";
                    break;
                case TournamentSpectatorType.All:
                    result = "ALL";
                    break;
                default:
                    result = string.Empty;
                    break;
            }
            serializer.Serialize(writer, result);
        }
        */
	}
}
