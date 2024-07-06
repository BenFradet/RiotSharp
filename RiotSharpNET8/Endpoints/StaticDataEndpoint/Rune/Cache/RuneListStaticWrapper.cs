using System.Text.Json.Serialization;
using RiotSharpNET8.Misc;

namespace RiotSharpNET8.Endpoints.StaticDataEndpoint.Rune.Cache
{
    internal class RuneListStaticWrapper
    {
        [JsonInclude]
        public RuneListStatic RuneListStatic { get; private set; }
        public Language Language { get; }
        public string Version { get; }

        public RuneListStaticWrapper(RuneListStatic runes, Language language, string version)
        {
            RuneListStatic = runes;
            Language = language;
            Version = version;
        }
    }
}
