using System.Text.Json.Serialization;
using RiotSharpNET8.Misc;

namespace RiotSharpNET8.Endpoints.StaticDataEndpoint.LanguageStrings.Cache
{
    class LanguageStringsStaticWrapper
    {
        [JsonInclude]
        public LanguageStringsStatic LanguageStringsStatic { get; private set; }
        public Language Language { get; }
        public string Version { get; }

        public LanguageStringsStaticWrapper(LanguageStringsStatic languageStringsStatic, Language language, string version)
        {
            LanguageStringsStatic = languageStringsStatic;
            Language = language;
            Version = version;
        }
    }
}
