﻿using System;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace RiotSharp.Endpoints.MatchEndpoint.Enums.Converters
{
    class BuildingTypeConverter : JsonConverter
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
                case "INHIBITOR_BUILDING":
                    return BuildingType.InhibitorBuilding;
                case "TOWER_BUILDING":
                    return BuildingType.TowerBuilding;
                default:
                    return null;
            }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, ((BuildingType)value).ToCustomString());
        }
    }
}
