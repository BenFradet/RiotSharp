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
            var str = token.Value<string>().ToLower();
            switch (str)
            {
                case "br":
                    return Region.Br;
                case "eune":
                    return Region.Eune;
                case "euw":
                    return Region.Euw;
                case "kr":
                    return Region.Kr;
                case "lan":
                    return Region.Lan;
                case "las":
                    return Region.Las;
                case "na":
                    return Region.Na;
                case "oce":
                    return Region.Oce;
                case "ru":
                    return Region.Ru;
                case "tr":
                    return Region.Tr;
                case "jp":
                    return Region.Jp;
                case "americas":
                    return Region.Americas;
                case "asia":
                    return Region.Asia;
                case "europe":
                    return Region.Europe;
                case "ap":
                    return Region.Ap;
                case "eu":
                    return Region.Eu;
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
