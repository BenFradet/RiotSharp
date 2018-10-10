using Newtonsoft.Json;
using RiotSharp.Misc;

namespace RiotSharp.Endpoints.StaticDataEndpoint.ProfileIcons.Cache
{
    public class ProfileIconsStaticWrapper
    {
        [JsonProperty]
        public ProfileIconListStatic ProfileIconListStatic { get; private set; }
        public Language Language { get; }
        public string Version { get; }

        public ProfileIconsStaticWrapper(ProfileIconListStatic profileIconListStatic, Language language, string version)
        {
            ProfileIconListStatic = profileIconListStatic;
            Language = language;
            Version = version;
        }
    }
}
