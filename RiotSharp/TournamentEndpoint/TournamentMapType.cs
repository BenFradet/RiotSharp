using Newtonsoft.Json;

namespace RiotSharp.TournamentEndpoint
{
    /// <summary>
    ///     Mode of the game (Tournament API).
    /// </summary>
    [JsonConverter(typeof (TournamentMapTypeConverter))]
    public enum TournamentMapType
    {
        SummonersRift,
        TwistedTreeline,
        CrystalScar,
        HowlingAbyss
    }
}