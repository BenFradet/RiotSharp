using System;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace RiotSharp.Misc.Converters
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
                    return Region.Br;
                case "EUNE":
                case "eune":
                    return Region.Eune;
                case "EUW":
                case "euw":
                    return Region.Euw;
                case "KR":
                    return Region.Kr;
                case "LAN":
                case "lan":
                    return Region.Lan;
                case "LAS":
                case "las":
                    return Region.Las;
                case "NA":
                case "na":
                    return Region.Na;
                case "OCE":
                case "oce":
                    return Region.Oce;
                case "RU":
                case "ru":
                    return Region.Ru;
                case "TR":
                case "tr":
                    return Region.Tr;
                case "JP":
                case "jp":
                    return Region.Jp;
                case "AMERICAS":
                case "americas":
                    return Region.Americas;
                case "ASIA":
                case "asia":
                    return Region.Asia;
                case "EUROPE":
                case "europe":
                    return Region.Europe;
                case "AP":
                case "ap":
                    return Region.Ap;
                case "EU":
                case "eu":
                    return Region.Eu;
                case "LATAM":
                case "latam":
                    return Region.Latam;
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
