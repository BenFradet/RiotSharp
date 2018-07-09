using Newtonsoft.Json;
using RiotSharp.Misc;

namespace RiotSharp.Endpoints.StaticDataEndpoint.ProfileIcons.Cache
{
    class ProfileIconsStaticWrapper
    {
        [JsonProperty]
        public ProfileIconListStatic ProfileIconListStatic { get; private set; }
        public Language Language { get; private set; }
        public string Version { get; private set; }

        public ProfileIconsStaticWrapper(ProfileIconListStatic profileIconListStatic, Language language, string version)
        {
            ProfileIconListStatic = profileIconListStatic;
            Language = language;
            Version = version;
        }
    }
}
