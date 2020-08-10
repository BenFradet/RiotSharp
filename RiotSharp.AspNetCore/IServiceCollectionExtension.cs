using Microsoft.Extensions.DependencyInjection;
using RiotSharp.Endpoints.Interfaces.Static;
using RiotSharp.Endpoints.StaticDataEndpoint;
using RiotSharp.Http;
using RiotSharp.Interfaces;
using System;
using RiotSharp.Caching;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Caching.Distributed;
using RiotSharp.AspNetCore.Caching;
using RiotSharp.AspNetCore.Options;

namespace RiotSharp.AspNetCore
{
    public static class IServiceCollectionExtension
    {
        /// <summary>
        /// Adds and configures RiotSharp's services
        /// </summary>
        /// <param name="serviceCollection"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static IServiceCollection AddRiotSharp(this IServiceCollection serviceCollection, Action<RiotSharpOptions> options)
        {
            if (serviceCollection == null)
                throw new ArgumentNullException(nameof(serviceCollection));

            var riotSharpOptions = new RiotSharpOptions();
            options(riotSharpOptions);

            if (riotSharpOptions.TournamentApi.ApiKey == null && riotSharpOptions.RiotApi.ApiKey == null)
                throw new ArgumentNullException("No api key provided.", innerException: null);

            if (riotSharpOptions.RiotApi.ApiKey != null)
            {
                var rateLimitedRequester = new RateLimitedRequester(riotSharpOptions.RiotApi.ApiKey,
                    riotSharpOptions.RiotApi.RateLimits);
                var requester = new Requester(riotSharpOptions.RiotApi.ApiKey);

                AddCache(serviceCollection, riotSharpOptions);

                serviceCollection.AddSingleton<IStaticEndpointProvider>(serviceProvider =>
                    new StaticEndpointProvider(new Requester(riotSharpOptions.RiotApi.ApiKey), serviceProvider.GetRequiredService<ICache>(),
                        riotSharpOptions.RiotApi.SlidingExpirationTime));

                serviceCollection.AddSingleton<IDataDragonEndpoints>(serviceProvider =>
                    new DataDragonEndpoints(serviceProvider.GetRequiredService<IStaticEndpointProvider>()));

                serviceCollection.AddSingleton<IRiotApi>(serviceProvider =>
                    new RiotApi(rateLimitedRequester, requester, serviceProvider.GetRequiredService<IStaticEndpointProvider>()));
            }

            if (riotSharpOptions.TournamentApi.ApiKey != null)
            {
                var rateLimitedRequester = new RateLimitedRequester(riotSharpOptions.TournamentApi.ApiKey,
                    riotSharpOptions.TournamentApi.RateLimits);
                serviceCollection.AddSingleton<ITournamentRiotApi>(serviceProvider =>
                    new TournamentRiotApi(rateLimitedRequester, riotSharpOptions.TournamentApi.UseStub));
            }

            return serviceCollection;
        }

        private static void AddCache(IServiceCollection serviceCollection, RiotSharpOptions options)
        {
            switch(options.RiotApi.CacheType)
            {
                case CacheType.None:
                    break;
                case CacheType.PassThrough:
                    serviceCollection.AddSingleton<ICache, PassThroughCache>();
                    break;
                case CacheType.Internal:
                    serviceCollection.AddSingleton<ICache, Cache>();
                    break;
                case CacheType.Memory:
                    serviceCollection.AddSingleton<ICache, Caching.MemoryCache>();
                    break;
                case CacheType.Hybrid:
                    serviceCollection.AddSingleton<ICache, HybridCache>(
                    serviceProvider => new HybridCache(
                        serviceProvider.GetRequiredService<IMemoryCache>(),
                        serviceProvider.GetRequiredService<IDistributedCache>(),
                        options.RiotApi.SlidingExpirationTime));
                    break;
            }
        }
    }
}
