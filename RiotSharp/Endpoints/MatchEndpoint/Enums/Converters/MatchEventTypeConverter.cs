﻿using System;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace RiotSharp.Endpoints.MatchEndpoint.Enums.Converters
{
    class MatchEventTypeConverter : JsonConverter
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
                case "ASCENDED_EVENT":
                    return MatchEventType.AscendedEvent;
                case "BUILDING_KILL":
                    return MatchEventType.BuildingKill;
                case "CAPTURE_POINT":
                    return MatchEventType.CapturePoint;
                case "CHAMPION_KILL":
                    return MatchEventType.ChampionKill;
                case "CHAMPION_SPECIAL_KILL":
                    return MatchEventType.ChampionSpecialKill;
                case "CHAMPION_TRANSFORM":
                    return MatchEventType.ChampionTransform;
                case "DRAGON_SOUL_GIVEN":
                    return MatchEventType.DragonSoulGiven;
                case "ELITE_MONSTER_KILL":
                    return MatchEventType.EliteMonsterKill;
                case "GAME_END":
                    return MatchEventType.GameEnd;
                case "ITEM_DESTROYED":
                    return MatchEventType.ItemDestroyed;
                case "ITEM_PURCHASED":
                    return MatchEventType.ItemPurchased;
                case "ITEM_SOLD":
                    return MatchEventType.ItemSold;
                case "ITEM_UNDO":
                    return MatchEventType.ItemUndo;
                case "LEVEL_UP":
                    return MatchEventType.LevelUp;
                case "PAUSE_END":
                    return MatchEventType.PauseEnd;
                case "PAUSE_START":
                    return MatchEventType.PauseStart;
                case "SKILL_LEVEL_UP":
                    return MatchEventType.SkillLevelUp;
                case "TURRET_PLATE_DESTROYED":
                    return MatchEventType.TurretPlateDestroyed;
                case "WARD_KILL":
                    return MatchEventType.WardKill;
                case "WARD_PLACED":
                    return MatchEventType.WardPlaced;
                default:
                    return null;
            }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, ((MatchEventType)value).ToCustomString());
        }
    }
}
