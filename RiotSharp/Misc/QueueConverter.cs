// --------------------------------------------------------------------------------------------------------------------
// <copyright file="QueueConverter.cs" company="">
//   
// </copyright>
// <summary>
//   The queue converter.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace RiotSharp
{
    /// <summary>
    /// The queue converter.
    /// </summary>
    class QueueConverter : JsonConverter
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
                    case "RANKED_SOLO_5x5":
                        return Queue.RankedSolo5x5;
                    case "RANKED_TEAM_3x3":
                        return Queue.RankedTeam3x3;
                    case "RANKED_TEAM_5x5":
                        return Queue.RankedTeam5x5;
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
            serializer.Serialize(writer, ((Queue)value).ToCustomString());
        }
    }
}
