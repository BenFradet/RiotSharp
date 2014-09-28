// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TagStaticConverter.cs" company="">
//
// </copyright>
// <summary>
//   The tag static converter.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace RiotSharp.StaticDataEndpoint
{
    /// <summary>
    /// The tag static converter.
    /// </summary>
    class TagStaticConverter : JsonConverter
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
            return typeof(List<string>).IsAssignableFrom(objectType);
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
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue
            , JsonSerializer serializer)
        {
            var token = JToken.Load(reader);
            if (token.Values<string>() != null)
            {
                var list = token.Values<string>();
                var tags = new List<TagStatic>();
                foreach (var str in list)
                {
                    switch (str)
                    {
                        case "Fighter":
                            tags.Add(TagStatic.Fighter);
                            break;
                        case "Tank":
                            tags.Add(TagStatic.Tank);
                            break;
                        case "Mage":
                            tags.Add(TagStatic.Mage);
                            break;
                        case "Assassin":
                            tags.Add(TagStatic.Assassin);
                            break;
                        case "Support":
                            tags.Add(TagStatic.Support);
                            break;
                        case "Marksman":
                            tags.Add(TagStatic.Marksman);
                            break;
                    }
                }

                return tags;
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
            var list = new List<string>();
            foreach (var tag in (List<TagStatic>)value)
            {
                list.Add(tag.ToString());
            }

            serializer.Serialize(writer, list);
        }
    }
}
