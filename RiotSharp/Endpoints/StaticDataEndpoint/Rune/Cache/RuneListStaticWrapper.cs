using Newtonsoft.Json;
using RiotSharp.Misc;

namespace RiotSharp.Endpoints.StaticDataEndpoint.Rune.Cache
{
    class RuneListStaticWrapper
    {
        [JsonProperty]
        public RuneListStatic RuneListStatic { get; private set; }
        public Language Language { get; private set; }
        public string Version { get; private set; }

        public RuneListStaticWrapper(RuneListStatic runes, Language language, string version)
        {
            RuneListStatic = runes;
            Language = language;
            Version = version;
        }
    }
}
