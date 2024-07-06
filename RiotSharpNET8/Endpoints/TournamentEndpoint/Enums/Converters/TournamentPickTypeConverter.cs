using System.Text.Json;
using System.Text.Json.Serialization;

namespace RiotSharpNET8.Endpoints.TournamentEndpoint.Enums.Converters
{
	internal class TournamentPickTypeConverter : JsonConverter<TournamentPickType>
	{
		public override TournamentPickType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
            var value = reader.GetString();
			switch (value)
			{
				case "BLIND_PICK":
					return TournamentPickType.BlindPick;
				case "DRAFT_MODE":
					return TournamentPickType.DraftMode;
				case "ALL_RANDOM":
					return TournamentPickType.AllRandom;
				case "TOURNAMENT_DRAFT":
					return TournamentPickType.TournamentDraft;
				default:
					return TournamentPickType.BlindPick;
			}
		}

		public override void Write(Utf8JsonWriter writer, TournamentPickType value, JsonSerializerOptions options)
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
                case "BLIND_PICK":
                    return TournamentPickType.BlindPick;
                case "DRAFT_MODE":
                    return TournamentPickType.DraftMode;
                case "ALL_RANDOM":
                    return TournamentPickType.AllRandom;
                case "TOURNAMENT_DRAFT":
                    return TournamentPickType.TournamentDraft;
                default:
                    return null;
            }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var pickType = (TournamentPickType) value;
            string result;
            switch (pickType)
            {
                case TournamentPickType.BlindPick:
                    result = "BLIND_PICK";
                    break;
                case TournamentPickType.DraftMode:
                    result = "DRAFT_MODE";
                    break;
                case TournamentPickType.AllRandom:
                    result = "ALL_RANDOM";
                    break;
                case TournamentPickType.TournamentDraft:
                    result = "TOURNAMENT_DRAFT";
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
