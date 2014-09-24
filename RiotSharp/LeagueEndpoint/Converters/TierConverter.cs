using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace RiotSharp.LeagueEndpoint
{
    class TierConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(string).IsAssignableFrom(objectType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
            JsonSerializer serializer)
        {
            var token = JToken.Load(reader);
            if (token.Value<string>() != null)
            {
                var str = token.Value<string>();
                switch (str)
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
                    default:
                        return null;
                }
            }
            return null;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, ((Tier)value).ToString().ToUpper());
        }
    }
}
