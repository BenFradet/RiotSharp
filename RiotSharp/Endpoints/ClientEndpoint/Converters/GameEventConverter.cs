using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RiotSharp.Endpoints.ClientEndpoint.Enums;

namespace RiotSharp.Endpoints.ClientEndpoint.Converters
{
    public class GameEventConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            // taken from https://blog.mbwarez.dk/deserializing-different-types-based-on-properties-with-newtonsoft-json/
            var jsonObject = JToken.ReadFrom(reader);
            // var eventType = JsonConvert.DeserializeObject<GameEventType>(jsonObject["EventName"].Value<string>(), new StringEnumConverter());
            var eventType = jsonObject["EventName"].ToObject<GameEventType>();

            var result = eventType.CreateGameEvent();
            serializer.Populate(jsonObject.CreateReader(), result);
            return result;
        }

        public override bool CanConvert(Type objectType)
        {
            return true;
        }
    }
}