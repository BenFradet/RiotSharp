using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace RiotSharp
{
    public class GameModeConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(String).IsAssignableFrom(objectType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var token = JToken.Load(reader);
            var str = token.Value<String>();
            switch (str)
            {
                case "CLASSIC":
                    return GameMode.CLASSIC;
                case "ODIN":
                    return GameMode.ODIN;
                case "ARAM":
                    return GameMode.ARAM;
                case "TUTORIAL":
                    return GameMode.TUTORIAL;
                default:
                    return null;
            }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
