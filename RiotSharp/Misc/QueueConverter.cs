using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace RiotSharp
{
    class QueueConverter : JsonConverter
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
                case "RANKED_SOLO_5x5":
                    return Queue.RankedSolo5x5;
                case "RANKED_TEAM_3x3":
                    return Queue.RankedTeam3x3;
                case "RANKED_TEAM_5x5":
                    return Queue.RankedTeam5x5;
                default:
                    return null;
            }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, ((Queue)value).ToCustomString());
        }
    }
}
