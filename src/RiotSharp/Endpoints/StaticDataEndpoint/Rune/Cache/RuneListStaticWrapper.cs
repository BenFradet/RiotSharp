using Newtonsoft.Json;
using RiotSharp.Misc;

namespace RiotSharp.Endpoints.StaticDataEndpoint.Rune.Cache
{
    internal class RuneListStaticWrapper
    {
        [JsonProperty]
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
