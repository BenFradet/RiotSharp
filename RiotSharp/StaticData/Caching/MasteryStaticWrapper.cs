using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiotSharp
{
    class MasteryStaticWrapper
    {
        public MasteryStatic MasteryStatic { get; private set; }
        public Language Language { get; private set; }
        public MasteryData MasteryData { get; private set; }

        public MasteryStaticWrapper(MasteryStatic mastery, Language language, MasteryData masteryData)
        {
            MasteryStatic = mastery;
            Language = language;
            MasteryData = masteryData;
        }
    }
}
