using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using RiotSharp.Endpoints.ChampionEndpoint;
using RiotSharp.Endpoints.ChampionMasteryEndpoint;
using RiotSharp.Endpoints.Interfaces;
using RiotSharp.Endpoints.LeagueEndpoint;
using RiotSharp.Endpoints.MatchEndpoint;
using RiotSharp.Endpoints.MatchEndpoint.Enums;
using RiotSharp.Endpoints.RunesEndpoint;
using RiotSharp.Endpoints.SpectatorEndpoint;
using RiotSharp.Endpoints.SummonerEndpoint;
using RiotSharp.Misc;

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
        /// The Masteries Endpoint.
        /// </summary>
        IMasteriesEndpoint Masteries { get; }
        /// <summary>
        /// The Runes Endpoint.
        /// </summary>
        IRunesEndpoint Runes { get; }
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
    }
}
