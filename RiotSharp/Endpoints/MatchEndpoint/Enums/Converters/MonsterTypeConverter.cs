using System;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace RiotSharp.Endpoints.MatchEndpoint.Enums.Converters
{
    class MonsterTypeConverter : JsonConverter
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
                case "RIFTHERALD":
                    return MonsterType.RiftHerald;
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
