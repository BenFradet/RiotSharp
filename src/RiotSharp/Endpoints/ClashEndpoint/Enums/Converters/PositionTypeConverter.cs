using System;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace RiotSharp.Endpoints.ClashEndpoint.Enums.Converters
{
    public class PositionTypeConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, ((PositionType)value).ToCustomString());
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var token = JToken.Load(reader);
            var value = token.Value<string>();

            switch (value)
            {
                case "UNSELECTED":
                    return PositionType.Unselected;
                case "FILL":
                    return PositionType.Unselected;
                case "TOP":
                    return PositionType.Top;
                case "JUNGLE":
                    return PositionType.Jungle;
                case "MIDDLE":
                    return PositionType.Middle;
                case "BOTTOM":
                    return PositionType.Bottom;
                case "UTILITY":
                    return PositionType.Utility;
            }

            return null;
        }

        public override bool CanConvert(Type objectType)
        {
            return typeof(string).GetTypeInfo().IsAssignableFrom(objectType.GetTypeInfo());
        }
    }
}