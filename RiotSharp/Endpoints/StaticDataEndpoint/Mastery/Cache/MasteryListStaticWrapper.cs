using Newtonsoft.Json;
using RiotSharp.Misc;

namespace RiotSharp.Endpoints.StaticDataEndpoint.Mastery.Cache
{
    class MasteryListStaticWrapper
    {
        [JsonProperty]
        public MasteryListStatic MasteryListStatic { get; private set; }
        public Language Language { get; private set; }
        public string Version { get; private set; }

        public MasteryListStaticWrapper(MasteryListStatic masteries, Language language, string version)
        {
            MasteryListStatic = masteries;
            Language = language;
            Version = version;
        }
    }
}
