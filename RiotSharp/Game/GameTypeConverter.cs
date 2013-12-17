using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace RiotSharp
{
    public class GameTypeConverter : JsonConverter
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
                case "CUSTOM_GAME":
                    return GameType.CUSTOM_GAME;
                case "MATCHED_GAME":
                    return GameType.MATCHED_GAME;
                case "CO_OP_VS_AI_GAME":
                    return GameType.CO_OP_VS_AI_GAME;
                case "TUTORIAL_GAME":
                    return GameType.TUTORIAL_GAME;
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
