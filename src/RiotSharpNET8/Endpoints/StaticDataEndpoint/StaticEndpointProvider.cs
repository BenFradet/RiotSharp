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
        public StaticEndpointProvider(IRiotRequester riotRequester, ICache cache, TimeSpan? slidingExpirationTime = null)
        {
            this.Endpoints = new List<IStaticEndpoint>
            {
                new StaticChampionEndpoint(riotRequester, cache, slidingExpirationTime),
                new StaticItemEndpoint(riotRequester, cache, slidingExpirationTime),
                new StaticLanguageEndpoint(riotRequester, cache, slidingExpirationTime),
                new StaticMapEndpoint(riotRequester, cache, slidingExpirationTime),
                new StaticMasteryEndpoint(riotRequester, cache, slidingExpirationTime),
                new StaticProfileIconEndpoint(riotRequester, cache, slidingExpirationTime),
                new StaticRealmEndpoint(riotRequester, cache, slidingExpirationTime),
                new StaticRuneEndpoint(riotRequester, cache, slidingExpirationTime),
                new StaticSummonerSpellEndpoint(riotRequester, cache, slidingExpirationTime),
                new StaticVersionEndpoint(riotRequester, cache, slidingExpirationTime),
                new StaticReforgedRuneEndpoint(riotRequester, cache, slidingExpirationTime),
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