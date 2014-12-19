using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace RiotSharp.MatchEndpoint
{
    class MonsterTypeConverter : JsonConverter
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
                case "BARON_NASHOR":
                    return MonsterType.BaronNashor;
                case "BLUE_GOLEM":
                    return MonsterType.BlueGolem;
                case "DRAGON":
                    return MonsterType.Dragon;
                case "RED_LIZARD":
                    return MonsterType.RedLizard;
                case "VILEMAW":
                    return MonsterType.Vilemaw;
                default:
                    return null;
            }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, ((MonsterType)value).ToCustomString());
        }
    }
}
