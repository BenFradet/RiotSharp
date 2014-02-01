using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiotSharp
{
    class ChampionListStaticWrapper
    {
        public ChampionListStatic ChampionListStatic { get; set; }
        public Language Language { get; set; }
        public DataRequested DataRequested { get; set; }

        public ChampionListStaticWrapper(ChampionListStatic champions, Language language, DataRequested dataRequested)
        {
            ChampionListStatic = champions;
            Language = language;
            DataRequested = dataRequested;
        }
    }
}
