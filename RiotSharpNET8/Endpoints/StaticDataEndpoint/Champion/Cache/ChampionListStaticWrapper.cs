using System.Text.Json.Serialization;
using RiotSharpNET8.Misc;

namespace RiotSharpNET8.Endpoints.StaticDataEndpoint.Champion.Cache
{
    internal class ChampionListStaticWrapper
    {
        [JsonInclude]
        public ChampionListStatic ChampionListStatic { get; private set; }
        public Language Language { get; }
        public string Version { get; }

        public ChampionListStaticWrapper(ChampionListStatic champions, Language language, string version)
        {
            ChampionListStatic = champions;
            Language = language;
            Version = version;
        }
    }
}
