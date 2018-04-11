using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RiotSharp.Caching;
using RiotSharp.Endpoints.Interfaces.Static;
using RiotSharp.Http.Interfaces;
using RiotSharp.Misc;

namespace RiotSharp.Endpoints.StaticDataEndpoint.TarballLinks
{
    public class StaticTarballLinkEndPoint : StaticEndpointBase, IStaticTarballLinkEndPoint
    {
        private const string TarballLinksUrl = "tarball-links";
        private const string TarballLinksCacheKey = "tarball-links";

        public StaticTarballLinkEndPoint(IRateLimitedRequester requester, ICache cache)
            : base(requester, cache) { }

        public StaticTarballLinkEndPoint(IRateLimitedRequester requester, ICache cache, TimeSpan? slidingExpirationTime)
            : base(requester, cache, slidingExpirationTime) { }

        public async Task<string> GetTarballLinksAsync(Region region)
        {
            return await this.GetTarballLinksAsync(region, string.Empty);
        }

        public async Task<string> GetTarballLinksAsync(Region region, String version)
        {
            var cacheKey = TarballLinksCacheKey + region + version;
            var wrapper = cache.Get<string, string>(cacheKey);
            if (wrapper != null)
            {
                return wrapper;
            }

            var json = await requester.CreateGetRequestAsync(StaticDataRootUrl + TarballLinksUrl, region,
                    new List<string> { !string.IsNullOrEmpty(version) ? $"version={version}" : null }).ConfigureAwait(false);
            var tarballLink = JsonConvert.DeserializeObject<string>(json);

            cache.Add(cacheKey, tarballLink, SlidingExpirationTime);

            return tarballLink;
        }
    }
}