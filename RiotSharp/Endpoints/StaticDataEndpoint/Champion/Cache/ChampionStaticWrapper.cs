using Newtonsoft.Json;
using RiotSharp.Misc;

namespace RiotSharp.Endpoints.StaticDataEndpoint.Champion.Cache
{
    class ChampionStaticWrapper
    {
        [JsonProperty]
        public ChampionStatic ChampionStatic { get; private set; }
        public Language Language { get; private set; }
        public ChampionData ChampionData { get; private set; }

        public ChampionStaticWrapper(ChampionStatic champion, Language language, ChampionData championData)
        {
            ChampionStatic = champion;
            Language = language;
            ChampionData = championData;
        }
    }
}
