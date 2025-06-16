using System.Text.Json;
using System.Text.Json.Serialization;

namespace RiotSharpNET8.Endpoints.LeagueEndpoint.Enums.Converters
{
    class TierConverter : JsonConverter<Tier>
    {
	    public override Tier Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
	    {
		    var value = reader.GetString();
            switch (value)
		    {
			    case "MASTER":
				    return Tier.Master;
			    case "CHALLENGER":
				    return Tier.Challenger;
			    case "DIAMOND":
				    return Tier.Diamond;
			    case "PLATINUM":
				    return Tier.Platinum;
			    case "GOLD":
				    return Tier.Gold;
			    case "SILVER":
				    return Tier.Silver;
			    case "BRONZE":
				    return Tier.Bronze;
			    case "IRON":
				    return Tier.Iron;
			    case "UNRANKED":
				    return Tier.Unranked;
		    }

            // No null value returnable
            return Tier.Unranked;
	    }

	    public override void Write(Utf8JsonWriter writer, Tier value, JsonSerializerOptions options)
	    {
            writer.WriteStringValue(value.ToString().ToUpper());
	    }
        /*
        public override bool CanConvert(Type objectType)
        {
            return typeof(string).GetTypeInfo().IsAssignableFrom(objectType.GetTypeInfo());
        }
        */
        /*
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
            JsonSerializer serializer)
        {
            var token = JToken.Load(reader);
            var str = token.Value<string>();
            if (str == null) return null;

            if(Enum.TryParse<Tier>(str, true, out var result))
            {
                return result;
            }
            return null;
        }
        */
        /*
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, ((Tier)value).ToString().ToUpper());
        }
        */

    }
}
