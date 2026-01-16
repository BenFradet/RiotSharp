using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace RiotSharp.LeagueOfLegends.Misc.Converters
{
    public class GameModeConverter : JsonConverter<GameMode>
    {
        public override GameMode Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var value = reader.GetString();
            return ParseGameMode(value);
        }

        public override void Write(Utf8JsonWriter writer, GameMode value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToCustomString());
        }

        private static GameMode ParseGameMode(string? value)
        {
            return value switch
            {
                "CLASSIC" => GameMode.Classic,
                "ODIN" => GameMode.Odin,
                "ARAM" => GameMode.Aram,
                "TUTORIAL" => GameMode.Tutorial,
                "URF" => GameMode.Urf,
                "DOOMBOTSTEEMO" => GameMode.DoomBotsTeemo,
                "ONEFORALL" => GameMode.OneForAll,
                "ASCENSION" => GameMode.Ascension,
                "FIRSTBLOOD" => GameMode.FirstBlood,
                "KINGPORO" => GameMode.KingPoro,
                "SIEGE" => GameMode.Siege,
                "ASSASSINATE" => GameMode.Assassinate,
                "ARSR" => GameMode.Arsr,
                "DARKSTAR" => GameMode.Darkstar,
                "STARGUARDIAN" => GameMode.StarGuardian,
                "PROJECT" => GameMode.Project,
                "GAMEMODEX" => GameMode.GameModeX,
                "ODYSSEY" => GameMode.Odyssey,
                "NEXUSBLITZ" => GameMode.NexusBlitz,
                "ULTBOOK" => GameMode.UltBook,
                "SWIFTPLAY" => GameMode.Swiftplay,
                "BRAWL" => GameMode.Brawl,
                _ => GameMode.Classic // Default fallback
            };
        }
    }
}
