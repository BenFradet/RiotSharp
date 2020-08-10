using RiotSharp.Caching;
using RiotSharp.Endpoints.Interfaces.Static;
using RiotSharp.Http;
using RiotSharp.Http.Interfaces;
using System;

namespace RiotSharp.Endpoints.StaticDataEndpoint
{
    /// <summary>
    /// Implementation of <see cref="IDataDragonEndpoints"> which contains all static data </see>/>
    /// </summary>
    /// <seealso cref="RiotSharp.Endpoints.Interfaces.Static.IDataDragonEndpoints" />
    public class DataDragonEndpoints : IDataDragonEndpoints

    {
        private static DataDragonEndpoints _instance;

        /// <inheritdoc />
        public IStaticChampionEndpoint Champions { get; private set; }

        /// <inheritdoc />
        public IStaticItemEndpoint Items { get; private set; }

        /// <inheritdoc />
        public IStaticLanguageEndpoint Languages { get; private set; }

        /// <inheritdoc />
        public IStaticMapEndpoint Maps { get; private set; }

        /// <inheritdoc />
        public IStaticMasteryEndpoint Masteries { get; private set; }

        /// <inheritdoc />
        public IStaticProfileIconEndpoint ProfileIcons { get; private set; }

        /// <inheritdoc />
        public IStaticRealmEndpoint Realms { get; private set; }

        /// <inheritdoc />
        public IStaticReforgedRuneEndpoint ReforgedRunes { get; private set; }

        /// <inheritdoc />
        public IStaticRuneEndpoint Runes { get; private set; }

        /// <inheritdoc />
        public IStaticSummonerSpellEndpoint SummonerSpells { get; private set; }

        /// <inheritdoc />
        public IStaticVersionEndpoint Versions { get; private set; }

        /// <inheritdoc />
        public IStaticTarballLinkEndPoint TarballLinks { get; private set; }

        /// <summary>
        /// Get the instance of DataDragonEndpoints which contains all the static Endpoints as Properties.
        /// </summary>
        /// <returns>The instance of DataDragonEndpoint.</returns>
        public static DataDragonEndpoints GetInstance(bool useCache = true)
        {
            if (_instance == null ||
                Requesters.StaticApiRequester == null)
            {
                _instance = new DataDragonEndpoints(useCache);
            }
            return _instance;
        }

        private DataDragonEndpoints(bool useCache = true)
        {
            Requesters.StaticApiRequester = new Requester();

            var cache = useCache ? (ICache)new Cache() : new PassThroughCache();

            InitializeEndpoints(new StaticEndpointProvider(Requesters.StaticApiRequester, cache));
        }

        /// <summary>
        /// Default dependency injection constructor
        /// </summary>
        /// <param name="staticEndpointProvider">provider that provides configured static-endpoints</param>
        public DataDragonEndpoints(IStaticEndpointProvider staticEndpointProvider)
        {
            InitializeEndpoints(staticEndpointProvider);
        }

        /// <summary>
        /// StatidDataEndpoint using the default <see cref="IStaticEndpointProvider"/>
        /// </summary>
        /// <param name="requester"></param>
        /// <param name="cache"></param>
        public DataDragonEndpoints(IRequester requester, ICache cache)
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
            Champions = staticEndpointProvider.GetEndpoint<IStaticChampionEndpoint>();
            Items = staticEndpointProvider.GetEndpoint<IStaticItemEndpoint>();
            Languages = staticEndpointProvider.GetEndpoint<IStaticLanguageEndpoint>();
            Maps = staticEndpointProvider.GetEndpoint<IStaticMapEndpoint>();
            Masteries = staticEndpointProvider.GetEndpoint<IStaticMasteryEndpoint>();
            ProfileIcons = staticEndpointProvider.GetEndpoint<IStaticProfileIconEndpoint>();
            Realms = staticEndpointProvider.GetEndpoint<IStaticRealmEndpoint>();
            ReforgedRunes = staticEndpointProvider.GetEndpoint<IStaticReforgedRuneEndpoint>();
            Runes = staticEndpointProvider.GetEndpoint<IStaticRuneEndpoint>();
            SummonerSpells = staticEndpointProvider.GetEndpoint<IStaticSummonerSpellEndpoint>();
            Versions = staticEndpointProvider.GetEndpoint<IStaticVersionEndpoint>();
            TarballLinks = staticEndpointProvider.GetEndpoint<IStaticTarballLinkEndPoint>();
        }
    }
}
