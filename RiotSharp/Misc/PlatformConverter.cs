using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace RiotSharp.Misc
{
    class PlatformConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, ((Platform)value).ToString().ToUpper());
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var token = JToken.Load(reader);
            if (token.Value<string>() == null) return null;
            var str = token.Value<string>();
            switch (str)
            {
                case "NA1":
                    return Platform.NA1;
                case "BR1":
                    return Platform.BR1;
                case "LA1":
                    return Platform.LA1;
                case "LA2":
                    return Platform.LA2;
                case "OC1":
                    return Platform.OC1;
                case "EUN1":
                    return Platform.EUN1;
                case "TR1":
                    return Platform.TR1;
                case "RU":
                    return Platform.RU;
                case "EUW1":
                    return Platform.EUW1;
                case "KR":
                    return Platform.KR;
                default:
                    return null;
            }
        }

        public override bool CanConvert(Type objectType)
        {
            return typeof(string).IsAssignableFrom(objectType);
        }
    }

    public static class PlatformToRegionConverter
    {
        public static Region ConvertToRegion(this Platform platform)
        {
            switch (platform)
            {
                case Platform.NA1:
                    return Region.na;
                case Platform.BR1:
                    return Region.br;
                case Platform.LA1:
                    return Region.lan;
                case Platform.LA2:
                    return Region.las;
                case Platform.OC1:
                    return Region.oce;
                case Platform.EUN1:
                    return Region.eune;
                case Platform.TR1:
                    return Region.tr;
                case Platform.RU:
                    return Region.ru;
                case Platform.EUW1:
                    return Region.euw;
                case Platform.KR:
                    return Region.kr;
                default:
                    return Region.na;
            }
        }
    }
}
