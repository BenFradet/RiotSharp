// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GameTypeConverter.cs" company="">
//
// </copyright>
// <summary>
//   The game type converter.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace RiotSharp
{
    /// <summary>
    /// The game type converter.
    /// </summary>
    class GameTypeConverter : JsonConverter
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
                    case "CUSTOM_GAME":
                        return GameType.CustomGame;
                    case "MATCHED_GAME":
                        return GameType.MatchedGame;
                    case "TUTORIAL_GAME":
                        return GameType.TutorialGame;
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
            var type = (GameType)value;
            string result;
            switch (type)
            {
                case GameType.CustomGame:
                    result = "CUSTOM_GAME";
                    break;
                case GameType.MatchedGame:
                    result = "MATCHED_GAME";
                    break;
                case GameType.TutorialGame:
                    result = "TUTORIAL_GAME";
                    break;
                default:
                    result = string.Empty;
                    break;
            }

            serializer.Serialize(writer, result);
        }
    }
}
