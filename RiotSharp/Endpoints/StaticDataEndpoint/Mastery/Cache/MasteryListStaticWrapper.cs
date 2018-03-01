using Newtonsoft.Json;
using RiotSharp.Misc;

namespace RiotSharp.Endpoints.StaticDataEndpoint.Mastery.Cache
{
    class MasteryListStaticWrapper
    {
        [JsonProperty]
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
