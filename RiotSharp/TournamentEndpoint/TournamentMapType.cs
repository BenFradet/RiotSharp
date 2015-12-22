using Newtonsoft.Json;

namespace RiotSharp.TournamentEndpoint
{
    [JsonConverter(typeof(TournamentMapTypeConverter))]
    /// <summary>
    /// Mode of the game (Tournament API).
    /// </summary>
    public enum TournamentMapType
    {
        SummonersRift,
        TwistedTreeline,
        CrystalScar,
        HowlingAbyss
    }
}
