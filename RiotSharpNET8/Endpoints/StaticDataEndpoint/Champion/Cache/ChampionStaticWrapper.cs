using System.Text.Json.Serialization;
using RiotSharpNET8.Misc;

namespace RiotSharpNET8.Endpoints.StaticDataEndpoint.Champion.Cache
{
    internal class ChampionStaticWrapper
    {
        [JsonInclude]
        public ChampionStatic ChampionStatic { get; private set; }
        public Language Language { get; }
        public string Version { get; }

        public ChampionStaticWrapper(ChampionStatic champion, Language language, string version)
        {
            ChampionStatic = champion;
            Language = language;
            Version = version;
        }
    }
}
