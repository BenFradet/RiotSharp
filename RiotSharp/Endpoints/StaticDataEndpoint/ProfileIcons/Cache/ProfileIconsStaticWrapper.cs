using Newtonsoft.Json;
using RiotSharp.Misc;

namespace RiotSharp.Endpoints.StaticDataEndpoint.ProfileIcons.Cache
{
    class ProfileIconsStaticWrapper
    {
        [JsonProperty]
        public ProfileIconListStatic ProfileIconListStatic { get; private set; }
        public Language Language { get; private set; }

        public ProfileIconsStaticWrapper(ProfileIconListStatic profileIconListStatic, Language language)
        {
            ProfileIconListStatic = profileIconListStatic;
            Language = language;
        }
    }
}
