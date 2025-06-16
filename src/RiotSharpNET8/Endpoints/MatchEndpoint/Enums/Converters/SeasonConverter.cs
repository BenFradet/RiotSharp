using System.Text.Json;
using System.Text.Json.Serialization;

namespace RiotSharpNET8.Endpoints.MatchEndpoint.Enums.Converters
{
	class SeasonConverter : JsonConverter<Season>
	{
		public override Season Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			var value = reader.GetString();
			switch (value)
			{
				case "PRESEASON3":
					return Season.PreSeason3;
				case "SEASON3":
					return Season.Season3;
				case "PRESEASON2014":
					return Season.PreSeason2014;
				case "SEASON2014":
					return Season.Season2014;
				case "PRESEASON2015":
					return Season.PreSeason2015;
				case "SEASON2015":
					return Season.Season2015;
				case "PRESEASON2016":
					return Season.PreSeason2016;
				case "SEASON2016":
					return Season.Season2016;
				case "PRESEASON2017":
					return Season.PreSeason2017;
				case "SEASON2017":
					return Season.Season2017;
				case "PRESEASON2018":
					return Season.PreSeason2018;
				case "SEASON2018":
					return Season.Season2018;
				case "PRESEASON2019":
					return Season.PreSeason2019;
				case "SEASON2019":
					return Season.Season2019;
			}

			// No null value returnable
			return Season.Season2019;
		}

		public override void Write(Utf8JsonWriter writer, Season value, JsonSerializerOptions options)
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
            if (token.Value<int>() == 0) return null;
            var nbr = token.Value<int>();
            switch (nbr)
            {
                case 0:
                    return Season.PreSeason3;
                case 1:
                    return Season.Season3;
                case 2:
                    return Season.PreSeason2014;
                case 3:
                    return Season.Season2014;
                case 4:
                    return Season.PreSeason2015;
                case 5:
                    return Season.Season2015;
                case 6:
                    return Season.PreSeason2016;
                case 7:
                    return Season.Season2016;
                case 8:
                    return Season.PreSeason2017;
                case 9:
                    return Season.Season2017;
                case 10:
                    return Season.PreSeason2018;
                case 11:
                    return Season.Season2018;
                case 12:
                    return Season.PreSeason2019;
                case 13:
                    return Season.Season2019;
                default:
                    return null;
            }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, ((Season)value));
        }
        */
	}
}
