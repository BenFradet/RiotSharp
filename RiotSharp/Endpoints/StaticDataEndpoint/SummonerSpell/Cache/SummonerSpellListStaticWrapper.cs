using Newtonsoft.Json;
using RiotSharp.Misc;

namespace RiotSharp.Endpoints.StaticDataEndpoint.SummonerSpell.Cache
{
    class SummonerSpellListStaticWrapper
    {
        [JsonProperty]
        public SummonerSpellListStatic SummonerSpellListStatic { get; private set; }
        public Language Language { get; private set; }
        public string Version { get; private set; }

        public SummonerSpellListStaticWrapper(SummonerSpellListStatic spells, Language language
            , string version)
        {
            SummonerSpellListStatic = spells;
            Language = language;
            Version = version;
        }
    }
}
