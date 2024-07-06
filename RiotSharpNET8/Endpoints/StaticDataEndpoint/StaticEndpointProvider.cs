using RiotSharpNET8.Caching;
using RiotSharpNET8.Endpoints.Interfaces.Static;
using RiotSharpNET8.Endpoints.StaticDataEndpoint.Champion;
using RiotSharpNET8.Endpoints.StaticDataEndpoint.Item;
using RiotSharpNET8.Endpoints.StaticDataEndpoint.LanguageStrings;
using RiotSharpNET8.Endpoints.StaticDataEndpoint.Map;
using RiotSharpNET8.Endpoints.StaticDataEndpoint.Mastery;
using RiotSharpNET8.Endpoints.StaticDataEndpoint.ProfileIcons;
using RiotSharpNET8.Endpoints.StaticDataEndpoint.Realm;
using RiotSharpNET8.Endpoints.StaticDataEndpoint.ReforgedRune;
using RiotSharpNET8.Endpoints.StaticDataEndpoint.Rune;
using RiotSharpNET8.Endpoints.StaticDataEndpoint.SummonerSpell;
using RiotSharpNET8.Endpoints.StaticDataEndpoint.TarballLinks;
using RiotSharpNET8.Endpoints.StaticDataEndpoint.Version;
using RiotSharpNET8.Http.Interfaces;

namespace RiotSharpNET8.Endpoints.StaticDataEndpoint
{
    /// <summary>
    /// Implementation of <see cref="IStaticEndpointProvider"/>
    /// </summary>
    /// <seealso cref="IStaticEndpointProvider" />
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