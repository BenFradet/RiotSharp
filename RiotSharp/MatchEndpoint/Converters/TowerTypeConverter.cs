using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace RiotSharp.MatchEndpoint
{
    class TowerTypeConverter : JsonConverter
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
                case "BASE_TURRET":
                    return TowerType.BaseTurret;
                case "INNER_TURRET":
                    return TowerType.InnerTurret;
                case "NEXUS_TURRET":
                    return TowerType.NexusTurret;
                case "OUTER_TURRET":
                    return TowerType.OuterTurret;
                case "UNDEFINED_TURRET":
                    return TowerType.UndefinedTurret;
                default:
                    return null;
            }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, ((TowerType)value).ToCustomString());
        }
    }
}
