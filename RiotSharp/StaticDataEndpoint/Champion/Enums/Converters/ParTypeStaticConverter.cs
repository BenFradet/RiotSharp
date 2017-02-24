﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Reflection;

namespace RiotSharp.StaticDataEndpoint.Champion.Enums.Converters
{
    class ParTypeStaticConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(string).GetTypeInfo().IsAssignableFrom(objectType.GetTypeInfo());
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var token = JToken.Load(reader);
            if (token.Value<string>() == null) return null;
            var str = token.Value<string>();
            switch (str)
            {
                case "Battlefury":
                    return ParTypeStatic.Battlefury;
                case "BloodWell":
                case "Blood Well":
                    return ParTypeStatic.BloodWell;
                case "Dragonfury":
                    return ParTypeStatic.Dragonfury;
                case "Energy":
                    return ParTypeStatic.Energy;
                case "Ferocity":
                    return ParTypeStatic.Ferocity;
                case "Gnarfury":
                    return ParTypeStatic.Gnarfury;
                case "Heat":
                    return ParTypeStatic.Heat;
                case "Mana":
                    return ParTypeStatic.Mana;
                case "MP":
                    return ParTypeStatic.MP;
                case "None":
                    return ParTypeStatic.None;
                case "Rage":
                    return ParTypeStatic.Rage;
                case "Shield":
                    return ParTypeStatic.Shield;
                case "Wind":
                    return ParTypeStatic.Wind;
                case "Courage":
                    return ParTypeStatic.Courage;
                case "Crimson Rush":
                    return ParTypeStatic.CrimsonRush;
                case "Flow":
                    return ParTypeStatic.Flow;
                case "Fury":
                    return ParTypeStatic.Fury;
                default:
                    return null;
            }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            string result = ((ParTypeStatic)value).ToString();
            serializer.Serialize(writer, result);
        }
    }
}
