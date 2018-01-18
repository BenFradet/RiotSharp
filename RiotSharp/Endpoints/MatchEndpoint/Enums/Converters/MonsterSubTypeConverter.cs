using System;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace RiotSharp.Endpoints.MatchEndpoint.Enums.Converters
{
    class MonsterSubTypeConverter : JsonConverter
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
                case "AIR_DRAGON":
                    return MonsterSubType.AirDragon;
                case "WATER_DRAGON":
                    return MonsterSubType.WaterDragon;
                case "EARTH_DRAGON":
                    return MonsterSubType.EarthDragon;
                case "FIRE_DRAGON":
                    return MonsterSubType.FireDragon;
                case "ELDER_DRAGON":
                    return MonsterSubType.ElderDragon;
                default:
                    return null;
            }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, ((MonsterSubType)value).ToCustomString());
        }
    }
}
