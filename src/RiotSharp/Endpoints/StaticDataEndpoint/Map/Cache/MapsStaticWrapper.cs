using Newtonsoft.Json;
using RiotSharp.Misc;

namespace RiotSharp.Endpoints.StaticDataEndpoint.Map.Cache
{
    internal class MapsStaticWrapper
    {
        [JsonProperty]
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
