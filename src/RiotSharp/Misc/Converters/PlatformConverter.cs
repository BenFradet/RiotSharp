using System;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace RiotSharp.Misc.Converters
{
    class PlatformConverter : JsonConverter
    {
        /// <inheritdoc />
        public override bool CanConvert(Type objectType)
        {
            return typeof(string).GetTypeInfo().IsAssignableFrom(objectType.GetTypeInfo());
        }

        /// <inheritdoc />
        public override object ReadJson(
            JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var token = JToken.Load(reader);
            if (token.Value<string>() == null) return null;
            var str = token.Value<string>().ToUpperInvariant();
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
                case "JP1":
                    return Platform.JP1;
                case "KR":
                    return Platform.KR;
                case "NA":
                    return Platform.NA1;
                case "":
                    return Platform.NoPlatform;
                default:
                    return null;
            }
        }

        /// <inheritdoc />
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var platform = (Platform)value;
            var str = platform == Platform.NoPlatform ? "" : platform.ToString().ToUpper();
            serializer.Serialize(writer, str);
        }
    }

    public static class PlatformToRegionConverter
    {
        public static Region ConvertToRegion(this Platform platform)
        {
            switch (platform)
            {
                case Platform.NA1:
                    return Region.Na;
                case Platform.BR1:
                    return Region.Br;
                case Platform.LA1:
                    return Region.Lan;
                case Platform.LA2:
                    return Region.Las;
                case Platform.OC1:
                    return Region.Oce;
                case Platform.EUN1:
                    return Region.Eune;
                case Platform.TR1:
                    return Region.Tr;
                case Platform.RU:
                    return Region.Ru;
                case Platform.EUW1:
                    return Region.Euw;
                case Platform.KR:
                    return Region.Kr;
                case Platform.JP1:
                    return Region.Jp;
                case Platform.NoPlatform:
                    return Region.NoRegion;
                default:
                    return Region.Na;
            }
        }
    }
}
