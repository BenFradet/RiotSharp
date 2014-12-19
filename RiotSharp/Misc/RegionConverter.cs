using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace RiotSharp
{
    class RegionConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(string).IsAssignableFrom(objectType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
            JsonSerializer serializer)
        {
            var token = JToken.Load(reader);
            if (token.Value<string>() == null) return null;
            var str = token.Value<string>();
            switch (str)
            {
                case "BR":
                    return Region.br;
                case "EUNE":
                    return Region.eune;
                case "EUW":
                    return Region.euw;
                case "KR":
                    return Region.kr;
                case "LAN":
                    return Region.lan;
                case "LAS":
                    return Region.las;
                case "NA":
                    return Region.na;
                case "OCE":
                    return Region.oce;
                case "RU":
                    return Region.ru;
                case "TR":
                    return Region.tr;
                default:
                    return null;
            }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, ((Region)value).ToString().ToUpper());
        }
    }
}
