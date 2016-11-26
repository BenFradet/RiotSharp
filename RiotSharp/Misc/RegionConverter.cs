using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Reflection;

namespace RiotSharp
{
    class RegionConverter : JsonConverter
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
                case "BR":
                case "br":
                    return Region.br;
                case "EUNE":
                case "eune":
                    return Region.eune;
                case "EUW":
                case "euw":
                    return Region.euw;
                case "KR":
                    return Region.kr;
                case "LAN":
                case "lan":
                    return Region.lan;
                case "LAS":
                case "las":
                    return Region.las;
                case "NA":
                case "na":
                    return Region.na;
                case "OCE":
                case "oce":
                    return Region.oce;
                case "RU":
                case "ru":
                    return Region.ru;
                case "TR":
                case "tr":
                    return Region.tr;
                case "JP":
                case "jp":
                    return Region.jp;
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
