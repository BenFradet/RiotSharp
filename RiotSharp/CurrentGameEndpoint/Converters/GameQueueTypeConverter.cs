using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace RiotSharp.CurrentGameEndpoint.Converters
{
    class GameQueueTypeConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var subType = (GameQueueType)value;
            string result;
            switch (subType)
            {
                case GameQueueType.Custom:
                    result = "CUSTOM";
                    break;
                case GameQueueType.Normal5x5Blind:
                    result = "NORMAL_5x5_BLIND";
                    break;
                case GameQueueType.Bot5x5:
                    result = "BOT_5x5";
                    break;
                case GameQueueType.Bot5x5Intro:
                    result = "BOT_5x5_INTRO";
                    break;
                case GameQueueType.Bot5x5Beginner:
                    result = "BOT_5x5_BEGINNER";
                    break;
                case GameQueueType.Bot5x5Intermediate:
                    result = "BOT_5x5_INTERMEDIATE";
                    break;
                case GameQueueType.Normal3x3:
                    result = "NORMAL_3x3";
                    break;
                case GameQueueType.Normal5x5Draft:
                    result = "NORMAL_5x5_DRAFT";
                    break;
                case GameQueueType.Odin5x5Blind:
                    result = "ODIN_5x5_BLIND";
                    break;
                case GameQueueType.Odin5x5Draft:
                    result = "ODIN_5x5_DRAFT";
                    break;
                case GameQueueType.BotOdin5x5:
                    result = "BOT_ODIN_5x5";
                    break;
                case GameQueueType.RankedSolo5x5:
                    result = "RANKED_SOLO_5x5";
                    break;
                case GameQueueType.RankedPremade3x3:
                    result = "RANKED_PREMADE_3x3";
                    break;
                case GameQueueType.RankedPremade5x5:
                    result = "RANKED_PREMADE_5x5";
                    break;
                case GameQueueType.RankedTeam3x3:
                    result = "RANKED_TEAM_3x3";
                    break;
                case GameQueueType.RankedTeam5x5:
                    result = "RANKED_TEAM_5x5";
                    break;
                case GameQueueType.BotTt3x3:
                    result = "BOT_TT_3x3";
                    break;
                case GameQueueType.GroupFinder5x5:
                    result = "GROUP_FINDER_5x5";
                    break;
                case GameQueueType.Aram5x5:
                    result = "ARAM_5x5";
                    break;
                case GameQueueType.Oneforall5x5:
                    result = "ONEFORALL_5x5";
                    break;
                case GameQueueType.Firstblood1x1:
                    result = "FIRSTBLOOD_1x1";
                    break;
                case GameQueueType.Firstblood2x2:
                    result = "FIRSTBLOOD_2x2";
                    break;
                case GameQueueType.Sr6x6:
                    result = "SR_6x6";
                    break;
                case GameQueueType.Urf5x5:
                    result = "URF_5x5";
                    break;
                case GameQueueType.BotUrf5x5:
                    result = "BOT_URF_5x5";
                    break;
                case GameQueueType.NightmareBot5x5Rank1:
                    result = "NIGHTMARE_BOT_5x5_RANK1";
                    break;
                case GameQueueType.NightmareBot5x5Rank2:
                    result = "NIGHTMARE_BOT_5x5_RANK2";
                    break;
                case GameQueueType.NightmareBot5x5Rank5:
                    result = "NIGHTMARE_BOT_5x5_RANK5";
                    break;
                case GameQueueType.Ascension5x5:
                    result = "ASCENSION_5x5";
                    break;
                case GameQueueType.Hexakill:
                    result = "HEXAKILL";
                    break;
                case GameQueueType.BilgewaterAram5x5:
                    result = "BILGEWATER_ARAM_5x5";
                    break;
                case GameQueueType.KingPoro5x5:
                    result = "KING_PORO_5x5";
                    break;
                case GameQueueType.Bilgewater5x5:
                    result = "BILGEWATER_5x5";
                    break;
                default:
                    result = "";
                    break;
            }
            serializer.Serialize(writer, result);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var token = JToken.Load(reader);
            if (token.Value<string>() == null) return null;
            var str = token.Value<string>();
            switch (str)
            {
                case "CUSTOM":
                case "0":
                    return GameQueueType.Custom;
                case "NORMAL_5x5_BLIND":
                case "2":
                    return GameQueueType.Normal5x5Blind;
                case "BOT_5x5":
                case "7":
                    return GameQueueType.Bot5x5;
                case "BOT_5x5_INTRO":
                case "31":
                    return GameQueueType.Bot5x5Intro;
                case "BOT_5x5_BEGINNER":
                case "32":
                    return GameQueueType.Bot5x5Beginner;
                case "BOT_5x5_INTERMEDIATE":
                case "33":
                    return GameQueueType.Bot5x5Intermediate;
                case "NORMAL_3x3":
                case "8":
                    return GameQueueType.Normal3x3;
                case "NORMAL_5x5_DRAFT":
                case "14":
                    return GameQueueType.Normal5x5Draft;
                case "ODIN_5x5_BLIND":
                case "16":
                    return GameQueueType.Odin5x5Blind;
                case "ODIN_5x5_DRAFT":
                case "17":
                    return GameQueueType.Odin5x5Draft;
                case "BOT_ODIN_5x5":
                case "25":
                    return GameQueueType.BotOdin5x5;
                case "RANKED_SOLO_5x5":
                case "4":
                    return GameQueueType.RankedSolo5x5;
                case "RANKED_PREMADE_3x3":
                case "9":
                    return GameQueueType.RankedPremade3x3;
                case "RANKED_PREMADE_5x5":
                case "6":
                    return GameQueueType.RankedPremade5x5;
                case "RANKED_TEAM_3x3":
                case "41":
                    return GameQueueType.RankedTeam3x3;
                case "RANKED_TEAM_5x5":
                case "42":
                    return GameQueueType.RankedTeam5x5;
                case "BOT_TT_3x3":
                case "52":
                    return GameQueueType.BotTt3x3;
                case "GROUP_FINDER_5x5":
                case "61":
                    return GameQueueType.GroupFinder5x5;
                case "ARAM_5x5":
                case "65":
                    return GameQueueType.Aram5x5;
                case "ONEFORALL_5x5":
                case "70":
                    return GameQueueType.Oneforall5x5;
                case "FIRSTBLOOD_1x1":
                case "72":
                    return GameQueueType.Firstblood1x1;
                case "FIRSTBLOOD_2x2":
                case "73":
                    return GameQueueType.Firstblood2x2;
                case "SR_6x6":
                case "75":
                    return GameQueueType.Sr6x6;
                case "URF_5x5":
                case "76":
                    return GameQueueType.Urf5x5;
                case "BOT_URF_5x5":
                case "83":
                    return GameQueueType.BotUrf5x5;
                case "NIGHTMARE_BOT_5x5_RANK1":
                case "91":
                    return GameQueueType.NightmareBot5x5Rank1;
                case "NIGHTMARE_BOT_5x5_RANK2":
                case "92":
                    return GameQueueType.NightmareBot5x5Rank2;
                case "NIGHTMARE_BOT_5x5_RANK5":
                case "93":
                    return GameQueueType.NightmareBot5x5Rank5;
                case "ASCENSION_5x5":
                case "96":
                    return GameQueueType.Ascension5x5;
                case "HEXAKILL":
                case "98":
                    return GameQueueType.Hexakill;
                case "BILGEWATER_ARAM_5x5":
                case "100":
                    return GameQueueType.BilgewaterAram5x5;
                case "KING_PORO_5x5":
                case "300":
                    return GameQueueType.KingPoro5x5;
                case "BILGEWATER_5x5":
                case "313":
                    return GameQueueType.Bilgewater5x5;
                default:
                    return null;
            }
        }

        public override bool CanConvert(Type objectType)
        {
            return typeof(string).IsAssignableFrom(objectType);
        }
    }
}
