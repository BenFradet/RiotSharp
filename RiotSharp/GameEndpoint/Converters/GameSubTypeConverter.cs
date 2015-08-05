using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace RiotSharp.GameEndpoint
{
    class GameSubTypeConverter : JsonConverter
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
                case "NONE":
                    return GameSubType.None;
                case "NORMAL":
                    return GameSubType.Normal;
                case "BOT":
                    return GameSubType.Bot;
                case "RANKED_SOLO_5x5":
                    return GameSubType.RankedSolo5x5;
                case "RANKED_PREMADE_3x3":
                    return GameSubType.RankedPremade3x3;
                case "RANKED_PREMADE_5x5":
                    return GameSubType.RankedPremade5x5;
                case "ODIN_UNRANKED":
                    return GameSubType.OdinUnranked;
                case "RANKED_TEAM_3x3":
                    return GameSubType.RankedTeam3x3;
                case "RANKED_TEAM_5x5":
                    return GameSubType.RankedTeam5x5;
                case "NORMAL_3x3":
                    return GameSubType.Normal3x3;
                case "BOT_3x3":
                    return GameSubType.Bot3x3;
                case "ARAM_UNRANKED_5x5":
                    return GameSubType.AramUnranked5x5;
                case "ONEFORALL_5x5":
                    return GameSubType.OneForAll5x5;
                case "FIRSTBLOOD_1x1":
                    return GameSubType.FirstBlood1x1;
                case "FIRSTBLOOD_2x2":
                    return GameSubType.FirstBlood2x2;
                case "HEXAKILL":
                    return GameSubType.Hexakill;
                case "CAP_5x5":
                    return GameSubType.TeamBuilder5x5;
                case "URF":
                    return GameSubType.URF;
                case "URF_BOT":
                    return GameSubType.URF_BOT;
                case "NIGHTMARE_BOT":
                    return GameSubType.NightmareBot;
                case "ASCENSION":
                    return GameSubType.Ascension;
                case "KING_PORO":
                    return GameSubType.KingPoro;
                case "COUNTER_PICK":
                    return GameSubType.CounterPick;
                case "BILGEWATER":
                    return GameSubType.Bilgewater;
                default:
                    return null;
            }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var subType = (GameSubType)value;
            string result;
            switch (subType)
            {
                case GameSubType.AramUnranked5x5:
                    result = "ARAM_UNRANKED_5x5";
                    break;
                case GameSubType.Bot:
                    result = "BOT";
                    break;
                case GameSubType.Bot3x3:
                    result = "BOT_3x3";
                    break;
                case GameSubType.FirstBlood1x1:
                    result = "FIRSTBLOOD_1x1";
                    break;
                case GameSubType.FirstBlood2x2:
                    result = "FIRSTBLOOD_2x2";
                    break;
                case GameSubType.Hexakill:
                    result = "HEXAKILL";
                    break;
                case GameSubType.None:
                    result = "NONE";
                    break;
                case GameSubType.Normal:
                    result = "NORMAL";
                    break;
                case GameSubType.Normal3x3:
                    result = "NORMAL_3x3";
                    break;
                case GameSubType.OdinUnranked:
                    result = "ODIN_UNRANKED";
                    break;
                case GameSubType.OneForAll5x5:
                    result = "ONEFORALL_5x5";
                    break;
                case GameSubType.RankedPremade3x3:
                    result = "RANKED_PREMADE_3x3";
                    break;
                case GameSubType.RankedPremade5x5:
                    result = "RANKED_PREMADE_5x5";
                    break;
                case GameSubType.RankedSolo5x5:
                    result = "RANKED_SOLO_5x5";
                    break;
                case GameSubType.RankedTeam3x3:
                    result = "RANKED_TEAM_3x3";
                    break;
                case GameSubType.RankedTeam5x5:
                    result = "RANKED_TEAM_5x5";
                    break;
                case GameSubType.TeamBuilder5x5:
                    result = "CAP_5x5";
                    break;
                case GameSubType.URF:
                    result = "URF";
                    break;
                case GameSubType.URF_BOT:
                    result = "URF_BOT";
                    break;
                case GameSubType.NightmareBot:
                    result = "NIGHTMARE_BOT";
                    break;
                case GameSubType.Ascension:
                    result = "ASCENSION";
                    break;
                case GameSubType.KingPoro:
                    result = "KING_PORO";
                    break;
                case GameSubType.CounterPick:
                    result = "COUNTER_PICK";
                    break;
                case GameSubType.Bilgewater:
                    result = "BILGEWATER";
                    break;
                default:
                    result = "";
                    break;
            }
            serializer.Serialize(writer, result);
        }
    }
}
