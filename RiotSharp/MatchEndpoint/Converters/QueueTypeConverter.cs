﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="QueueTypeConverter.cs" company="">
//   
// </copyright>
// <summary>
//   The queue type converter.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace RiotSharp.MatchEndpoint
{
    /// <summary>
    /// The queue type converter.
    /// </summary>
    class QueueTypeConverter : JsonConverter
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
                    case "CUSTOM":
                        return QueueType.Custom;
                    case "NORMAL_5x5_BLIND":
                        return QueueType.Normal5x5Blind;
                    case "RANKED_SOLO_5x5":
                        return QueueType.RankedSolo5x5;
                    case "RANKED_PREMADE_5x5":
                        return QueueType.RankedPremade5x5;
                    case "BOT_5x5":
                        return QueueType.Bot5x5;
                    case "NORMAL_3x3":
                        return QueueType.Normal3x3;
                    case "RANKED_PREMADE_3x3":
                        return QueueType.RankedPremade3x3;
                    case "NORMAL_5x5_DRAFT":
                        return QueueType.Normal5x5Draft;
                    case "ODIN_5x5_BLIND":
                        return QueueType.Odin5x5Blind;
                    case "ODIN_5x5_DRAFT":
                        return QueueType.Odin5x5Draft;
                    case "BOT_ODIN_5x5":
                        return QueueType.BotOdin5x5;
                    case "BOT_5x5_INTRO":
                        return QueueType.Bot5x5Intro;
                    case "BOT_5x5_BEGINNER":
                        return QueueType.Bot5x5Beginner;
                    case "BOT_5x5_INTERMEDIATE":
                        return QueueType.Bot5x5Intermediate;
                    case "RANKED_TEAM_3x3":
                        return QueueType.RankedTeam3x3;
                    case "RANKED_TEAM_5x5":
                        return QueueType.RankedTeam5x5;
                    case "BOT_TT_3x3":
                        return QueueType.BotTt3x3;
                    case "GROUP_FINDER_5x5":
                        return QueueType.GroupFinder5x5;
                    case "ARAM_5x5":
                        return QueueType.Aram5x5;
                    case "ONEFORALL_5x5":
                        return QueueType.OneForAll5x5;
                    case "FIRSTBLOOD_1x1":
                        return QueueType.FirstBlood1x1;
                    case "FIRSTBLOOD_2x2":
                        return QueueType.FirstBlood2x2;
                    case "SR_6x6":
                        return QueueType.Sr6x6;
                    case "URF_5x5":
                        return QueueType.Urf5x5;
                    case "BOT_URF_5x5":
                        return QueueType.BotUrf5x5;
                    case "NIGHTMARE_BOT_5x5_RANK1":
                        return QueueType.NightmareBot5x5Rank1;
                    case "NIGHTMARE_BOT_5x5_RANK2":
                        return QueueType.NightmareBot5x5Rank2;
                    case "NIGHTMARE_BOT_5x5_RANK5":
                        return QueueType.NightmareBot5x5Rank5;
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
            serializer.Serialize(writer, ((QueueType)value).ToCustomString());
        }
    }
}
