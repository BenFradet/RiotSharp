using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace RiotSharp.MatchEndpoint
{
    class CapturePointConverter : JsonConverter
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
                case "POINT_A":
                    return CapturePoint.PointA;
                case "POINT_B":
                    return CapturePoint.PointB;
                case "POINT_C":
                    return CapturePoint.PointC;
                case "POINT_D":
                    return CapturePoint.PointD;
                case "POINT_E":
                    return CapturePoint.PointE;
                default:
                    return null;
            }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, ((CapturePoint)value).ToCustomString());
        }
    }
}
