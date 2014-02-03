using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiotSharp
{
    class RuneStaticWrapper
    {
        public RuneStatic RuneStatic { get; private set; }
        public Language Language { get; private set; }
        public RuneData RuneData { get; private set; }

        public RuneStaticWrapper(RuneStatic rune, Language language, RuneData runeData)
        {
            RuneStatic = rune;
            Language = language;
            RuneData = runeData;
        }
    }
}
