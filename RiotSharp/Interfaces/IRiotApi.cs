using RiotSharp.Endpoints.Interfaces;
using RiotSharp.Endpoints.Interfaces.Static;

namespace RiotSharp.Interfaces
{
    /// <summary>
    /// Entry point for the API.
    /// </summary>
    public interface IRiotApi
    {
        /// <summary>
        /// The Summoner Endpoint.
        /// </summary>
        ISummonerEndpoint Summoner { get; }
        /// <summary>
        /// The Champion Endpoint.
        /// </summary>
        IChampionEndpoint Champion { get; }
        /// <summary>
        /// The League Endpoint.
        /// </summary>
        ILeagueEndpoint League { get; }
        /// <summary>
        /// The Match Endpoint.
        /// </summary>
        IMatchEndpoint Match { get; }
        /// <summary>
        /// The Spectator Endpoint.
        /// </summary>
        ISpectatorEndpoint Spectator { get; }
        /// <summary>
        /// The Champion Mastery Endpoint.
        /// </summary>
        IChampionMasteryEndpoint ChampionMastery { get; }
        /// <summary>
        /// The Third Party Endpoint.
        /// </summary>
        IThirdPartyEndpoint ThirdParty { get; }
        /// <summary>
        /// The Static Data Endpoint.
        /// </summary>
        IStaticDataEndpoints StaticData { get; }
    }
}
