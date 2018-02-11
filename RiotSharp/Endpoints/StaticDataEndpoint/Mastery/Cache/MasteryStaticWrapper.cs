using Newtonsoft.Json;
using RiotSharp.Misc;

namespace RiotSharp.Endpoints.StaticDataEndpoint.Mastery.Cache
{
    class MasteryStaticWrapper
    {
        [JsonProperty]
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
