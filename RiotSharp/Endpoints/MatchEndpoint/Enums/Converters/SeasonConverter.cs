using System;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace RiotSharp.Endpoints.MatchEndpoint.Enums.Converters
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
                default:
                    return null;
            }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, ((Season)value));
        }
    }
}
