using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace RiotSharp
{
    class GameModeConverter : JsonConverter
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
                case "INTRO":
                    return GameMode.Intro;
                case "KINGPORO":
                    return GameMode.KingPoro;
                default:
                    return null;
            }
        }

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
                case GameMode.Intro:
                    result = "INTRO";
                    break;
                case GameMode.KingPoro:
                    result = "KINGPORO";
                    break;
                default:
                    result = string.Empty;
                    break;
            }
            serializer.Serialize(writer, result);
        }
    }
}
