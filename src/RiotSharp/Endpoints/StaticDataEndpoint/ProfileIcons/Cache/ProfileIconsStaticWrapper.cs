using Newtonsoft.Json;
using RiotSharp.Misc;

namespace RiotSharp.Endpoints.StaticDataEndpoint.ProfileIcons.Cache
{
    internal class ProfileIconsStaticWrapper
    {
        [JsonProperty]
        internal ProfileIconListStatic ProfileIconListStatic { get; private set; }
        internal Language Language { get; }
        internal string Version { get; }

        internal ProfileIconsStaticWrapper(ProfileIconListStatic profileIconListStatic, Language language, string version)
        {
            ProfileIconListStatic = profileIconListStatic;
            Language = language;
            Version = version;
        }
    }
}
