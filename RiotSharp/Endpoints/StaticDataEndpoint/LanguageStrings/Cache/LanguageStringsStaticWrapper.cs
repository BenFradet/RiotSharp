using Newtonsoft.Json;
using RiotSharp.Misc;

namespace RiotSharp.Endpoints.StaticDataEndpoint.LanguageStrings.Cache
{
    class LanguageStringsStaticWrapper
    {
        [JsonProperty]
        public LanguageStringsStatic LanguageStringsStatic { get; private set; }
        public Language Language { get; private set; }
        public string Version { get; private set; }

        public LanguageStringsStaticWrapper(LanguageStringsStatic languageStringsStatic, Language language, string version)
        {
            LanguageStringsStatic = languageStringsStatic;
            Language = language;
            Version = version;
        }
    }
}
