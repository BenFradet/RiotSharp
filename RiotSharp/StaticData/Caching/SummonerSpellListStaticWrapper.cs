using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiotSharp
{
    class SummonerSpellListStaticWrapper
    {
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
