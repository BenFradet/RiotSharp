using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace RiotSharp.MatchEndpoint
{
    class RoleConverter : JsonConverter
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
                case "DUO":
                    return Role.Duo;
                case "NONE":
                    return Role.None;
                case "SOLO":
                    return Role.Solo;
                case "DUO_CARRY":
                    return Role.DuoCarry;
                case "DUO_SUPPORT":
                    return Role.DuoSupport;
                default:
                    return null;
            }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, ((Role)value).ToCustomString());
        }
    }
}
