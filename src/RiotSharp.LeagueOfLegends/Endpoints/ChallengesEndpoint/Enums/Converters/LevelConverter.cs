using RiotSharp.LeagueOfLegends.Endpoints.ChallengesEndpoint.Enums;
using RiotSharp.LeagueOfLegends.Endpoints.ClashEndpoint.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RiotSharp.LeagueOfLegends.Endpoints.ChallengesEndpoint.Enums.Converters
{
    public class LevelConverter : JsonConverter<Level>
    {
        public override Level Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var value = reader.GetString();
            return ParseLevel(value);
        }

        public override void Write(Utf8JsonWriter writer, Level value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToCustomString());
        }

        // Required for dictionary key deserialization
        public override Level ReadAsPropertyName(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var value = reader.GetString();
            return ParseLevel(value);
        }

        // Required for dictionary key serialization
        public override void WriteAsPropertyName(Utf8JsonWriter writer, Level value, JsonSerializerOptions options)
        {
            writer.WritePropertyName(value.ToCustomString());
        }

        private static Level ParseLevel(string? value)
        {
            switch (value)
            {
                case "IRON":
                    return Level.Iron;
                case "BRONZE":
                    return Level.Bronze;
                case "SILVER":
                    return Level.Silver;
                case "GOLD":
                    return Level.Gold;
                case "PLATINUM":
                    return Level.Platinum;
                case "DIAMOND":
                    return Level.Diamond;
                case "MASTER":
                    return Level.Master;
                case "GRANDMASTER":
                    return Level.Grandmaster;
                case "CHALLENGER":
                    return Level.Challenger;
                case "HIGHEST_NOT_LEADERBOARD_ONLY":
                    return Level.HighestNotLeaderboardOnly;
                case "HIGHEST":
                    return Level.Highest;
                case "LOWEST":
                    return Level.Lowest;
            }

            // Default fallback
            return Level.None;
        }
    }
}