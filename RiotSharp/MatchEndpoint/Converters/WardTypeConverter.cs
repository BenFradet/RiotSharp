using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace RiotSharp.MatchEndpoint
{
    class WardTypeConverter : JsonConverter
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
                case "SIGHT_WARD":
                    return WardType.SightWard;
                case "TEEMO_MUSHROOM":
                    return WardType.TeemoMushroom;
                case "UNDEFINED":
                    return WardType.Undefined;
                case "VISION_WARD":
                    return WardType.VisionWard;
                case "YELLOW_TRINKET":
                    return WardType.YellowTrinket;
                case "YELLOW_TRINKET_UPGRADE":
                    return WardType.YellowTrinketUpgrade;
                default:
                    return null;
            }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, ((WardType)value).ToCustomString());
        }
    }
}
