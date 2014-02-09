using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace RiotSharp
{
    class MiniSeriesConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(MiniSeries).IsAssignableFrom(objectType);
        }

        public override object ReadJson(JsonReader reader, Type objectType
            , object existingValue, JsonSerializer serializer)
        {
            var token = JToken.Load(reader);
            return new MiniSeries(token);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
