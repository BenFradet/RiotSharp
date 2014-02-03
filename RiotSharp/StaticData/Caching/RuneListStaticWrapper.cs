using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiotSharp
{
    class RuneListStaticWrapper
    {
        public RuneListStatic RuneListStatic { get; private set; }
        public Language Language { get; private set; }
        public RuneData RuneData { get; private set; }

        public RuneListStaticWrapper(RuneListStatic runes, Language language, RuneData runeData)
        {
            RuneListStatic = runes;
            Language = language;
            RuneData = runeData;
        }
    }
}
