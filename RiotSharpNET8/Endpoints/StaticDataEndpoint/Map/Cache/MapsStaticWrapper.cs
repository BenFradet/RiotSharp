using System.Text.Json.Serialization;
using RiotSharpNET8.Misc;

namespace RiotSharpNET8.Endpoints.StaticDataEndpoint.Map.Cache
{
    internal class MapsStaticWrapper
    {
        [JsonInclude]
        public MapsStatic MapsStatic { get; private set; }
        public Language Language { get; }
        public string Version { get; }

        public MapsStaticWrapper(MapsStatic mapsStatic, Language language, string version)
        {
            MapsStatic = mapsStatic;
            Language = language;
            Version = version;
        }
    }
}
