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
    /// <summary>
    /// Implementation of <see cref="IStaticEndpointProvider"/>
    /// </summary>
    /// <seealso cref="RiotSharp.Endpoints.Interfaces.Static.IStaticEndpointProvider" />
    public class StaticEndpointProvider : IStaticEndpointProvider
    {
        /// <summary>
        /// A list of StaticEndpoints
        /// </summary>
        public List<IStaticEndpoint> Endpoints { get; set; }

        /// <inheritdoc />
        public StaticEndpointProvider(IRequester requester, ICache cache, TimeSpan? slidingExpirationTime = null)
        {
            this.Endpoints = new List<IStaticEndpoint>
            {
                new StaticChampionEndpoint(requester, cache, slidingExpirationTime),
                new StaticItemEndpoint(requester, cache, slidingExpirationTime),
                new StaticLanguageEndpoint(requester, cache, slidingExpirationTime),
                new StaticMapEndpoint(requester, cache, slidingExpirationTime),
                new StaticMasteryEndpoint(requester, cache, slidingExpirationTime),
                new StaticProfileIconEndpoint(requester, cache, slidingExpirationTime),
                new StaticRealmEndpoint(requester, cache, slidingExpirationTime),
                new StaticRuneEndpoint(requester, cache, slidingExpirationTime),
                new StaticSummonerSpellEndpoint(requester, cache, slidingExpirationTime),
                new StaticVersionEndpoint(requester, cache, slidingExpirationTime),
                new StaticReforgedRuneEndpoint(requester, cache, slidingExpirationTime),
                new StaticTarballLinkEndPoint()
            };
        }

        /// <inheritdoc />
        public StaticEndpointProvider(IEnumerable<IStaticEndpoint> staticEndpoints)
        {
            this.Endpoints = staticEndpoints.ToList();
        }

        /// <inheritdoc />
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