// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BuildingTypeConverter.cs" company="">
//   
// </copyright>
// <summary>
//   The building type converter.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace RiotSharp.MatchEndpoint
{
    /// <summary>
    /// The building type converter.
    /// </summary>
    class BuildingTypeConverter : JsonConverter
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
                    case "INHIBITOR_BUILDING":
                        return BuildingType.InhibitorBuilding;
                    case "TOWER_BUILDING":
                        return BuildingType.TowerBuilding;
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
            serializer.Serialize(writer, ((BuildingType)value).ToCustomString());
        }
    }
}
