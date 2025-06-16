using Newtonsoft.Json;
using RiotSharp.Endpoints.TournamentEndpoint.Enums.Converters;

namespace RiotSharp.Endpoints.TournamentEndpoint.Enums
{
    /// <summary>
    ///     Mode of the game (Tournament API).
    /// </summary>
    [JsonConverter(typeof(TournamentMapTypeConverter))]
    public enum TournamentMapType
    {
        /// <summary>
        /// Summoner's Rift map.
        /// </summary>
        SummonersRift,

        /// <summary>
        /// Twisted Treeline map.
        /// </summary>
        TwistedTreeline,

        /// <summary>
        /// Crystal Scar (Dominion) map.
        /// </summary>
        CrystalScar,

        /// <summary>
        /// Howling Abyss (ARAM) map.
        /// </summary>
        HowlingAbyss
    }
}
