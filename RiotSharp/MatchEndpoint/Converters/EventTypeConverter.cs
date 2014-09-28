// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EventTypeConverter.cs" company="">
//
// </copyright>
// <summary>
//   The event type converter.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace RiotSharp.MatchEndpoint
{
    /// <summary>
    /// The event type converter.
    /// </summary>
    class EventTypeConverter : JsonConverter
    {
        /// <summary>
        /// The can convert.
        /// </summary>
        /// <param name="objectType">
        /// The object type.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public override bool CanConvert(Type objectType)
        {
            return typeof(string).IsAssignableFrom(objectType);
        }

        /// <summary>
        /// The read json.
        /// </summary>
        /// <param name="reader">
        /// The reader.
        /// </param>
        /// <param name="objectType">
        /// The object type.
        /// </param>
        /// <param name="existingValue">
        /// The existing value.
        /// </param>
        /// <param name="serializer">
        /// The serializer.
        /// </param>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
            JsonSerializer serializer)
        {
            var token = JToken.Load(reader);
            if (token.Value<string>() != null)
            {
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

            return null;
        }

        /// <summary>
        /// The write json.
        /// </summary>
        /// <param name="writer">
        /// The writer.
        /// </param>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <param name="serializer">
        /// The serializer.
        /// </param>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, ((EventType)value).ToCustomString());
        }
    }
}
