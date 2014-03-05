using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace RiotSharp
{
    class GameSubTypeConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(string).IsAssignableFrom(objectType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var token = JToken.Load(reader);
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
                case "SR_6x6":
                    return GameSubType.Hexakill;
                default:
                    return null;
            }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
