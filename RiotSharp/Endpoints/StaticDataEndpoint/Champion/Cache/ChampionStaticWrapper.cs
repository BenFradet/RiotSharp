using Newtonsoft.Json;
using RiotSharp.Misc;

namespace RiotSharp.Endpoints.StaticDataEndpoint.Champion.Cache
{
    class ChampionStaticWrapper
    {
        [JsonProperty]
        public ChampionStatic ChampionStatic { get; private set; }
        public Language Language { get; private set; }
        public string Version { get; private set; }

        public ChampionStaticWrapper(ChampionStatic champion, Language language, string version)
        {
            ChampionStatic = champion;
            Language = language;
            Version = version;
        }
    }
}
