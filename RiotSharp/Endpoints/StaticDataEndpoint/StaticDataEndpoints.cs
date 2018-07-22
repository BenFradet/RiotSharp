using RiotSharp.Caching;
using RiotSharp.Endpoints.Interfaces.Static;
using RiotSharp.Http;
using RiotSharp.Http.Interfaces;
using System;
using System.Collections.Generic;

namespace RiotSharp.Endpoints.StaticDataEndpoint
{
    public class StaticDataEndpoints : IStaticDataEndpoints
    {
        private static StaticDataEndpoints instance;

        public IStaticChampionEndpoint Champions { get; private set; }
        public IStaticItemEndpoint Items { get; private set; }
        public IStaticLanguageEndpoint Languages { get; private set; }
        public IStaticMapEndpoint Maps { get; private set; }
        public IStaticMasteryEndpoint Masteries { get; private set; }
        public IStaticProfileIconEndpoint ProfileIcons { get; private set; }
        public IStaticRealmEndpoint Realms { get; private set; }
        public IStaticReforgedRuneEndpoint ReforgedRunes { get; private set; }
        public IStaticRuneEndpoint Runes { get; private set; }
        public IStaticSummonerSpellEndpoint SummonerSpells { get; private set; }
        public IStaticVersionEndpoint Versions { get; private set; }
        public IStaticTarballLinkEndPoint TarballLinks { get; private set; }

        /// <summary>
        /// Get the instance of StaticDataEndpoints which contains all the static Endpoints as Properties.
        /// </summary>
        /// <returns>The instance of StaticDataEndpoint.</returns>
        public static StaticDataEndpoints GetInstance(bool useCache = true)
        {
            if (instance == null ||
                Requesters.StaticApiRequester == null)
            {
                instance = new StaticDataEndpoints(useCache);
            }
            return instance;
        }

        private StaticDataEndpoints(bool useCache = true)
        {
            Requesters.StaticApiRequester = new Requester();

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
        public StaticDataEndpoints(IStaticEndpointProvider staticEndpointProvider)
        {
            InitializeEndpoints(staticEndpointProvider);
        }

        /// <summary>
        /// StatidDataEndpoint using the default <see cref="IStaticEndpointProvider"/>
        /// </summary>
        /// <param name="requester"></param>
        /// <param name="cache"></param>
        public StaticDataEndpoints(IRequester requester, ICache cache)
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
            this.Champions = staticEndpointProvider.GetEndpoint<IStaticChampionEndpoint>();
            this.Items = staticEndpointProvider.GetEndpoint<IStaticItemEndpoint>();
            this.Languages = staticEndpointProvider.GetEndpoint<IStaticLanguageEndpoint>();
            this.Maps = staticEndpointProvider.GetEndpoint<IStaticMapEndpoint>();
            this.Masteries = staticEndpointProvider.GetEndpoint<IStaticMasteryEndpoint>();
            this.ProfileIcons = staticEndpointProvider.GetEndpoint<IStaticProfileIconEndpoint>();
            this.Realms = staticEndpointProvider.GetEndpoint<IStaticRealmEndpoint>();
            this.ReforgedRunes = staticEndpointProvider.GetEndpoint<IStaticReforgedRuneEndpoint>();
            this.Runes = staticEndpointProvider.GetEndpoint<IStaticRuneEndpoint>();
            this.SummonerSpells = staticEndpointProvider.GetEndpoint<IStaticSummonerSpellEndpoint>();
            this.Versions = staticEndpointProvider.GetEndpoint<IStaticVersionEndpoint>();
            this.TarballLinks = staticEndpointProvider.GetEndpoint<IStaticTarballLinkEndPoint>();
        }
    }
}
