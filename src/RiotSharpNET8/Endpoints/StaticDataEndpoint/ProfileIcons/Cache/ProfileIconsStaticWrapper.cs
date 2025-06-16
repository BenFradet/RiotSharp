using System.Text.Json.Serialization;
using RiotSharpNET8.Misc;

namespace RiotSharpNET8.Endpoints.StaticDataEndpoint.ProfileIcons.Cache
{
    internal class ProfileIconsStaticWrapper
    {
        [JsonInclude]
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
