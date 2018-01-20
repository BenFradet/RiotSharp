using RiotSharp.Caching;
using RiotSharp.Endpoints.Interfaces.Static;
using RiotSharp.Http;
using RiotSharp.Http.Interfaces;
using System;
using System.Collections.Generic;

namespace RiotSharp.Endpoints.StaticDataEndpoint
{
    public class StaticDataEndpoint : IStaticDataEndpoint
    {
        private static StaticDataEndpoint instance;

        public IStaticChampionEndpoint Champion { get; private set; }
        public IStaticItemEndpoint Item { get; private set; }
        public IStaticLanguageEndpoint Language { get; private set; }
        public IStaticMapEndpoint Map { get; private set; }
        public IStaticMasteryEndpoint Mastery { get; private set; }
        public IStaticProfileIconEndpoint ProfileIcon { get; private set; }
        public IStaticRealmEndpoint Realm { get; private set; }
        public IStaticRuneEndpoint Rune { get; private set; }
        public IStaticSummonerSpellEndpoint SummonerSpell { get; private set; }
        public IStaticVersionEndpoint Version { get; private set; }

        /// <summary>
        /// Get the instance of StaticDataEndpoint.
        /// </summary>
        /// <param name="apiKey">The api key.</param>
        /// <returns>The instance of StaticDataEndpoint.</returns>
        public static StaticDataEndpoint GetInstance(string apiKey, bool useCache = true)
        {
            if (instance == null ||
                Requesters.StaticApiRequester == null ||
                apiKey != Requesters.StaticApiRequester.ApiKey)
            {
                instance = new StaticDataEndpoint(apiKey, useCache);
            }
            return instance;
        }

        private StaticDataEndpoint(string apiKey, bool useCache = true)
        {
            Requesters.StaticApiRequester = new RateLimitedRequester(apiKey, new Dictionary<TimeSpan, int>
            {
                { new TimeSpan(1, 0, 0), 10 }
            });

            ICache cache = null;
            if (useCache)
                cache = new Cache();
            else
                cache = new PassThroughCache();

            InitializeEndpoints(new StaticEndpointProvider(Requesters.StaticApiRequester, cache));
        }

        /// <summary>
        /// Default dependency injection constructor
        /// </summary>
        /// <param name="staticEndpointProvider">provider that provides configured static-endpoints</param>
        public StaticDataEndpoint(IStaticEndpointProvider staticEndpointProvider)
        {
            InitializeEndpoints(staticEndpointProvider);
        }

        /// <summary>
        /// StatidDataEndpoint using the default <see cref="IStaticEndpointProvider"/>
        /// </summary>
        /// <param name="requester"></param>
        /// <param name="cache"></param>
        public StaticDataEndpoint(IRateLimitedRequester requester, ICache cache)
        {
            if (requester == null)
            {
                throw new ArgumentNullException(nameof(requester));
            }
            if (cache == null)
            {
                throw new ArgumentNullException(nameof(cache));
            }
            InitializeEndpoints(new StaticEndpointProvider(requester, cache));
        }

        private void InitializeEndpoints(IStaticEndpointProvider staticEndpointProvider)
        {
            this.Champion = staticEndpointProvider.GetEndpoint<IStaticChampionEndpoint>();
            this.Item = staticEndpointProvider.GetEndpoint<IStaticItemEndpoint>();
            this.Language = staticEndpointProvider.GetEndpoint<IStaticLanguageEndpoint>();
            this.Map = staticEndpointProvider.GetEndpoint<IStaticMapEndpoint>();
            this.Mastery = staticEndpointProvider.GetEndpoint<IStaticMasteryEndpoint>();
            this.ProfileIcon = staticEndpointProvider.GetEndpoint<IStaticProfileIconEndpoint>();
            this.Realm = staticEndpointProvider.GetEndpoint<IStaticRealmEndpoint>();
            this.Rune = staticEndpointProvider.GetEndpoint<IStaticRuneEndpoint>();
            this.SummonerSpell = staticEndpointProvider.GetEndpoint<IStaticSummonerSpellEndpoint>();
            this.Version = staticEndpointProvider.GetEndpoint<IStaticVersionEndpoint>();
        }
    }
}
