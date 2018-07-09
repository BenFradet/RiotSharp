using Newtonsoft.Json;
using RiotSharp.Misc;

namespace RiotSharp.Endpoints.StaticDataEndpoint.Champion.Cache
{
    class ChampionListStaticWrapper
    {
        [JsonProperty]
        public ChampionListStatic ChampionListStatic { get; private set; }
        public Language Language { get; private set; }
        public string Version { get; private set; }

        public ChampionListStaticWrapper(ChampionListStatic champions, Language language, string version)
        {
            ChampionListStatic = champions;
            Language = language;
            Version = version;
        }
    }
}
