using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace RiotSharp
{
    class DateTimeConverterFromString : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(string).IsAssignableFrom(objectType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
            JsonSerializer serializer)
        {
            var token = JToken.Load(reader);
            if (token.Value<string>() != null)
            {
                var str = token.Value<string>();
                return DateTime.Parse(str);
            }
            return null;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, ((DateTime)value).ToString("yyyy-MM-ddTHH:mm:ss.zzzZ"));
        }
    }
}
