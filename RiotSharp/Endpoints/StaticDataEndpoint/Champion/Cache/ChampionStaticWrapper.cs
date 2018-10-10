using Newtonsoft.Json;
using RiotSharp.Misc;

namespace RiotSharp.Endpoints.StaticDataEndpoint.Champion.Cache
{
    internal class ChampionStaticWrapper
    {
        [JsonProperty]
        public ChampionStatic ChampionStatic { get; private set; }
        public Language Language { get; }
        public string Version { get; }

        public ChampionStaticWrapper(ChampionStatic champion, Language language, string version)
        {
            ChampionStatic = champion;
            Language = language;
            Version = version;
        }
    }
}
