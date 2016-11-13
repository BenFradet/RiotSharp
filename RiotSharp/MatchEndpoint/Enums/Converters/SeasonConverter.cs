using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Reflection;

namespace RiotSharp.MatchEndpoint.Enums.Converters
{
    class SeasonConverter : JsonConverter
    {
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
                default:
                    return null;
            }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, ((Season)value).ToString().ToUpper());
        }
    }
}
