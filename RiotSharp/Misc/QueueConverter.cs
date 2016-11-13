using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Reflection;

namespace RiotSharp
{
    class QueueConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(string).GetTypeInfo().IsAssignableFrom(objectType.GetTypeInfo());
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
                case "TEAM_BUILDER_DRAFT_RANKED_5x5":
                    return Queue.TeamBuilderDraftRanked5x5;
                case "TEAM_BUILDER_DRAFT_UNRANKED_5x5":
                    return Queue.TeamBuilderDraftUnranked5x5;
                case "RANKED_FLEX_SR":
                    return Queue.RankedFlexSR;
                case "RANKED_FLEX_TT":
                    return Queue.RankedFlexTT;
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
