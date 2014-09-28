// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GameModeConverter.cs" company="">
//
// </copyright>
// <summary>
//   The game mode converter.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace RiotSharp
{
    /// <summary>
    /// The game mode converter.
    /// </summary>
    class GameModeConverter : JsonConverter
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
        public override object ReadJson(
            JsonReader reader,
            Type objectType,
            object existingValue,
            JsonSerializer serializer)
        {
            var token = JToken.Load(reader);
            if (token.Value<string>() != null)
            {
                var str = token.Value<string>();
                switch (str)
                {
                    case "CLASSIC":
                        return GameMode.Classic;
                    case "ODIN":
                        return GameMode.Dominion;
                    case "ARAM":
                        return GameMode.Aram;
                    case "TUTORIAL":
                        return GameMode.Tutorial;
                    case "ONEFORALL":
                        return GameMode.OneForAll;
                    case "FIRSTBLOOD":
                        return GameMode.FirstBlood;
                    case "ASCENSION":
                        return GameMode.Ascension;
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
            var mode = (GameMode)value;
            string result;
            switch (mode)
            {
                case GameMode.Classic:
                    result = "CLASSIC";
                    break;
                case GameMode.Aram:
                    result = "ARAM";
                    break;
                case GameMode.Dominion:
                    result = "ODIN";
                    break;
                case GameMode.FirstBlood:
                    result = "FIRSTBLOOD";
                    break;
                case GameMode.OneForAll:
                    result = "ONEFORALL";
                    break;
                case GameMode.Tutorial:
                    result = "TUTORIAL";
                    break;
                case GameMode.Ascension:
                    result = "ASCENSION";
                    break;
                default:
                    result = string.Empty;
                    break;
            }

            serializer.Serialize(writer, result);
        }
    }
}
