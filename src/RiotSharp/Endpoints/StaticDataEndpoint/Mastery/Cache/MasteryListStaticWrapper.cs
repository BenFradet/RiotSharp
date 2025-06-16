using Newtonsoft.Json;
using RiotSharp.Misc;

namespace RiotSharp.Endpoints.StaticDataEndpoint.Mastery.Cache
{
    internal class MasteryListStaticWrapper
    {
        [JsonProperty]
        public MasteryListStatic MasteryListStatic { get; private set; }
        public Language Language { get; }
        public string Version { get; }

        public MasteryListStaticWrapper(MasteryListStatic masteries, Language language, string version)
        {
            MasteryListStatic = masteries;
            Language = language;
            Version = version;
        }
    }
}
