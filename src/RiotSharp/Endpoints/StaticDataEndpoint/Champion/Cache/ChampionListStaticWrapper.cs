using Newtonsoft.Json;
using RiotSharp.Misc;

namespace RiotSharp.Endpoints.StaticDataEndpoint.Champion.Cache
{
    internal class ChampionListStaticWrapper
    {
        [JsonProperty]
        public ChampionListStatic ChampionListStatic { get; private set; }
        public Language Language { get; }
        public string Version { get; }

        public ChampionListStaticWrapper(ChampionListStatic champions, Language language, string version)
        {
            ChampionListStatic = champions;
            Language = language;
            Version = version;
        }
    }
}
