using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace RiotSharp.MatchEndpoint
{
    class EventTypeConverter : JsonConverter
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
                case "ASCENDED_EVENT":
                    return EventType.AscendedEvent;
                case "BUILDING_KILL":
                    return EventType.BuildingKill;
                case "CAPTURE_POINT":
                    return EventType.CapturePoint;
                case "CHAMPION_KILL":
                    return EventType.ChampionKill;
                case "ELITE_MONSTER_KILL":
                    return EventType.EliteMonsterKill;
                case "ITEM_DESTROYED":
                    return EventType.ItemDestroyed;
                case "ITEM_PURCHASED":
                    return EventType.ItemPurchased;
                case "ITEM_SOLD":
                    return EventType.ItemSold;
                case "ITEM_UNDO":
                    return EventType.ItemUndo;
                case "SKILL_LEVEL_UP":
                    return EventType.SkillLevelUp;
                case "WARD_KILL":
                    return EventType.WardKill;
                case "WARD_PLACED":
                    return EventType.WardPlaced;
                default:
                    return null;
            }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, ((EventType)value).ToCustomString());
        }
    }
}
