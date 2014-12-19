using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace RiotSharp.StaticDataEndpoint
{
    class ParTypeStaticConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(string).IsAssignableFrom(objectType);
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
                case "None":
                    return ParTypeStatic.None;
                case "Rage":
                    return ParTypeStatic.Rage;
                case "Shield":
                    return ParTypeStatic.Shield;
                case "Wind":
                    return ParTypeStatic.Wind;
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
