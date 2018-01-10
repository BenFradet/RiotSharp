using System;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace RiotSharp.Endpoints.TournamentEndpoint.Enums.Converters
{
    internal class TournamentMapTypeConverter : JsonConverter
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
                case "SUMMONERS_RIFT":
                    return TournamentMapType.SummonersRift;
                case "TWISTED_TREELINE":
                    return TournamentMapType.TwistedTreeline;
                case "CRYSTAL_SCAR":
                    return TournamentMapType.CrystalScar;
                case "HOWLING_ABYSS":
                    return TournamentMapType.HowlingAbyss;
                default:
                    return null;
            }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var map = (TournamentMapType) value;
            string result;
            switch (map)
            {
                case TournamentMapType.SummonersRift:
                    result = "SUMMONERS_RIFT";
                    break;
                case TournamentMapType.TwistedTreeline:
                    result = "TWISTED_TREELINE";
                    break;
                case TournamentMapType.CrystalScar:
                    result = "CRYSTAL_SCAR";
                    break;
                case TournamentMapType.HowlingAbyss:
                    result = "HOWLING_ABYSS";
                    break;
                default:
                    result = string.Empty;
                    break;
            }
            serializer.Serialize(writer, result);
        }
    }
}
