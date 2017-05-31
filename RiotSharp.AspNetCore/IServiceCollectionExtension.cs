using Microsoft.Extensions.DependencyInjection;
using RiotSharp.Http;
using RiotSharp.Interfaces;
using System;

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
            var riotSharpOptions = new RiotSharpOptions();
            options(riotSharpOptions);

            if (riotSharpOptions.TournamentApiKey.Key == null && riotSharpOptions.ApiKey.Key == null)
                throw new ArgumentNullException("No api key provided.", innerException: null);

            if (riotSharpOptions.ApiKey.Key != null)
            {
                var rateLimitedRequester = new RateLimitedRequester(riotSharpOptions.ApiKey.Key,
                    riotSharpOptions.ApiKey.RateLimitPer10S, riotSharpOptions.ApiKey.RateLimitPer10M);
                serviceCollection.AddSingleton<ITournamentRiotApi>(serviceProvider => 
                    new TournamentRiotApi(rateLimitedRequester));
                serviceCollection.AddSingleton<IRiotApi>(serviceProvider => new RiotApi(rateLimitedRequester));

                var requester = new Requester(riotSharpOptions.ApiKey.Key);
                serviceCollection.AddSingleton<ICache, Cache>();
                serviceCollection.AddSingleton<IStaticRiotApi>(serviceProvider => 
                    new StaticRiotApi(requester, serviceProvider.GetRequiredService<ICache>())); 
            }

            if (riotSharpOptions.TournamentApiKey.Key != null)
            {
                var rateLimitedRequester = new RateLimitedRequester(riotSharpOptions.TournamentApiKey.Key, 
                    riotSharpOptions.TournamentApiKey.RateLimitPer10S, riotSharpOptions.TournamentApiKey.RateLimitPer10M);
                serviceCollection.AddSingleton<ITournamentRiotApi>(serviceProvider => 
                    new TournamentRiotApi(rateLimitedRequester));
            }
            
            return serviceCollection;
        }
    }
}
