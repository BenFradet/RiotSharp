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

        public IStaticChampionEndpoint Champion { get; private set; }
        public IStaticItemEndpoint Item { get; private set; }
        public IStaticLanguageEndpoint Language { get; private set; }
        public IStaticMapEndpoint Map { get; private set; }
        public IStaticMasteryEndpoint Mastery { get; private set; }
        public IStaticProfileIconEndpoint ProfileIcon { get; private set; }
        public IStaticRealmEndpoint Realm { get; private set; }
        public IStaticReforgedRuneEndpoint ReforgedRune { get; private set; }
        public IStaticRuneEndpoint Rune { get; private set; }
        public IStaticSummonerSpellEndpoint SummonerSpell { get; private set; }
        public IStaticVersionEndpoint Version { get; private set; }
        public IStaticTarballLinkEndPoint TarballLink { get; private set; }

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
            Requesters.StaticApiRequester = new Requester("NOT-NEEDED");

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
            this.Champion = staticEndpointProvider.GetEndpoint<IStaticChampionEndpoint>();
            this.Item = staticEndpointProvider.GetEndpoint<IStaticItemEndpoint>();
            this.Language = staticEndpointProvider.GetEndpoint<IStaticLanguageEndpoint>();
            this.Map = staticEndpointProvider.GetEndpoint<IStaticMapEndpoint>();
            this.Mastery = staticEndpointProvider.GetEndpoint<IStaticMasteryEndpoint>();
            this.ProfileIcon = staticEndpointProvider.GetEndpoint<IStaticProfileIconEndpoint>();
            this.Realm = staticEndpointProvider.GetEndpoint<IStaticRealmEndpoint>();
            this.ReforgedRune = staticEndpointProvider.GetEndpoint<IStaticReforgedRuneEndpoint>();
            this.Rune = staticEndpointProvider.GetEndpoint<IStaticRuneEndpoint>();
            this.SummonerSpell = staticEndpointProvider.GetEndpoint<IStaticSummonerSpellEndpoint>();
            this.Version = staticEndpointProvider.GetEndpoint<IStaticVersionEndpoint>();
            this.TarballLink = staticEndpointProvider.GetEndpoint<IStaticTarballLinkEndPoint>();
        }
    }
}
