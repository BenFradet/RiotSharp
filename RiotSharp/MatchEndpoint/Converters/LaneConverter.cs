using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace RiotSharp.MatchEndpoint
{
    class LaneConverter : JsonConverter
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
                case "MID":
                    return Lane.Mid;
                case "MIDDLE":
                    return Lane.Middle;
                case "TOP":
                    return Lane.Top;
                case "JUNGLE":
                    return Lane.Jungle;
                case "BOT":
                    return Lane.Bot;
                case "BOTTOM":
                    return Lane.Bottom;
                default:
                    return null;
            }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, ((Lane)value).ToCustomString());
        }
    }
}
