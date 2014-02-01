using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiotSharp
{
    class ChampionStaticWrapper
    {
        public ChampionStatic ChampionStatic { get; set; }
        public Language Language { get; set; }
        public ChampionData ChampionData { get; set; }

        public ChampionStaticWrapper(ChampionStatic champion, Language language, ChampionData championData)
        {
            ChampionStatic = champion;
            Language = language;
            ChampionData = championData;
        }
    }
}
