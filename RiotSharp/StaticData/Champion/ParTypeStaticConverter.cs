using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace RiotSharp
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
            var str = token.Value<string>();
            switch (str)
            {
                case "BloodWell":
                    return ParTypeStatic.BloodWell;
                case "Mana":
                    return ParTypeStatic.Mana;
                case "Energy":
                    return ParTypeStatic.Energy;
                case "None":
                    return ParTypeStatic.None;
                case "Shield":
                    return ParTypeStatic.Shield;
                case "Rage":
                    return ParTypeStatic.Rage;
                case "Ferocity":
                    return ParTypeStatic.Ferocity;
                case "Heat":
                    return ParTypeStatic.Heat;
                case "Dragonfury":
                    return ParTypeStatic.Dragonfury;
                case "Battlefury":
                    return ParTypeStatic.Battlefury;
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
