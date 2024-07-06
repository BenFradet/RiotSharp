using System.Text.Json.Serialization;
using RiotSharpNET8.Misc;

namespace RiotSharpNET8.Endpoints.StaticDataEndpoint.Mastery.Cache
{
    internal class MasteryListStaticWrapper
    {
        [JsonInclude]
        public MasteryListStatic MasteryListStatic { get; private set; }
        public Language Language { get; }
        public string Version { get; }

        public MasteryListStaticWrapper(MasteryListStatic masteries, Language language, string version)
        {
            MasteryListStatic = masteries;
            Language = language;
            Version = version;
        }
    }
}
