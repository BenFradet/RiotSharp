using Newtonsoft.Json;
using RiotSharp.Misc;

namespace RiotSharp.Endpoints.StaticDataEndpoint.SummonerSpell.Cache
{
    class SummonerSpellStaticWrapper
    {
        [JsonProperty]
        public SummonerSpellStatic SummonerSpellStatic { get; private set; }
        public Language Language { get; private set; }
        public SummonerSpellData SummonerSpellData { get; private set; }

        public SummonerSpellStaticWrapper(SummonerSpellStatic spell, Language language
            , SummonerSpellData summonerSpellData)
        {
            SummonerSpellStatic = spell;
            Language = language;
            SummonerSpellData = summonerSpellData;
        }
    }
}
