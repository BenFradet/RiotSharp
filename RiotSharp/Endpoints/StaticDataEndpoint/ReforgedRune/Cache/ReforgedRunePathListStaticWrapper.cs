using RiotSharp.Misc;
using System;
using System.Collections.Generic;
using System.Text;

namespace RiotSharp.Endpoints.StaticDataEndpoint.ReforgedRune.Cache
{
    class ReforgedRunePathListStaticWrapper
    {
        public Language Language { get; set; }
        public string Version { get; set; }

        public List<ReforgedRunePathStatic> ReforgedRunePaths { get; set; }

        public ReforgedRunePathListStaticWrapper(Language language, string version, List<ReforgedRunePathStatic> reforgedRunePaths)
        {
            Language = language;
            Version = version;
            ReforgedRunePaths = reforgedRunePaths;
        }

        public bool Validate(Language language, string version)
        {
            return Language == language && Version == version;
        }
    }
}
