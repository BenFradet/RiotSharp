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
        private const string ProfileIconsDataKey = "profileicon";
        private const string ProfileIconsCacheKey = "profile-icons";

        public StaticProfileIconEndpoint(IRequester requester, ICache cache, TimeSpan? slidingExpirationTime)
            : base(requester, cache, slidingExpirationTime) { }

        public StaticProfileIconEndpoint(IRequester requester, ICache cache)
            : this(requester, cache, null) { }

        public async Task<ProfileIconListStatic> GetAllAsync(string version, Language language = Language.en_US)
        {
            var cacheKey = ProfileIconsCacheKey + language + version;
            var wrapper = cache.Get<string, ProfileIconsStaticWrapper>(cacheKey);
            if (wrapper != null && language == wrapper.Language && version == wrapper.Version)
            {
                return wrapper.ProfileIconListStatic;
            }
            var json = await requester.CreateGetRequestAsync(Host, CreateUrl(version, language, ProfileIconsDataKey)).ConfigureAwait(false);
            var profileIcons = JsonConvert.DeserializeObject<ProfileIconListStatic>(json);
            wrapper = new ProfileIconsStaticWrapper(profileIcons, language, version);
            cache.Add(cacheKey, wrapper, SlidingExpirationTime);
            return wrapper.ProfileIconListStatic;
        }
    }
}
