using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace RiotSharp.LeagueEndpoint
{
    class CharArrayConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(char[]).IsAssignableFrom(objectType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
            JsonSerializer serializer)
        {
            var token = JToken.Load(reader);
            return token.ToString().ToCharArray();
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
