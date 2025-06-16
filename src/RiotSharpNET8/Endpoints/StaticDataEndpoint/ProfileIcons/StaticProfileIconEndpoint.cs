using System.Text.Json;
using RiotSharpNET8.Caching;
using RiotSharpNET8.Endpoints.Interfaces.Static;
using RiotSharpNET8.Endpoints.StaticDataEndpoint.ProfileIcons.Cache;
using RiotSharpNET8.Http.Interfaces;
using RiotSharpNET8.Misc;

namespace RiotSharpNET8.Endpoints.StaticDataEndpoint.ProfileIcons
{
    /// <summary>
    /// Implementation of <see cref="IStaticProfileIconEndpoint"/>, inherits from <see cref="StaticEndpointBase"/>
    /// </summary>
    /// <seealso cref="StaticEndpointBase" />
    /// <seealso cref="IStaticProfileIconEndpoint" />
    public class StaticProfileIconEndpoint : StaticEndpointBase, IStaticProfileIconEndpoint
    {
        private const string ProfileIconsDataKey = "profileicon";
        private const string ProfileIconsCacheKey = "profile-icons";

        /// <inheritdoc />
        public StaticProfileIconEndpoint(IRiotRequester riotRequester, ICache cache, TimeSpan? slidingExpirationTime)
            : base(riotRequester, cache, slidingExpirationTime) { }

        /// <inheritdoc />
        public StaticProfileIconEndpoint(IRiotRequester riotRequester, ICache cache)
            : this(riotRequester, cache, null) { }

        /// <inheritdoc />
        public async Task<ProfileIconListStatic> GetAllAsync(string version, Language language = Language.en_US)
        {
            var cacheKey = ProfileIconsCacheKey + language + version;
            var wrapper = cache.Get<string, ProfileIconsStaticWrapper>(cacheKey);
            if (wrapper != null && language == wrapper.Language && version == wrapper.Version)
            {
                return wrapper.ProfileIconListStatic;
            }
            var json = await RiotRequester.CreateGetRequestAsync(Host, CreateUrl(version, language, ProfileIconsDataKey)).ConfigureAwait(false);
            var profileIcons = JsonSerializer.Deserialize<ProfileIconListStatic>(json); //JsonConvert.DeserializeObject<ProfileIconListStatic>(json);
            wrapper = new ProfileIconsStaticWrapper(profileIcons, language, version);
            cache.Add(cacheKey, wrapper, SlidingExpirationTime);
            return wrapper.ProfileIconListStatic;
        }
    }
}
