using Newtonsoft.Json;

namespace RiotSharp
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
        Dominion,

        /// <summary>
        /// ARAM games.
        /// </summary>
        Aram,

        /// <summary>
        /// Tutorial games.
        /// </summary>
        Tutorial,

        /// <summary>
        /// One for All games.
        /// </summary>
        OneForAll,

        /// <summary>
        /// Snowdown Showdown games.
        /// </summary>
        FirstBlood,

        /// <summary>
        /// Ascension mode games.
        /// </summary>
        Ascension,

        /// <summary>
        /// Introduction game mode.
        /// </summary>
        Intro,

        /// <summary>
        /// King Poro game mode.
        /// </summary>
        KingPoro,

        /// <summary>
        /// Nexus Siege game mode.
        /// </summary>
        Siege
    }
}
