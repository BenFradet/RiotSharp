using Microsoft.Extensions.DependencyInjection;
using RiotSharp.Endpoints.Interfaces.Static;
using RiotSharp.Endpoints.StaticDataEndpoint;
using RiotSharp.Http;
using RiotSharp.Http.Interfaces;
using RiotSharp.Interfaces;
using System;
using System.Collections.Generic;
using RiotSharp.Caching;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Caching.Distributed;

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
                serviceCollection.AddSingleton<ITournamentRiotApi>(serviceProvider => 
                    new TournamentRiotApi(rateLimitedRequester));

                var staticApiRequester = new RateLimitedRequester(riotSharpOptions.RiotApi.ApiKey, 
                    riotSharpOptions.RiotApi.StaticDataRateLimits, riotSharpOptions.RiotApi.ThrowOnRateLimitedReached);

                if (riotSharpOptions.RiotApi.UseMemoryCache)
                    serviceCollection.AddSingleton<ICache, MemoryCache>();
                else if (riotSharpOptions.RiotApi.UseDistributedCache)
                    serviceCollection.AddSingleton<ICache, DistributedCache>();
                else if (riotSharpOptions.RiotApi.UseHybridCache)
                    serviceCollection.AddSingleton<ICache, HybridCache>(serviceProvider => {
                        return new HybridCache(serviceProvider.GetRequiredService<IMemoryCache>(),
                            serviceProvider.GetRequiredService<IDistributedCache>(), riotSharpOptions.RiotApi.SlidingExpirationTime);
                    });
                else if (riotSharpOptions.RiotApi.UseCache)
                    serviceCollection.AddSingleton<ICache, Cache>();
                else
                    serviceCollection.AddSingleton<ICache, PassThroughCache>();

                serviceCollection.AddSingleton<IStaticEndpointProvider>(serviceProvider =>
                    new StaticEndpointProvider(staticApiRequester, serviceProvider.GetRequiredService<ICache>(), 
                        riotSharpOptions.RiotApi.SlidingExpirationTime));

                serviceCollection.AddSingleton<IStaticDataEndpoints>(serviceProvider => 
                    new StaticDataEndpoints(serviceProvider.GetRequiredService<IStaticEndpointProvider>()));

                serviceCollection.AddSingleton<IRiotApi>(serviceProvider =>
                    new RiotApi(rateLimitedRequester, serviceProvider.GetRequiredService<IStaticEndpointProvider>()));
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
    }
}
