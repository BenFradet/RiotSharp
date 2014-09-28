// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ParTypeStaticConverter.cs" company="">
//
// </copyright>
// <summary>
//   The par type static converter.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace RiotSharp.StaticDataEndpoint
{
    /// <summary>
    /// The par type static converter.
    /// </summary>
    class ParTypeStaticConverter : JsonConverter
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
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var token = JToken.Load(reader);
            if (token.Value<string>() != null)
            {
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
            string result = ((ParTypeStatic)value).ToString();
            serializer.Serialize(writer, result);
        }
    }
}
