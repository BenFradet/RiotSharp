using Newtonsoft.Json;
using RiotSharp.Misc;

namespace RiotSharp.Endpoints.StaticDataEndpoint.SummonerSpell.Cache
{
    class SummonerSpellListStaticWrapper
    {
        [JsonProperty]
        public SummonerSpellListStatic SummonerSpellListStatic { get; private set; }
        public Language Language { get; private set; }
        public SummonerSpellData SummonerSpellData { get; private set; }

        public SummonerSpellListStaticWrapper(SummonerSpellListStatic spells, Language language
            , SummonerSpellData summonerSpellData)
        {
            SummonerSpellListStatic = spells;
            Language = language;
            SummonerSpellData = summonerSpellData;
        }
    }
}
