using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace RiotSharp
{
    class GameTypeConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(string).IsAssignableFrom(objectType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
            JsonSerializer serializer)
        {
            var token = JToken.Load(reader);
            if (token.Value<string>() == null) return null;
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
                    result = "";
                    break;
            }
            serializer.Serialize(writer, result);
        }
    }
}
