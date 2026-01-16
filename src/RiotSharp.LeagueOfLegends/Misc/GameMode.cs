using System.Text.Json.Serialization;
using RiotSharp.LeagueOfLegends.Misc.Converters;

namespace RiotSharp.LeagueOfLegends.Misc
{
    /// <summary>
    /// Mode of the game (Game API).
    /// </summary>
    [JsonConverter(typeof(GameModeConverter))]
    public enum GameMode
    {
        /// <summary>
        /// Classic Summoner's Rift and Twisted Treeline games.
        /// </summary>
        Classic,

        /// <summary>
        /// Dominion/Crystal Scar games.
        /// </summary>
        Odin,

        /// <summary>
        /// ARAM games.
        /// </summary>
        Aram,

        /// <summary>
        /// Tutorial games.
        /// </summary>
        Tutorial,

        /// <summary>
        /// URF games.
        /// </summary>
        Urf,
        
        /// <summary>
        /// Doom Bot games.
        /// </summary>
        DoomBotsTeemo,

        /// <summary>
        /// One for All games.
        /// </summary>
        OneForAll,
        
        /// <summary>
        /// Ascension games.
        /// </summary>
        Ascension,

        /// <summary>
        /// Snowdown Showdown games.
        /// </summary>
        FirstBlood,
        
        /// <summary>
        /// Legend of the Poro King games.
        /// </summary>
        KingPoro,

        /// <summary>
        /// Nexus Siege games.
        /// </summary>
        Siege,

        /// <summary>
        /// Blood Hunt Assassin games.
        /// </summary>
        Assassinate,

        /// <summary>
        /// All Random Summoner's Rift games.
        /// </summary>
        Arsr,
        
        /// <summary>
        /// Dark Star: Singularity games.
        /// </summary>
        Darkstar,

        /// <summary>
        /// Star Guardian Invasion games.
        /// </summary>
        StarGuardian,

        /// <summary>
        /// PROJECT: Hunters games.
        /// </summary>
        Project,

        /// <summary>
        /// Nexus Blitz games.
        /// </summary>
        GameModeX,

        /// <summary>
        /// Odyssey: Extraction games.
        /// </summary>
        Odyssey,

        /// <summary>
        /// Nexus Blitz games.
        /// </summary>
        NexusBlitz,

        /// <summary>
        /// Ultimate Spellbook games.
        /// </summary>
        UltBook,

        /// <summary>
        /// Swiftplay Games.
        /// </summary>
        Swiftplay,

        /// <summary>
        /// Brawl.
        /// </summary>
        Brawl
    }

    static class GameModeExtension
    {
        public static string ToCustomString(this GameMode gameMode)
        {
            return gameMode switch
            {
                GameMode.Classic => "CLASSIC",
                GameMode.Odin => "ODIN",
                GameMode.Aram => "ARAM",
                GameMode.Tutorial => "TUTORIAL",
                GameMode.Urf => "URF",
                GameMode.DoomBotsTeemo => "DOOMBOTSTEEMO",
                GameMode.OneForAll => "ONEFORALL",
                GameMode.Ascension => "ASCENSION",
                GameMode.FirstBlood => "FIRSTBLOOD",
                GameMode.KingPoro => "KINGPORO",
                GameMode.Siege => "SIEGE",
                GameMode.Assassinate => "ASSASSINATE",
                GameMode.Arsr => "ARSR",
                GameMode.Darkstar => "DARKSTAR",
                GameMode.StarGuardian => "STARGUARDIAN",
                GameMode.Project => "PROJECT",
                GameMode.GameModeX => "GAMEMODEX",
                GameMode.Odyssey => "ODYSSEY",
                GameMode.NexusBlitz => "NEXUSBLITZ",
                GameMode.UltBook => "ULTBOOK",
                GameMode.Swiftplay => "SWIFTPLAY",
                GameMode.Brawl => "BRAWL",
                _ => string.Empty
            };
        }
    }
}
