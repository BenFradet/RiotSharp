using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace RiotSharp.MatchEndpoint
{
    class SeasonConverter : JsonConverter
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
                    case "PRESEASON3":
                        return Season.PreSeason3;
                    case "SEASON3":
                        return Season.Season3;
                    case "PRESEASON2014":
                        return Season.PreSeason2014;
                    case "SEASON2014":
                        return Season.Season2014;
                    default:
                        return null;
                }
            }
            return null;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, ((Season)value).ToString().ToUpper());
        }
    }
}
