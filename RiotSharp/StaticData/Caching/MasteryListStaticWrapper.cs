using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiotSharp
{
    class MasteryListStaticWrapper
    {
        public MasteryListStatic MasteryListStatic { get; private set; }
        public Language Language { get; private set; }
        public MasteryData MasteryData { get; private set; }

        public MasteryListStaticWrapper(MasteryListStatic masteries, Language language, MasteryData masteryData)
        {
            MasteryListStatic = masteries;
            Language = language;
            MasteryData = masteryData;
        }
    }
}
