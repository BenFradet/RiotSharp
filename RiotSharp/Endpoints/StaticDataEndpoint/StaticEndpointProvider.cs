using RiotSharp.Caching;
using RiotSharp.Endpoints.Interfaces.Static;
using RiotSharp.Endpoints.StaticDataEndpoint.Champion;
using RiotSharp.Endpoints.StaticDataEndpoint.Item;
using RiotSharp.Endpoints.StaticDataEndpoint.LanguageStrings;
using RiotSharp.Endpoints.StaticDataEndpoint.Map;
using RiotSharp.Endpoints.StaticDataEndpoint.Mastery;
using RiotSharp.Endpoints.StaticDataEndpoint.ProfileIcons;
using RiotSharp.Endpoints.StaticDataEndpoint.Realm;
using RiotSharp.Endpoints.StaticDataEndpoint.ReforgedRune;
using RiotSharp.Endpoints.StaticDataEndpoint.Rune;
using RiotSharp.Endpoints.StaticDataEndpoint.SummonerSpell;
using RiotSharp.Endpoints.StaticDataEndpoint.TarballLinks;
using RiotSharp.Endpoints.StaticDataEndpoint.Version;
using RiotSharp.Http.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RiotSharp.Endpoints.StaticDataEndpoint
{
    public class StaticEndpointProvider : IStaticEndpointProvider
    {
        public List<IStaticEndpoint> Endpoints { get; set; }

        public StaticEndpointProvider(IRateLimitedRequester requester, ICache cache)
        {
            this.Endpoints = new List<IStaticEndpoint>
            {
                new StaticChampionEndpoint(requester, cache),
                new StaticItemEndpoint(requester, cache),
                new StaticLanguageEndpoint(requester, cache),
                new StaticMapEndpoint(requester, cache),
                new StaticMasteryEndpoint(requester, cache),
                new StaticProfileIconEndpoint(requester, cache),
                new StaticRealmEndpoint(requester, cache),
                new StaticRuneEndpoint(requester, cache),
                new StaticSummonerSpellEndpoint(requester, cache),
                new StaticVersionEndpoint(requester, cache),
                new StaticReforgedRuneEndpoint(requester, cache),
                new StaticTarballLinkEndPoint(requester, cache)
            };
        }

        public StaticEndpointProvider(IEnumerable<IStaticEndpoint> staticEndpoints)
        {
            this.Endpoints = staticEndpoints.ToList();
        }

        public TStaticEndpoint GetEndpoint<TStaticEndpoint>() where TStaticEndpoint : IStaticEndpoint
        {
            foreach (var endpoint in Endpoints)
            {
                if (endpoint is TStaticEndpoint requestedEndpoint)
                {
                    return requestedEndpoint;
                }
            }
            throw new InvalidOperationException($"No endpoint for the requested type ({typeof(TStaticEndpoint)}) registered.");
        }
    }
}