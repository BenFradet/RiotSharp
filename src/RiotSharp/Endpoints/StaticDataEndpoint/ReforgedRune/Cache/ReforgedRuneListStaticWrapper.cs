using RiotSharp.Misc;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace RiotSharp.Endpoints.StaticDataEndpoint.ReforgedRune.Cache
{
    internal class ReforgedRuneListStaticWrapper
    {
        public Language Language { get; }
        public string Version { get; }

        [JsonProperty]
        public List<ReforgedRunePathStatic> ReforgedRunes { get; set; }

        public ReforgedRuneListStaticWrapper(Language language, string version, List<ReforgedRunePathStatic> reforgedRunes)
        {
            Language = language;
            Version = version;
            ReforgedRunes = reforgedRunes;
        }

        public bool Validate(Language language, string version)
        {
            return Language == language && Version == version;
        }
    }
}
