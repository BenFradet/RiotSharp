using Newtonsoft.Json;
using RiotSharp.Caching;
using RiotSharp.Endpoints.Interfaces.Static;
using RiotSharp.Endpoints.StaticDataEndpoint.ProfileIcons.Cache;
using RiotSharp.Http.Interfaces;
using RiotSharp.Misc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RiotSharp.Endpoints.StaticDataEndpoint.ProfileIcons
{
    public class StaticProfileIconEndpoint : StaticEndpointBase, IStaticProfileIconEndpoint
    {
        private const string ProfileIconsUrl = "profile-icons";
        private const string ProfileIconsCacheKey = "profile-icons";

        public StaticProfileIconEndpoint(IRateLimitedRequester requester, ICache cache, TimeSpan? slidingExpirationTime)
            : base(requester, cache, slidingExpirationTime) { }

        public StaticProfileIconEndpoint(IRateLimitedRequester requester, ICache cache)
            : this(requester, cache, null) { }

        public async Task<ProfileIconListStatic> GetProfileIconsAsync(Region region, Language language = Language.en_US)
        {
            var wrapper = cache.Get<string, ProfileIconsStaticWrapper>(ProfileIconsCacheKey);
            if (wrapper != null && language == wrapper.Language)
            {
                return wrapper.ProfileIconListStatic;
            }
            var json = await requester.CreateGetRequestAsync(StaticDataRootUrl + ProfileIconsUrl, region,
                new List<string>
                {
                    $"locale={language}",
                }).ConfigureAwait(false);
            var profileIcons = JsonConvert.DeserializeObject<ProfileIconListStatic>(json);
            wrapper = new ProfileIconsStaticWrapper(profileIcons, language);
            cache.Add(ProfileIconsCacheKey, wrapper, SlidingExpirationTime);
            return wrapper.ProfileIconListStatic;
        }
    }
}
