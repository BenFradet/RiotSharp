// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TimeSpanConverterFromMS.cs" company="">
//   
// </copyright>
// <summary>
//   The time span converter from ms.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace RiotSharp
{
    /// <summary>
    /// The time span converter from ms.
    /// </summary>
    class TimeSpanConverterFromMS : JsonConverter
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
            return objectType == typeof(long);
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
            if (token.Value<long?>() != null)
            {
                return TimeSpan.FromMilliseconds(token.Value<long>());
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
            serializer.Serialize(writer, (long)((TimeSpan)value).TotalMilliseconds);
        }
    }
}
