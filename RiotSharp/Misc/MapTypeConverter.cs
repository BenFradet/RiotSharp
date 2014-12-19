using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace RiotSharp
{
    public class MapTypeConverter : JsonConverter
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
            return (MapType)(Enum.Parse(typeof(MapType), str));
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            string result = ((int)value).ToString();
            serializer.Serialize(writer, result);
        }
    }
}
