using Microsoft.Extensions.DependencyInjection;
using RiotSharp.Http;
using RiotSharp.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Http;
using Microsoft.Extensions.DependencyInjection.Extensions;

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

            var serializer = new RequestContentSerializer();
            var deserializer = new ResponseDeserializer();
            var httpClient = new HttpClient();
            var failedRequestHandler = new FailedRequestHandler();
            var client = new RequestClient(httpClient, failedRequestHandler);

            if (riotSharpOptions.RiotApi.ApiKey != null)
            {
                var requestCreator = new RequestCreator(riotSharpOptions.RiotApi.ApiKey, serializer);
                var basicRequester = new Requester(client, requestCreator, deserializer);
                var riotRateLimitProvider = new RateLimitProvider(riotSharpOptions.RiotApi.RateLimits);


                var riotRateLimitedRequester = new RateLimitedRequester(basicRequester, riotRateLimitProvider);

                serviceCollection.AddSingleton<IRiotApi>(provider => new RiotApi(riotRateLimitedRequester));


                var staticRateLimitProvider = new RateLimitProvider(new Dictionary<TimeSpan, int>{{new TimeSpan(1, 0, 0), 10}});

                var staticRateLimtedRequester = new RateLimitedRequester(basicRequester, staticRateLimitProvider);

                if (riotSharpOptions.RiotApi.UseMemoryCache)
                {
                    serviceCollection.AddMemoryCache();
                    serviceCollection.AddSingleton<ICache, MemoryCache>();
                }
                else if (riotSharpOptions.RiotApi.UseCache)
                    serviceCollection.AddSingleton<ICache, Cache>();
                else
                    serviceCollection.AddSingleton<ICache, PassThroughCache>();

                serviceCollection.AddSingleton<IStaticRiotApi>(serviceProvider => 
                    new StaticRiotApi(staticRateLimtedRequester, serviceProvider.GetRequiredService<ICache>(), riotSharpOptions.RiotApi.SlidingExpirationTime)); 
            }

            if (riotSharpOptions.TournamentApi.ApiKey != null)
            {
                var requestCreator = new RequestCreator(riotSharpOptions.TournamentApi.ApiKey, serializer);
                var basicRequester = new Requester(client, requestCreator, deserializer);
                var riotRateLimitProvider = new RateLimitProvider(riotSharpOptions.TournamentApi.RateLimits);


                var tournamentRateLimitedRequester = new RateLimitedRequester(basicRequester, riotRateLimitProvider);

                serviceCollection.AddSingleton<ITournamentRiotApi>(serviceProvider => new TournamentRiotApi(tournamentRateLimitedRequester, riotSharpOptions.TournamentApi.UseStub));
            }
            
            return serviceCollection;
        }
    }
}
