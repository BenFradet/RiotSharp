using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace RiotSharp.StatsEndpoint
{
    class PlayerStatsSummaryTypeConverter : JsonConverter
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
                case "AramUnranked5x5":
                    return PlayerStatsSummaryType.AramUnranked5x5;
                case "CAP5x5":
                    return PlayerStatsSummaryType.CAP5x5;
                case "CoopVsAI":
                    return PlayerStatsSummaryType.CoopVsAI;
                case "CoopVsAI3x3":
                    return PlayerStatsSummaryType.CoopVsAI3x3;
                case "OdinUnranked":
                    return PlayerStatsSummaryType.OdinUnranked;
                case "RankedPremade3x3":
                    return PlayerStatsSummaryType.RankedPremade3x3;
                case "RankedPremade5x5":
                    return PlayerStatsSummaryType.RankedPremade5x5;
                case "RankedSolo5x5":
                    return PlayerStatsSummaryType.RankedSolo5x5;
                case "RankedTeam3x3":
                    return PlayerStatsSummaryType.RankedTeam3x3;
                case "RankedTeam5x5":
                    return PlayerStatsSummaryType.RankedTeam5x5;
                case "Unranked":
                    return PlayerStatsSummaryType.Unranked;
                case "Unranked3x3":
                    return PlayerStatsSummaryType.Unranked3x3;
                case "OneForAll5x5":
                    return PlayerStatsSummaryType.OneForAll5x5;
                case "FirstBlood1x1":
                    return PlayerStatsSummaryType.FirstBlood1x1;
                case "FirstBlood2x2":
                    return PlayerStatsSummaryType.FirstBlood2x2;
                case "SummonersRift6x6":
                    return PlayerStatsSummaryType.SummonersRift6x6;
                case "URF":
                    return PlayerStatsSummaryType.URF;
                case "URFBots":
                    return PlayerStatsSummaryType.URFBots;
                case "NightmareBot":
                    return PlayerStatsSummaryType.NightmareBot;
                case "Ascension":
                    return PlayerStatsSummaryType.Ascension;
                case "Hexakill":
                    return PlayerStatsSummaryType.Hexakill;
                case "KingPoro":
                    return PlayerStatsSummaryType.KingPoro;
                case "CounterPick":
                    return PlayerStatsSummaryType.CounterPick;
                default:
                    return null;
            }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, ((PlayerStatsSummaryType)value).ToString());
        }
    }
}
