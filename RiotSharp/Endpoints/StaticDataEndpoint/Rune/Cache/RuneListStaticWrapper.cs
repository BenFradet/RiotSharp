using Newtonsoft.Json;
using RiotSharp.Misc;

namespace RiotSharp.Endpoints.StaticDataEndpoint.Rune.Cache
{
    class RuneListStaticWrapper
    {
        [JsonProperty]
        public RuneListStatic RuneListStatic { get; private set; }
        public Language Language { get; private set; }
        public RuneData RuneData { get; private set; }

        public RuneListStaticWrapper(RuneListStatic runes, Language language, RuneData runeData)
        {
            RuneListStatic = runes;
            Language = language;
            RuneData = runeData;
        }
    }
}
