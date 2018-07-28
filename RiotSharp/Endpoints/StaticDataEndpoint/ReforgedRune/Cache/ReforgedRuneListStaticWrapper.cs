using RiotSharp.Misc;
using System;
using System.Collections.Generic;
using System.Text;

namespace RiotSharp.Endpoints.StaticDataEndpoint.ReforgedRune.Cache
{
    class ReforgedRuneListStaticWrapper
    {
        public Language Language { get; set; }
        public string Version { get; set; }

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
