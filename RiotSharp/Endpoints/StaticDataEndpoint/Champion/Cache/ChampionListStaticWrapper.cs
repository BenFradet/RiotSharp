using Newtonsoft.Json;
using RiotSharp.Misc;

namespace RiotSharp.Endpoints.StaticDataEndpoint.Champion.Cache
{
    class ChampionListStaticWrapper
    {
        [JsonProperty]
        public ChampionListStatic ChampionListStatic { get; private set; }
        public Language Language { get; private set; }
        public ChampionData ChampionData { get; private set; }

        public ChampionListStaticWrapper(ChampionListStatic champions, Language language, ChampionData championData)
        {
            ChampionListStatic = champions;
            Language = language;
            ChampionData = championData;
        }
    }
}
