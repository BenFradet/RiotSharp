using System.Text.Json.Serialization;
using RiotSharpNET8.Misc;

namespace RiotSharpNET8.Endpoints.StaticDataEndpoint.SummonerSpell.Cache
{
    internal class SummonerSpellListStaticWrapper
    {
        [JsonInclude]
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
