using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace RiotSharp.MatchEndpoint
{
    class LevelUpTypeConverter : JsonConverter
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
                case "EVOLVE":
                    return LevelUpType.Evolve;
                case "NORMAL":
                    return LevelUpType.Normal;
                default:
                    return null;
            }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, ((LevelUpType)value).ToCustomString());
        }
    }
}
