using Newtonsoft.Json;
using RiotSharp.Misc;

namespace RiotSharp.Endpoints.StaticDataEndpoint.SummonerSpell.Cache
{
    internal class SummonerSpellListStaticWrapper
    {
        [JsonProperty]
        public SummonerSpellListStatic SummonerSpellListStatic { get; private set; }
        public Language Language { get; }
        public string Version { get; }

        public SummonerSpellListStaticWrapper(SummonerSpellListStatic spells, Language language
            , string version)
        {
            SummonerSpellListStatic = spells;
            Language = language;
            Version = version;
        }
    }
}
